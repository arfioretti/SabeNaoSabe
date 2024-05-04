using SabeNaoSabe.RazorClassLibrary.Data;
using SabeNaoSabe.RazorClassLibrary.ViewModel;


namespace SabeNaoSabe.RazorClassLibrary.Services
{
    public interface IQuestionarioService
    { 
        Task<List<Questionario>> GetAllAsync();
        Task<Questionario> GetByIdAsync(int id);
        Task AddQuestionario(QuestionarioViewModel questionarioViewModel);
        Task EditQuestionario(QuestionarioViewModel questionarioViewModel);
        Task DeleteQuestionario(int id);
    }
}
