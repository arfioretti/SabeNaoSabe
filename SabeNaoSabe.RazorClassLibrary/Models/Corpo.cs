using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabeNaoSabe.RazorClassLibrary.Models
{
    public class Corpo
    {
        public int Id { get; set; }
        public int Tipo { get; set; }
        public string Pergunta { get; set; }
        public List<Opcao> Opcoes { get; set; }
        public int Resposta { get; set; }
        public List<int> Gabaritos { get; set; }
        public string Explicacao { get; set; }
        public string Resultado { get; set; }
        public string ImagemSecundaria { get; set; }
    }
    public class Opcao
    { 
        public int Id { get; set; }
        public bool Checked { get; set; }
        public string Descricao { get; set; }
    }
}
