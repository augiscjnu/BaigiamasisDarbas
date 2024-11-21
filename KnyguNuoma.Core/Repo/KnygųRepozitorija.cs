using Dapper;
using KnyguNuoma.Core.Contracts;
using KnyguNuoma.Core.Modeliai;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace KnyguNuoma.Infrastructure.Repozitorijos
{
    public class KnyguRepozitorija : IKnyguRepozitorija
    {
        private readonly string _connectionString;

        public KnyguRepozitorija(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Add a new book (either physical or electronic)
        public async Task<bool> PridėtiKnygą(Knyga knyga)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string query = @"
                    INSERT INTO Knygos (Pavadinimas, Autorius, Kategorija, NuomosKaina, SukurimoData, Tipas, KopijųKiekis, ISBN, FailoFormatas, FailoDydisMB)
                    VALUES (@Pavadinimas, @Autorius, @Kategorija, @NuomosKaina, @SukurimoData, @Tipas, @KopijųKiekis, @ISBN, @FailoFormatas, @FailoDydisMB)";

                var parameters = new
                {
                    Pavadinimas = knyga.Pavadinimas,
                    Autorius = knyga.Autorius,
                    Kategorija = knyga.Kategorija,
                    NuomosKaina = knyga.NuomosKaina,
                    SukurimoData = knyga.SukurimoData,
                    Tipas = knyga.Tipas,
                    KopijųKiekis = (knyga is PopierinėKnyga) ? ((PopierinėKnyga)knyga).KopijųKiekis : (int?)null,
                    ISBN = (knyga is PopierinėKnyga) ? ((PopierinėKnyga)knyga).ISBN : (string)null,
                    FailoFormatas = (knyga is ElektroninėKnyga) ? ((ElektroninėKnyga)knyga).FailoFormatas : (string)null,
                    FailoDydisMB = (knyga is ElektroninėKnyga) ? ((ElektroninėKnyga)knyga).FailoDydisMB : (double?)null
                };

                var result = await connection.ExecuteAsync(query, parameters);
                return result > 0;
            }
        }

        // Retrieve all books (both physical and electronic)
        public async Task<List<Knyga>> GautiVisasKnygas()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Knygos"; // Query to get all books

                // Fetching the data from the database
                var books = await connection.QueryAsync<Knyga>(query);

                return books.ToList();
            }
        }


        // Retrieve books by category
        public async Task<List<Knyga>> GautiKnygasPagalKategoriją(string kategorija)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Knygos WHERE Kategorija = @Kategorija";
                var books = await connection.QueryAsync(query, new { Kategorija = kategorija });

                var knygos = new List<Knyga>();

                foreach (var book in books)
                {
                    if (book.Tipas == "Popierinė")
                    {
                        var paperBook = new PopierinėKnyga
                        {
                            Id = book.Id,
                            Pavadinimas = book.Pavadinimas,
                            Autorius = book.Autorius,
                            Kategorija = book.Kategorija,
                            NuomosKaina = book.NuomosKaina,
                            SukurimoData = book.SukurimoData,
                            Tipas = book.Tipas,
                            KopijųKiekis = (int)(book.KopijųKiekis as int?),
                            ISBN = book.ISBN
                        };
                        knygos.Add(paperBook);
                    }
                    else if (book.Tipas == "Elektroninė")
                    {
                        var electronicBook = new ElektroninėKnyga
                        {
                            Id = book.Id,
                            Pavadinimas = book.Pavadinimas,
                            Autorius = book.Autorius,
                            Kategorija = book.Kategorija,
                            NuomosKaina = book.NuomosKaina,
                            SukurimoData = book.SukurimoData,
                            Tipas = book.Tipas,
                            FailoFormatas = book.FailoFormatas,
                            FailoDydisMB = (double)(book.FailoDydisMB as double?)
                        };
                        knygos.Add(electronicBook);
                    }
                }

                return knygos;
            }
        }
    }
}
