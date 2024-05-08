using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SabeNaoSabe.WebAPI.Data;
using SabeNaoSabe.WebAPI.Entity;

namespace SabeNaoSabe.WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class QuestionarioController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public QuestionarioController(ApplicationDbContext db)
        {
            _db = db;   
        }
        [HttpGet]
        public IEnumerable<Questionario> Gets() 
        { 
            return _db.Questionarios.ToList();
        }
        [HttpPost]
        public IActionResult Posts(Questionario questionario) 
        {
            _db.Questionarios.Add(questionario);
            _db.SaveChanges();
            return Ok();
        }
    }
}
