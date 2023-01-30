using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using teste02.Entities;
using teste02.Repositorio;

namespace teste02.Services
{
    public class Jogar
    {
        private static string Jogador1;
        private static string Jogador2;

        private static int Tamanho;
        private static List<string> posicoes = new List<string>() ;


        public static void SelecionarJogadores()
        {

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n\t Selecione os jogadores:");
            Console.Write("\n\tJogador 1: ");
            Console.ResetColor();

            //pedir para o usuario escolher o jogador pelo nome:
            string jogador1 = Console.ReadLine();

            //validar se o jogador existe 
            jogador1 = Menu.NaoExisteJogador(jogador1);

            //doble check
           if (!Json.jogadores.Any(player => player.Nome == jogador1))
            {
                return;
            }
            // adicionar o jogador 1 ao nome do jogador 
            Jogador1 = jogador1;

            //repetir o processo para o jogador 02 
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("\n\tJogador 2: ");
            Console.ResetColor();
            string jogador2 = Console.ReadLine();
            jogador2 = Menu.NaoExisteJogador(jogador2);

            //doble check
            if (!Json.jogadores.Any(player => player.Nome == jogador2))
            {
                return;
            }

            Jogador2 = jogador2;
        }

        public static string[,] TabuleiroJogoDaVelha()
        {         
            Tamanho = 3;        
            string[,] tabuleiro = Tabuleiro.GerarTabuleiro(Tamanho);
            return tabuleiro;
        }
        public static string[,] TabuleiroBatalhaNaval()
        {
            Tamanho = 10;
            string[,] tabuleiro = Tabuleiro.GerarTabuleiro(Tamanho);
            return tabuleiro;
        }



        //jogo da velha 
        public static void Jogo()

