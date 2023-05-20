﻿using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Backend.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionApiController : ControllerBase
    {
        // https://localhost:7235/api/PrescriptionApi

        private readonly ReceptDbContext _dbContext;

        public PrescriptionApiController(ReceptDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/<PrescriptionApiController>
        [HttpGet]
        public IEnumerable<Recept> Get()
        {
            return _dbContext.Receptek.ToList();
        }

        // GET api/<PrescriptionApiController>/5
        [HttpGet("{id}")]
        public Recept Get(int id)
        {
            return _dbContext.Receptek.Where(r => r.ReceptId == id).FirstOrDefault();
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            using (StreamReader reader = new StreamReader(Request.Body))
            {
                string? requestBody = await reader.ReadToEndAsync();

                Recept newPrescription = JsonConvert.DeserializeObject<Recept>(requestBody);
                _dbContext.Receptek.Add(newPrescription);
                _dbContext.SaveChanges();
                return Ok(); // Return an appropriate response
            }
        }

        // PUT api/<PrescriptionApiController>/5
        [HttpPut("{id}")]

        public async Task<IActionResult> Put(int id)
        {
            using (StreamReader reader = new StreamReader(Request.Body))
            {
                string? requestBody = await reader.ReadToEndAsync();
                if (string.IsNullOrEmpty(requestBody))
                {
                    return NoContent();
                }

                // Deserialize the request body into an object
                Recept updatedPrescription = JsonConvert.DeserializeObject<Recept>(requestBody);

                // Update the existing prescription with the provided ID
                var existingPrescription = _dbContext.Receptek.Find(id);
                if (existingPrescription == null)
                {
                    return NotFound(); // Return a 404 Not Found response if the prescription doesn't exist
                }

                // Update the properties of the existing prescription
                existingPrescription.ReceptKiallitasDatuma = updatedPrescription.ReceptKiallitasDatuma;
                existingPrescription.EURendelkezessel = updatedPrescription.EURendelkezessel;
                existingPrescription.TeljesAronRendelve = updatedPrescription.TeljesAronRendelve;
                existingPrescription.EUTeritesKotelesAronRendelve = updatedPrescription.EUTeritesKotelesAronRendelve;
                existingPrescription.Helyettesitheto = updatedPrescription.Helyettesitheto;
                existingPrescription.AltalanosJogcimmel = updatedPrescription.AltalanosJogcimmel;
                existingPrescription.ReceptSzovege = updatedPrescription.ReceptSzovege;
                existingPrescription.Kozgyogyellatottnak = updatedPrescription.Kozgyogyellatottnak;
                existingPrescription.PaciensId = updatedPrescription.PaciensId;
                existingPrescription.BNOId = updatedPrescription.BNOId;
                _dbContext.SaveChanges();

                return Ok(); // Return an appropriate response
            }
        }

        // DELETE api/<PrescriptionApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Recept existingRecept = _dbContext.Receptek.FirstOrDefault(r => r.ReceptId == id);
            if (existingRecept == null)
            {
                throw new Exception("Not Found - Recept Id: " + id);
            }
            _dbContext.Receptek.Remove(existingRecept);
            _dbContext.SaveChanges();
        }
    }
}
