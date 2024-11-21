using Dapper;
using KnyguNuoma.Core.Contracts;
using KnyguNuoma.Core.Modeliai;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

/*namespace KnyguNuoma.Infrastructure.Repozitorijos
{
    public class ElektroniniuKnyguRepozitorija : IElektroniniuKnyguRepozitorija
    {
        private readonly string _connectionString;

        public ElektroniniuKnyguRepozitorija(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Pridėti elektroninę knygą
        public async Task<bool> PridėtiKnygą(ElektroninėKnyga knyga)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = @"
                    INSERT INTO Knygos (Pavadinimas, Autorius, Kategorija, NuomosKaina, SukurimoData, Tipas, FailoFormatas, FailoDydisMB, KopijuKiekis, ISBN)
                    VALUES (@Pavadinimas, @Autorius, @Kategorija, @NuomosKaina, @SukurimoData, 'Elektroninė', @FailoFormatas, @FailoDydisMB, NULL, NULL);
                    SELECT CAST(SCOPE_IDENTITY() AS INT);";

                var parameters = new
                {
                    knyga.Pavadinimas,
                    knyga.Autorius,
                    knyga.Kategorija,
                    knyga.NuomosKaina,
                    knyga.SukurimoData,
                    knyga.FailoFormatas,
                    knyga.FailoDydisMB
                };

                var result = await connection.ExecuteScalarAsync<int>(query, parameters);
                return result > 0;
            }
        }

        // Gauti elektroninę knygą pagal ID
        public async Task<ElektroninėKnyga> GautiKnygąPagalId(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM Knygos WHERE Id = @Id AND Tipas = 'Elektroninė'";
                var knyga = await connection.QuerySingleOrDefaultAsync<ElektroninėKnyga>(query, new { Id = id });
                return knyga;
            }
        }

        // Gauti visas elektronines knygas
        public async Task<List<ElektroninėKnyga>> GautiVisasKnygas()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM Knygos WHERE Tipas = 'Elektroninė'";
                var knygos = await connection.QueryAsync<ElektroninėKnyga>(query);
                return knygos.AsList();
            }
        }




        async Task<IEnumerable<Knyga>> IElektroniniuKnyguRepozitorija.GautiVisasKnygasPagalKategorija(string kategorija)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM Knygos WHERE Kategorija = @Kategorija AND Tipas = 'Elektroninė'";
                var knygos = await connection.QueryAsync<ElektroninėKnyga>(query, new { Kategorija = kategorija });
                return knygos.AsList();
            }
        }
    }
     
}*/
