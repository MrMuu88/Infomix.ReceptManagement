using Backend.Models;
using Backend.ResponseClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Backend.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BNOApiController : ControllerBase
    {
        private readonly ReceptDbContext _dbContext;

        public BNOApiController(ReceptDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/<BNOApiController>
        [HttpGet]
        public IEnumerable<BNOResponse> Get()
        {
            return _dbContext.BNOk.OrderBy(b => b.BetegsegNeve).Select(b => new BNOResponse
            {
                BetegsegNeve = b.BetegsegNeve,
                BNOId = b.BNOId,
                BNOKod = b.BNOKod,
            }).ToList();
        }

    }
}
