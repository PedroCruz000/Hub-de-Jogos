using teste02;
using teste02.Repositorio;
using teste02.Services;

namespace Teste02
{
    public class Program
    {
        public static void Main(string[] args)
        {

            Menu.Abertura();

            // Json data = new Json();

            

            int option = 10;

            do
            {
                Menu.ShowMenu();

                Json data = new Json();


                try
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("\n\tDigite uma opção:");
                    Console.ResetColor();
                    option = int.Parse(Console.ReadLine());
                    if (option < 0 || option > 5)
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
                


                switch (option)
                {
                    case 0:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("\n\tEncerrando Programa...");
                        Console.ResetColor();
                        break;
                        
                    case 1:
                        Json.Adicionar();
                        break;
                    case 2:
                        Json.Remover();
                        break;
                    case 3:
                        Ranking.MostrarRanking();
                        break;
                    case 4:
                        Jogar.Jogo();
                        break;
                    case 5:
                        Jogar.BatalhaNaval();
                        break;
                        


                }

            }while(option != 0);
        }
    }
}