using SabeNaoSabe.RazorClassLibrary.Models;


namespace SabeNaoSabe.RazorClassLibrary.Services
{
    public interface IQuestionarioService
    {
        Task<List<QuestionarioModel>> GetQuestionarios(string baseUrl);
        Task<QuestionarioModel> GetQuestionarioById(int id);
        Task<bool> AddQuestionario(QuestionarioModel questionarioModel);
        Task<bool> AddUploadedFile(UploadedFile uploadedFile);
        Task<bool> EditQuestionario(QuestionarioModel questionarioModel);
        Task<bool> DeleteQuestionario(QuestionarioModel questionarioModel);
    }
}
