using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceptekApiController : ControllerBase
    {
        // https://localhost:7235/api/ReceptekApi

        private readonly ReceptDbContext _dbContext;

        public ReceptekApiController(ReceptDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/<ReceptekApiController>
        [HttpGet]
        public IEnumerable<Recept> Get()
        {
            return _dbContext.Receptek.ToList();
        }

        // GET api/<ReceptekApiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ReceptekApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ReceptekApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ReceptekApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
