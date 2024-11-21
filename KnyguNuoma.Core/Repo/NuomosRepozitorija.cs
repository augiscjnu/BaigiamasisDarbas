using Dapper;
using KnyguNuoma.Core.Contracts;
using KnyguNuoma.Core.Modeliai;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

public class NuomosRepozitorija : INuomosRepozitorija
{
    private readonly string _connectionString;

    public NuomosRepozitorija(string connectionString)
    {
        _connectionString = connectionString;
    }

    // Pradėti nuomą
    public async Task PradetiNuomą(int knygosId, int vartotojoId, DateTime? pradziosData = null, DateTime? pabaigosData = null)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            // Jei pradžios data nėra pateikta, naudojame dabartinę datą
            var pradžiosData = pradziosData ?? DateTime.Now;

            // Jei pabaigos data nėra pateikta, nustatome ją kaip NULL (nes nuoma gali būti aktyvi)
            DateTime? galiojaIki = pabaigosData; // Pabaigos data gali būti null, jei ji nėra nurodyta

            var query = @"
        INSERT INTO NuomosIrasai (KnygosId, NaudotojoId, NuomosPradziosData, NuomosPabaigosData)
        VALUES (@KnygosId, @NaudotojoId, @NuomosPradziosData, @NuomosPabaigosData)";

            await connection.ExecuteAsync(query, new
            {
                KnygosId = knygosId,
                NaudotojoId = vartotojoId,
                NuomosPradziosData = pradžiosData,
                NuomosPabaigosData = galiojaIki // Jei pabaigos data yra null, ji bus įrašyta kaip null
            });
        }
    }




    // Užbaigti nuomą
    public async Task UzbiegtiNuomą(int nuomosId)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var query = "UPDATE NuomosIrasai SET NuomosPabaigosData = @NuomosPabaigosData WHERE Id = @NuomosId";
            await connection.ExecuteAsync(query, new
            {
                NuomosId = nuomosId,
                PabaigosData = DateTime.Now
            });
        }
    }

    // Gauti aktyvią nuomą pagal vartotojo Id
    public async Task<NuomosĮrašas> GautiAktyviaNuomą(int vartotojoId)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var query = "SELECT * FROM NuomosIrasai WHERE NaudotojoId = @NaudotojoId AND NuomosPabaigosData IS NULL";
            return await connection.QueryFirstOrDefaultAsync<NuomosĮrašas>(query, new { NaudotojoId = vartotojoId });
        }
    }

    // Gauti nuomos istoriją pagal vartotojo Id
    public async Task<List<NuomosĮrašas>> GautiNuomosIstoriją(int vartotojoId)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var query = "SELECT * FROM NuomosIrasai WHERE NaudotojoId = @NaudotojoId";
            var nuomos = await connection.QueryAsync<NuomosĮrašas>(query, new { NaudotojoId = vartotojoId });
            return nuomos.ToList();
        }
    }

    // Gauti klientus, kurie nuomojo konkrečią knygą
    public async Task<List<Naudotojas>> GautiKlientusPagalKnygą(int knygosId)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var query = @"
                SELECT Vartotojai.* 
                FROM Vartotojai 
                JOIN NuomosIrasai ON Vartotojai.Id = NuomosIrasai.NaudotojoId 
                WHERE NuomosIrasai.KnygosId = @KnygosId AND NuomosIrasai.PabaigosData IS NULL";  // PabaigosData IS NULL rodo aktyvias nuomas
            var vartotojai = await connection.QueryAsync<Naudotojas>(query, new { KnygosId = knygosId });
            return vartotojai.ToList();
        }
    }

    // Gauti visas esamas nuomas
    public async Task<List<NuomosĮrašas>> GautiVisasEsamasNuomas()
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var query = "SELECT * FROM NuomosIrasai";
            var nuomos = await connection.QueryAsync<NuomosĮrašas>(query);
            return nuomos.ToList();
        }
    }
}
