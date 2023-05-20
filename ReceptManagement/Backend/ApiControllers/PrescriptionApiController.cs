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
                var requestBody = await reader.ReadToEndAsync();

                Recept newPrescription = JsonConvert.DeserializeObject<Recept>(requestBody);
                _dbContext.Receptek.Add(newPrescription);
                _dbContext.SaveChanges();
                return Ok(); // Return an appropriate response
            }
        }

        // PUT api/<PrescriptionApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Recept recept)
        {
            Recept existingRecept = _dbContext.Receptek.FirstOrDefault(r => r.ReceptId == id);
            if (existingRecept == null)
            {
                throw new Exception("Not Found - Recept Id: " + id);
            }
            existingRecept.ReceptKiallitasDatuma = recept.ReceptKiallitasDatuma;
            existingRecept.EURendelkezessel = recept.EURendelkezessel;
            existingRecept.TeljesAronRendelve = recept.TeljesAronRendelve;
            existingRecept.EUTeritesKotelesAronRendelve = recept.EUTeritesKotelesAronRendelve;
            existingRecept.Helyettesitheto = recept.Helyettesitheto;
            existingRecept.AltalanosJogcimmel = recept.AltalanosJogcimmel;
            existingRecept.ReceptSzovege = recept.ReceptSzovege;
            existingRecept.Kozgyogyellatottnak = recept.Kozgyogyellatottnak;
            existingRecept.PaciensId = recept.PaciensId;
            existingRecept.BNOId = recept.BNOId;
            _dbContext.SaveChanges();
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
