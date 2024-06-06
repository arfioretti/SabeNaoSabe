using SabeNaoSabe.RazorClassLibrary.Models;


namespace SabeNaoSabe.RazorClassLibrary.Services
{
    public interface IQuestionarioService
    {
        Task<List<QuestionarioModel>> GetQuestionarios();
        Task<bool> AddQuestionario(QuestionarioModel questionarioModel);
        Task<bool> EditQuestionario(QuestionarioModel questionarioModel);
        Task<bool> DeleteQuestionario(QuestionarioModel questionarioModel);
    }
}
