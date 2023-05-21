using Frontend.Models;
using Frontend.ResponseClasses;
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
        private static string apiBaseUrl = "https://localhost:7235/api";

        // https://localhost:7235/api/PrescriptionApi/7
        public static async Task<Recept> ReceptLekereseAsync(int id)
        {
            try
            {
                // Az API végpont URL-je és az adott rekord azonosítója
                string apiUrl = apiBaseUrl + "/PrescriptionApi/" + id;

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
            catch (Exception)
            {
                throw;
            }
        }

        // https://localhost:7235/api/PrescriptionApi/limitoffset?limit=4&offset=10
        public static async Task<List<PrescriptionResponse>> ReceptekLekereseAsync(int limit = 20, int offset = 0)
        {
            try
            {
                // Az API végpont URL-je és az adott rekord azonosítója
                string apiUrl = apiBaseUrl + "/PrescriptionApi/limitoffset?limit=" + limit + "&offset=" + offset;

                // HttpClient inicializálása
                using var httpKliens = new HttpClient();

                // GET kérés elküldése az API végpont felé
                var valasz = await httpKliens.GetAsync(apiUrl);

                // Válasz ellenőrzése
                if (!valasz.IsSuccessStatusCode)
                {
                    throw new Exception("Receptek lekérdezése sikertelen: " + valasz.StatusCode);
                }

                // Válasz tartalmának olvasása JSON formátumban
                string jsonRecept = await valasz.Content.ReadAsStringAsync();

                // JSON formátumból történő deszerializálás List<Recept> listává
                List<PrescriptionResponse> receptek = JsonConvert.DeserializeObject<List<PrescriptionResponse>>(jsonRecept);

                return receptek;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task ReceptHozzaadasaAsync(Recept ujRecept)
        {
            string url = apiBaseUrl + "/PrescriptionApi";
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

        public static async Task ReceptModositasaAsync(Recept modositottRecept)
        {
            // A modositottRecept objektum JSON formátummá alakítása
            string jsonRecept = JsonConvert.SerializeObject(modositottRecept);

            // Az API végpont URL-je és az adott rekord azonosítója
            string apiUrl = apiBaseUrl + "/PrescriptionApi" + "/" + modositottRecept.ReceptId;

            // HttpClient inicializálása
            using var httpKliens = new HttpClient();

            // PUT kérés elküldése az API végpont felé
            var valasz = await httpKliens.PutAsync(apiUrl, new StringContent(jsonRecept, Encoding.UTF8, "application/json"));

            // Válasz ellenőrzése
            if (valasz.IsSuccessStatusCode)
            {
                Console.WriteLine("Sikeres PUT kérés");
            }
            else
            {
                Console.WriteLine($"Hiba történt: {valasz.StatusCode}");
            }
        }

        public static async Task ReceptTorlese(int id)
        {
            using (HttpClient httpKliens = new HttpClient())
            {
                string apiUrl = apiBaseUrl + "/PrescriptionApi" + "/" + id;

                HttpResponseMessage valasz = await httpKliens.DeleteAsync(apiUrl);

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

        public static async Task<List<BNOResponse>> BNOkLekereseAsync()
        {
            try
            {
                // Az API végpont URL-je és az adott rekord azonosítója
                string apiUrl = apiBaseUrl + "/BNOApi/";

                // HttpClient inicializálása
                using var httpKliens = new HttpClient();

                // GET kérés elküldése az API végpont felé
                var valasz = await httpKliens.GetAsync(apiUrl);

                // Válasz ellenőrzése
                if (!valasz.IsSuccessStatusCode)
                {
                    throw new Exception("BNOk lekérdezése sikertelen: " + valasz.StatusCode);
                }

                // Válasz tartalmának olvasása JSON formátumban
                string jsonBNOk = await valasz.Content.ReadAsStringAsync();

                // JSON formátumból történő deszerializálás
                List<BNOResponse> BNOk = JsonConvert.DeserializeObject<List<BNOResponse>>(jsonBNOk);

                return BNOk;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<List<PatientsResponse>> PaciensekLekereseAsync()
        {
            try
            {
                // Az API végpont URL-je és az adott rekord azonosítója
                string apiUrl = apiBaseUrl + "/PatientsApi/";

                // HttpClient inicializálása
                using var httpKliens = new HttpClient();

                // GET kérés elküldése az API végpont felé
                var valasz = await httpKliens.GetAsync(apiUrl);

                // Válasz ellenőrzése
                if (!valasz.IsSuccessStatusCode)
                {
                    throw new Exception("Páciensek lekérdezése sikertelen: " + valasz.StatusCode);
                }

                // Válasz tartalmának olvasása JSON formátumban
                string jsonPaciensek = await valasz.Content.ReadAsStringAsync();

                // JSON formátumból történő deszerializálás
                List<PatientsResponse> Paciensek = JsonConvert.DeserializeObject<List<PatientsResponse>>(jsonPaciensek);

                return Paciensek;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
