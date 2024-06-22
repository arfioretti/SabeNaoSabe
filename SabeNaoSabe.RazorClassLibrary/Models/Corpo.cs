using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabeNaoSabe.RazorClassLibrary.Models
{
    public class Corpo
    {
        public string Pergunta { get; set; }
        public List<Opcao> Opcoes { get; set; }
        public string Resposta { get; set; }
        public string Explicacao { get; set; }
    }
    public class Opcao
    {
        public string Descricao { get; set; }
    }
}
