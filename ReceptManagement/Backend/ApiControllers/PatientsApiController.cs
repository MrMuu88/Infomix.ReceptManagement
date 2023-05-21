using Backend.Models;
using Backend.ResponseClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Backend.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsApiController : ControllerBase
    {
        private readonly ReceptDbContext _dbContext;

        public PatientsApiController(ReceptDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/<PatientsApiController>
        [HttpGet]
        public IEnumerable<PatientsResponse> Get()
        {
            return _dbContext.Paciensek.OrderBy(p => p.Nev).Select(p => new PatientsResponse()
            {
                PatientId = p.PaciensId,
                PatientName = p.Nev
            }).ToList();
        }

    }
}
