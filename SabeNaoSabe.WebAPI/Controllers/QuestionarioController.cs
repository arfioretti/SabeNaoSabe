    using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SabeNaoSabe.WebAPI.Data;
using SabeNaoSabe.WebAPI.Model;
using SabeNaoSabe.WebAPI.Models;


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
    [HttpGet]
    [Route("GetUploadedFile")]
    public async Task<ActionResult> GetUploadedFile(string name)
    {        
        var path=Path.Combine(Directory.GetCurrentDirectory(), "Uploaded",  name);
        var stream = new FileStream(path, FileMode.Open, FileAccess.Read);
        return File(stream, "application/ocetet-stream", name); ;
    }

    [HttpPost]
    public async Task<ActionResult> PostQuestionario([FromBody]QuestionarioModel questionario) 
    {
        await _db.Questionarios.AddAsync(questionario);
        await _db.SaveChangesAsync();
        return Ok(questionario);
    }
    [HttpPost]
    [Route("UploadedFile")]
    public async Task<ActionResult> PostUploadedFile([FromBody] UploadedFile uploadedFile)
    {
        var path = $"{Environment.CurrentDirectory}\\Uploaded\\{uploadedFile.FileName}";
        var fs = System.IO.File.Create(path);
        fs.Write(uploadedFile.FileContent, 0, uploadedFile.FileContent.Length);
        fs.Close(); 
        
        return Ok();
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
