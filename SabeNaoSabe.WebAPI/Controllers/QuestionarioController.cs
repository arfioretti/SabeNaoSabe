using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SabeNaoSabe.WebAPI.Data;
using SabeNaoSabe.WebAPI.Model;


namespace SabeNaoSabe.WebAPI.Controllers;

[EnableCors("MyPolicy")]
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
    public ActionResult <IEnumerable<QuestionarioModel>> GetQuestionarios()
    {
        return Ok(_db.Questionarios.ToList());
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<QuestionarioModel?>> GetByIdQuestionario(int id)
    {
        return await _db.Questionarios.Where(u=>u.Id == id).SingleOrDefaultAsync();
    }
    [HttpPost]
    public async Task<ActionResult> PostQuestionario([FromBody]QuestionarioModel questionario) 
    {
        await _db.Questionarios.AddAsync(questionario);
        await _db.SaveChangesAsync();
        return Ok(questionario);
    }
    [HttpPut]
    public async Task<ActionResult> PutQuestionario(QuestionarioModel questionario)
    {
        _db.Questionarios.Update(questionario);        
        await _db.SaveChangesAsync();
        return Ok();
    }
    [HttpDelete]
    public async Task<ActionResult<QuestionarioModel?>> DeleteQuestionario(QuestionarioModel questionario)
    {
        //var questionario = await _db.Questionarios.Where(u => u.Id == id).SingleOrDefaultAsync();
        _db.Questionarios.Remove(questionario);
        await _db.SaveChangesAsync();
        return Ok(questionario);
    }

}
