using Dapper;
using KnyguNuoma.Core.Contracts;
using KnyguNuoma.Core.Modeliai;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

/*namespace KnyguNuoma.Infrastructure.Repozitorijos
{
    public class PopieriniuKnyguRepozitorija : IPopieriniuKnyguRepozitorija
    {
        private readonly string _connectionString;

        public PopieriniuKnyguRepozitorija(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Pridėti popierinę knygą
        public async Task<bool> PridėtiKnygą(PopierinėKnyga knyga)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = @"
                    INSERT INTO Knygos (Pavadinimas, Autorius, Kategorija, NuomosKaina, SukurimoData, Tipas, FailoFormatas, FailoDydisMB, KopijuKiekis, ISBN)
                    VALUES (@Pavadinimas, @Autorius, @Kategorija, @NuomosKaina, @SukurimoData, 'Popierinė', NULL, NULL, @KopijuKiekis, @ISBN);
                    SELECT CAST(SCOPE_IDENTITY() AS INT);";

                var parameters = new
                {
                    knyga.Pavadinimas,
                    knyga.Autorius,
                    knyga.Kategorija,
                    knyga.NuomosKaina,
                    knyga.SukurimoData,
                    knyga.KopijųKiekis,
                    knyga.ISBN
                };

                var result = await connection.ExecuteScalarAsync<int>(query, parameters);
                return result > 0;
            }
        }

        // Gauti popierinę knygą pagal ID
        public async Task<PopierinėKnyga> GautiKnygąPagalId(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM Knygos WHERE Id = @Id AND Tipas = 'Popierinė'";
                var knyga = await connection.QuerySingleOrDefaultAsync<PopierinėKnyga>(query, new { Id = id });
                return knyga;
            }
        }

        // Gauti visas popierines knygas
        public async Task<List<PopierinėKnyga>> GautiVisasKnygas()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM Knygos WHERE Tipas = 'Popierinė'";
                var knygos = await connection.QueryAsync<PopierinėKnyga>(query);
                return knygos.AsList();
            }
        }

        // Gauti visas popierines knygas pagal kategoriją
        async Task<IEnumerable<Knyga>> IPopieriniuKnyguRepozitorija.GautiVisasKnygasPagalKategorija(string kategorija)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM Knygos WHERE Kategorija = @Kategorija AND Tipas = 'Popierinė'";
                var knygos = await connection.QueryAsync<PopierinėKnyga>(query, new { Kategorija = kategorija });
                return knygos.AsList();
            }
        }

       
    }
}*/
