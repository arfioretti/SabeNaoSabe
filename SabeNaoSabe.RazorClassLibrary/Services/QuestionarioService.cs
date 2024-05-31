using SabeNaoSabe.RazorClassLibrary.Models;

namespace SabeNaoSabe.RazorClassLibrary.Services
{
    public class QuestionarioService : IQuestionarioService
    {
        private string _baseUrl = "https://localhost:7256";
        public async Task<List<Questionario>> GetQuestionarios()
        {
            List<Questionario> questionarios = new List<Questionario>();
            using (var client = new HttpClient())
            {
                string url = $"{_baseUrl}/api/questionario";
                var response = await client.GetAsync(url);
                int i = 0;
            }
            
            return questionarios;
        }
       
        //public async Task<Questionario> GetByIdAsync(int id)
        //{
        //}
        //public async Task AddQuestionario(Questionario questionario)
        //{
        //    return questionario;
        //}
        //public async Task EditQuestionario(Questionario questionario)
        //{
        //    await _httpClient.PostAsJsonAsync("/api/Questionario", questionario);
        //}
        //public async Task DeleteQuestionario(int id)
        //{
        //}

        //public Task AddQuestionario(Questionario questionario)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task EditQuestionario(Questionario questionario)
        //{
        //}
    }
}
