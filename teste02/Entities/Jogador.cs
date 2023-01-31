using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teste02.Entities
{
    public class Jogador
    {
        //atributos

        public string Nome { get; set; }
        public string Senha { get; set; }
        public int Partidas { get; set; }
        public int Pontos { get; set; }
        public int Vitorias { get; set; }
        public int Derrotas { get; set; }
        public int Empates { get; set; }
        public Jogador(string nome,string senha)
        { 
            Nome = nome;
            Senha = senha;
            Partidas = 0;
            Pontos = 0;           
            Vitorias = 0;
            Derrotas = 0;
            Empates = 0;

        }


   

    }
}
