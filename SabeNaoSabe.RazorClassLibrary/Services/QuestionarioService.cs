using SabeNaoSabe.RazorClassLibrary.Data;
using SabeNaoSabe.RazorClassLibrary.ViewModel;

namespace SabeNaoSabe.RazorClassLibrary.Services
{
    public  class QuestionarioService : IQuestionarioService
    {
        public readonly List<Questionario> questionariosList;

        public QuestionarioService()
        {
            questionariosList = new List<Questionario>()
            {
                new Questionario() { Id = 1, Name = "q1", Description = "primeiro questionario" },
                new Questionario() { Id = 2, Name = "q2", Description = "segundo questionario" }
            };
        }

        public async Task<List<Questionario>> GetAllAsync()
        {
            return questionariosList;
        }

        public async Task<Questionario> GetByIdAsync(int id)
        {
            return questionariosList.Where(u => u.Id == id).FirstOrDefault();
        }
        public async Task AddQuestionario(QuestionarioViewModel questionarioViewModel)
        {
            var IdMax = questionariosList.Max(u => u.Id);
            Questionario questionario = new Questionario();
            questionario.Id = IdMax+1;
            questionario.Name = questionarioViewModel.Name;
            questionario.Description = questionarioViewModel.Description;
            questionariosList.Add(questionario);
        }
    }   
}
