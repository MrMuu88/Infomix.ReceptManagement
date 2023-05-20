using Frontend.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Frontend
{
    public static class ApiKommunikacio
    {
        private static string apiBaseUrl = "https://localhost:7235/api/PrescriptionApi";

        public static async Task<Recept> ReceptLekereseAsync(int id)
        {
            try
            {
                // Az API végpont URL-je és az adott rekord azonosítója
                string apiUrl = apiBaseUrl + "/" + id;

                // HttpClient inicializálása
                using var httpKliens = new HttpClient();

                // GET kérés elküldése az API végpont felé
                var valasz = await httpKliens.GetAsync(apiUrl);

                // Válasz ellenőrzése
                if (!valasz.IsSuccessStatusCode)
                {
                    throw new Exception("Recept lekérdezése sikertelen: " + valasz.StatusCode);
                }

                // Válasz tartalmának olvasása JSON formátumban
                string jsonRecept = await valasz.Content.ReadAsStringAsync();

                // JSON formátumból történő deszerializálás Recept objektummá
                Recept recept = JsonConvert.DeserializeObject<Recept>(jsonRecept);

                return recept;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static async Task ReceptHozzaadasaAsync(Recept ujRecept)
        {
            string url = apiBaseUrl;
            string jsonStringRecept = JsonConvert.SerializeObject(ujRecept);

            using (HttpClient client = new HttpClient())
            {
                // Beállítások a kéréshez
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                // A POST kérés elküldése
                HttpResponseMessage response = await client.PostAsync(url, new StringContent(jsonStringRecept, System.Text.Encoding.UTF8, "application/json"));

                // A válasz kezelése
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Sikeres POST kérés");
                }
                else
                {
                    Console.WriteLine($"Hiba történt: {response.StatusCode}");
                }
            }
        }

        public static async Task ReceptModositasaAsync(int id, Recept updatedRecept)
        {
            // Az updatedRecept objektum JSON formátummá alakítása
            string jsonRecept = JsonConvert.SerializeObject(updatedRecept);

            // Az API végpont URL-je és az adott rekord azonosítója
            string apiUrl = apiBaseUrl + id;

            // HttpClient inicializálása
            using var httpKliens = new HttpClient();

            // PUT kérés elküldése az API végpont felé
            var valasz = await httpKliens.PutAsync(apiUrl, new StringContent(jsonRecept, Encoding.UTF8, "application/json"));

            // Válasz ellenőrzése
            if (!valasz.IsSuccessStatusCode)
            {
                throw new Exception("Recept frissítése sikertelen: " + valasz.StatusCode);
            }
        }
     
        public static async Task ReceptTorlese(int id)
        {
            using (HttpClient httpKliens = new HttpClient())
            {
                string url = apiBaseUrl + "/" + id;

                HttpResponseMessage valasz = await httpKliens.DeleteAsync(url);

                if (valasz.IsSuccessStatusCode)
                {
                    Console.WriteLine("Törölve");
                }
                else
                {
                    Console.WriteLine("Hiba. Status code: " + valasz.StatusCode);
                }
            }
        }
    }
}
