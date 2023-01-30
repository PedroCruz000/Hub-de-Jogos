using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using teste02.Repositorio;

namespace teste02
{
    internal class Menu
    {
        public static void Abertura()
        {

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n\tBem-vindo(a) Hub de jogos.");
            Console.Write("\n\tPressione qualquer tecla para acessar ao menu ");
            Console.ReadKey();
            Console.ResetColor();
        }

        public static string PegarNome()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("\n\t Digite Seu Nome:");
            Console.ResetColor();
            string nome = Console.ReadLine();           
            return nome;
        }

        public static void ShowMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            Console.WriteLine("\n\n\t 1 - Cadastrar jogador");
            Console.WriteLine("\n\t 2 - Deletar jogador");
            Console.WriteLine("\n\t 3 - Ranking dos jogadores");
            Console.WriteLine("\n\t 4 - Iniciar jogo da velha");
            Console.WriteLine("\n\t 5 - Iniciar Batalha Naval");
            Console.WriteLine("\n\t 0 - Sair");

            Console.ResetColor();
        }

        public static string ExisteJogador(string nome)
        {
            int escolha = 10;

            if(Json.jogadores.Any(player => player.Nome == nome))
            {
                do
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\n\n\t ESTE JOGADOR JA EXITE! ");
                    Console.ForegroundColor= ConsoleColor.DarkYellow;
                    Console.WriteLine("\n\n\t 1 - Tentar novamente");
                    Console.WriteLine("\n\t 0 - Sair");
                    Console.ResetColor();


                    try
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("\n\t Digite uma opção:");
                        Console.ResetColor();
                        escolha = int.Parse(Console.ReadLine());
                        if (escolha < 0 || escolha > 5)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("\n\t Opção inválida, tente novamente!");
                            Console.WriteLine("\n\t Precione uma tecla para tentar novamente!");
                            Console.ReadKey();
                            Console.ResetColor();

                        }
                    }
                    catch
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("\n\t Opção inválida, tente novamente!");
                        Console.WriteLine("\n\t Precione uma tecla para tentar novamente!");
                        Console.ReadKey();
                        Console.ResetColor();

                    }

                    switch (escolha)
                    {
                        case 1:
                            Json.Adicionar();
                            escolha = 0;
                            break;

                        case 0:
                            
                            break;
                    }

                } while (escolha != 0);
                
            }
            return nome;




            /*
            while (Json.jogadores.Any(player => player.Nome == nome))
            {
                Console.WriteLine("\n\tJogador já cadastrado. Tente novamente.");

                
                nome = PegarNome();
            }
            return nome;*/
        }
        public static string NaoExisteJogador(string nome)
        {
            int escolha = 10;

            if (!Json.jogadores.Any(player => player.Nome == nome))
            {
                do
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\n\n\t ESTE JOGADOR NÃO EXITE! ");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("\n\n\t 1 - Tentar novamente");
                    Console.WriteLine("\n\t 0 - Sair");
                    Console.ResetColor();



                    try
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("\n\t Digite uma opção:");
                        Console.ResetColor();
                        escolha = int.Parse(Console.ReadLine());
                        if (escolha < 0 || escolha > 5)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("\n\t Opção inválida, tente novamente!");
                            Console.WriteLine("\n\t Precione uma tecla para tentar novamente!");
                            Console.ReadKey();
                            Console.ResetColor();

                        }
                    }
                    catch
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("\n\t Opção inválida, tente novamente!");
                        Console.WriteLine("\n\t Precione uma tecla para tentar novamente!");
                        Console.ReadKey();
                        Console.ResetColor();

                    }

                    switch (escolha)
                    {
                        case 1:
                            Console.Write("\n\t Digite um nome valido:");
                            nome = Console.ReadLine();
                            NaoExisteJogador(nome);
                            escolha = 0;
                            break;

                        case 0:
                            
                            break;
                    }

                } while (escolha != 0);

            }
        
            return nome;
        }

       

        public static string NaoExisteJogadorParaDeletar(string nome)
        {
            int escolha = 10;

            if (!Json.jogadores.Any(player => player.Nome == nome))
            {
                do
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\n\n\t ESTE JOGADOR NÃO EXITE! ");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("\n\n\t 1 - Tentar novamente");
                    Console.WriteLine("\n\t 0 - Sair");
                    Console.ResetColor();



                    try
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("\n\t Digite uma opção:");
                        Console.ResetColor();
                        escolha = int.Parse(Console.ReadLine());
                        if (escolha < 0 || escolha > 5)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("\n\t Opção inválida, tente novamente!");
                            Console.WriteLine("\n\t Precione uma tecla para tentar novamente!");
                            Console.ReadKey();
                            Console.ResetColor();

                        }
                    }
                    catch
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("\n\t Opção inválida, tente novamente!");
                        Console.WriteLine("\n\t Precione uma tecla para tentar novamente!");
                        Console.ReadKey();
                        Console.ResetColor();

                    }

                    switch (escolha)
                    {
                        case 1:
                            Json.Remover();
                            escolha = 0;
                            break;

                        case 0:

                            break;
                    }

                } while (escolha != 0);

            }
            return nome;

        }



        public static void BemVindoBatalhaNaval()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("===========================================================");            
            Console.WriteLine("\n\tBem-vindo(a) ao Batalha Naval.");
            Console.WriteLine("\n\tPressione qualquer tecla para acessar ao menu \t\n");
            Console.WriteLine("===========================================================");
            Console.ReadKey();
            Console.ResetColor();
        }

        public static void LegendaBatalhaNaval()
        {
            Console.WriteLine("");
        }
    }
}
