using Dapper;
using KnyguNuoma.Core.Contracts;
using KnyguNuoma.Core.Modeliai;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace KnyguNuoma.Infrastructure.Repozitorijos
{
    public class NaudotojųRepozitorija : INaudotojųRepozitorija
    {
        private readonly string _connectionString;

        // Konstruktoriumi įvedame duomenų bazės prisijungimo eilutę
        public NaudotojųRepozitorija(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Gauti visus naudotojus
        public List<Naudotojas> GautiVisus()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                // SQL užklausa, kad gauti visus naudotojus
                var query = "SELECT * FROM Naudotojai";
                // Padedame Dapper parsinti duomenis į Naudotojo objektus ir grąžinti sąrašą
                return connection.Query<Naudotojas>(query).ToList();
            }
        }

        // Gauti naudotoją pagal ID
        public Naudotojas? GautiPagalId(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                // SQL užklausa, kad gauti naudotoją pagal jo ID
                var query = "SELECT * FROM Naudotojai WHERE Id = @Id";
                // Padedame Dapper parsinti duomenis ir grąžinti Naudotoją, jei jis yra
                return connection.QueryFirstOrDefault<Naudotojas>(query, new { Id = id });
            }
        }

        // Pridėti naudotoją
        public async Task<bool> PridėtiNaudotoją(Naudotojas naudotojas)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = @"
            INSERT INTO Naudotojai (Vardas, ElPastas) 
            VALUES (@Vardas, @ElPaštas)";  // Naudojame @ElPaštas, nes modelyje taip vadinasi laukas

                var result = await connection.ExecuteAsync(query, new
                {
                    Vardas = naudotojas.Vardas,
                    ElPaštas = naudotojas.ElPaštas  // Užtikrinkite, kad ElPaštas perduodamas
                });

                return result > 0; // Grąžiname true, jei įrašas buvo pridėtas
            }
        }

        // Ištrinti naudotoją pagal ID
        public async Task<bool> IštrintiNaudotoją(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                // SQL užklausa, kad ištrinti naudotoją pagal ID
                var query = "DELETE FROM Naudotojai WHERE Id = @Id";

                // Atlikti užklausą ir tikrinti, ar įrašas buvo ištrintas
                var result = await connection.ExecuteAsync(query, new { Id = id });

                // Jei užklausa buvo sėkminga, grąžiname true
                return result > 0;
            }
        }
    }
}
