using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using teste02.Entities;
using teste02.Repositorio;

namespace teste02.Services
{
    public class Ranking
    {
        private static List<Jogador> ranking = Json.jogadores.OrderBy(jogador => jogador.Pontos).ToList();
        public static void AtualizarRanking()
        {
            ranking = Json.jogadores.OrderBy(jogador => jogador.Pontos).ThenBy(jogador => jogador.Vitorias).ThenByDescending(jogador => jogador.Derrotas).ToList();
        }

        public static void MostrarRanking()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n\tRanking de Jogadores");
            Console.ResetColor();
            AtualizarRanking();
            for (int i = ranking.Count - 1, j = 1; i >= 0; i--, j++)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write($"\n\t{j}º");
                Console.ResetColor();
                Console.WriteLine($" {ranking[i].Nome}");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write($"\tPontos:");
                Console.ResetColor();
                Console.WriteLine($" {ranking[i].Pontos}");
            }
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n\t Pressione uma tecla para voltar ao menu");
            Console.ReadKey();
            Console.ResetColor();
            
        }
    }
}
