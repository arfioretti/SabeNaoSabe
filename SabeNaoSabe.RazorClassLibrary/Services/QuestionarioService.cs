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
            var Questionario = questionariosList.Where(u => u.Id == id).FirstOrDefault();
            return Questionario;
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

        public  async Task EditQuestionario(QuestionarioViewModel questionarioViewModel)
        {
            foreach(var q in questionariosList)
            {
                if(q.Id == questionarioViewModel.Id)
                {
                    q.Name = questionarioViewModel.Name;
                    q.Description = questionarioViewModel.Description;
                }
            }
        }

        public async Task DeleteQuestionario(int id)
        {
            var itemToRemove = questionariosList.SingleOrDefault(r => r.Id == id);
            if (itemToRemove != null)
                questionariosList.Remove(itemToRemove);
        }
    }
}
