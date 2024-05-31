using SabeNaoSabe.RazorClassLibrary.Models;


namespace SabeNaoSabe.RazorClassLibrary.Services
{
    public interface IQuestionarioService
    {
        Task<List<Questionario>> GetQuestionarios();
        //Task AddQuestionario(Questionario questionario);
        //Task EditQuestionario(Questionario questionario);
        //Task DeleteQuestionario(int id);
    }
}