        {
            //seleção de jogadores 

            SelecionarJogadores();

            //se não for ecolhido nenhum jogador o jogo encerra! 
            if (Jogador1 == null)
            {
                return;
            }
            if(Jogador2== null)
            {
                return;
            }

            //funcionamento do jogo 

            try
            {
                string[,] tabuleiro = TabuleiroJogoDaVelha();
                string posicao;
                int vez = 1;
                while(true)
                {
                    Tabuleiro.MostrarTabuleiro(tabuleiro, Tamanho);
                    if (vez % 2 != 0)
                    {
                        posicao = PegarPosicao(Jogador1, "X");
                        Tabuleiro.AlterarTabuleiro(posicao, Tamanho, tabuleiro, "X");
                        if (Tabuleiro.VerificarTabuleiro(posicao, Tamanho, tabuleiro, "X"))
                        {
                            Tabuleiro.MostrarTabuleiro(tabuleiro, Tamanho);
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("\n\tVencedor:");
                            Console.ResetColor();

                            Console.WriteLine($" {Jogador1}");
                            Console.Write($"\t{Jogador1}");
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine(" recebe +3 pontos");
                            Console.ResetColor();

                            Console.Write($"\t{Jogador2}");
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine(" não recebe pontos");
                            Console.ResetColor();

                            Json.jogadores.Find(player => player.Nome == Jogador1).Partidas += 1;
                            Json.jogadores.Find(player => player.Nome == Jogador2).Partidas += 1;
                            Json.jogadores.Find(player => player.Nome == Jogador1).Pontos += 3;
                            Json.jogadores.Find(player => player.Nome == Jogador1).Vitorias += 1;
                            Json.jogadores.Find(player => player.Nome == Jogador2).Derrotas += 1;
                            //Ranking.AtualizarRanking();
                            Json.Serializar();
                            posicoes.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("\n\t Pressione uma tecla para voltar ao menu");
                            Console.ReadKey();
                            Console.ResetColor();
                            break;
                        }
                        vez++;
                    }
                    else
                    {
                        posicao = PegarPosicao(Jogador2, "O");
                        Tabuleiro.AlterarTabuleiro(posicao, Tamanho, tabuleiro, "O");
                        if (Tabuleiro.VerificarTabuleiro(posicao, Tamanho, tabuleiro, "O"))
                        {
                            Tabuleiro.MostrarTabuleiro(tabuleiro, Tamanho);
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("\n\tVencedor:");
                            Console.ResetColor();
                            Console.WriteLine($" {Jogador2}");
                            Console.Write($"\t{Jogador2}");
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine(" recebe +3 pontos");
                            Console.ResetColor();
                            Console.Write($"\t{Jogador1}");
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine(" não recebe pontos");
                            Console.ResetColor();
                            Json.jogadores.Find(player => player.Nome == Jogador1).Partidas += 1;
                            Json.jogadores.Find(player => player.Nome == Jogador2).Partidas += 1;
                            Json.jogadores.Find(player => player.Nome == Jogador2).Pontos += 3;
                            Json.jogadores.Find(player => player.Nome == Jogador2).Vitorias += 1;
                            Json.jogadores.Find(player => player.Nome == Jogador1).Derrotas += 1;
                            //Ranking.AtualizarRanking();
                            Json.Serializar();
                            posicoes.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("\n\t Pressione uma tecla para voltar ao menu");
                            Console.ReadKey();
                            Console.ResetColor();
                            break;
                        }
                        vez++;


                    }
                    if(Tabuleiro.VerificarVelha(posicao, Tamanho, tabuleiro))
                    {

                        Tabuleiro.MostrarTabuleiro(tabuleiro, Tamanho);
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("\n\tEmpate: Deu velha.");
                        Console.ResetColor();
                        Console.Write($"\t{Jogador1}");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine(" recebe +1 ponto");
                        Console.ResetColor();
                        Console.Write($"\t{Jogador2}");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine(" recebe +1 ponto");
                        Console.ResetColor();
                        Json.jogadores.Find(player => player.Nome == Jogador1).Partidas += 1;
                        Json.jogadores.Find(player => player.Nome == Jogador2).Partidas += 1;
                        Json.jogadores.Find(player => player.Nome == Jogador1).Pontos += 1;
                        Json.jogadores.Find(player => player.Nome == Jogador2).Pontos += 1;
                        Json.jogadores.Find(player => player.Nome == Jogador1).Empates += 1;
                        Json.jogadores.Find(player => player.Nome == Jogador2).Empates += 1;
                        //Ranking.AtualizarRanking();
                        Json.Serializar();
                        posicoes.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("\n\t Pressione uma tecla para voltar ao menu");
                        Console.ReadKey();
                        Console.ResetColor();
                        break;
                    }

                 


                }

            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\n\t O tamanho deve ser um número inteiro.");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\n\t Pressione uma tecla para voltar ao menu");
                Console.ReadKey();
                Console.ResetColor();
            }


        }
        public static string PegarPosicao(string jogador, string valor)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($"\n\t Vez de");
            Console.ResetColor();
            Console.Write($" {jogador}");
            if (valor == "X")
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($" ({valor})");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($" ({valor})");
                Console.ResetColor();
            }
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("\n\tDigite a posição: ");
            Console.ResetColor();
            string posicao = Console.ReadLine();
            int number;
            while (posicoes.Contains(posicao) || !int.TryParse(posicao, out number) || number < 1 || number > Tamanho * Tamanho)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\n\tPosição incorreta. Digite a posição novamente: ");
                Console.ResetColor();
                posicao = Console.ReadLine();
            }
            posicoes.Add(posicao);
            return posicao;
        }


        public static void BatalhaNaval()
        {

            //menu de boas vindas 
            Menu.BemVindoBatalhaNaval();

            //seleção de jogadores 
            SelecionarJogadores();

            //se não for ecolhido nenhum jogador o jogo encerra! 
            if (Jogador1 == null)
            {
                return;
            }
            if (Jogador2 == null)
            {
                return;
            }

            //selecionar tamanho do tabuleiro 10x10
            string[,] tabuleiro = TabuleiroBatalhaNaval();


            string posicao;
            int vez = 1;

            // repetição enquando não houver vitoria 

            while (true)
            {
                //mostrar o tabuleiro 

                Tabuleiro.MostrarTabuleiro(tabuleiro, Tamanho);

                //vez do jogador 1 
                if (vez % 2 != 0)
                {
                    posicao = PegarPosicao(Jogador1, "X");
                    Tabuleiro.AlterarTabuleiro(posicao, Tamanho, tabuleiro, "X");

                    //verificar vitoria 
                    vez++;
                }

                //vez do jogador 2 

                else
                {
                    posicao = PegarPosicao(Jogador2, "O");
                    Tabuleiro.AlterarTabuleiro(posicao, Tamanho, tabuleiro, "O");

                    //verificar vitoria 

                    vez++;
                }

            }

                
        }

    }
}
