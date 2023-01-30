
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using teste02.Entities;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;
using Newtonsoft.Json;

namespace teste02.Repositorio
{
    public class Json
    {
        
        
        private static string path = "Dados.json";

        public static List<Jogador> jogadores = Desserializar();
        public Json()
        {
            if (!File.Exists(path)) File.Create(path).Close();
        }




        public static void Adicionar()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n\t Cadastrar novo Jogador. ");
            Console.ResetColor();

            //pedir para o usuario escrever o nome 
            string nome = Menu.PegarNome();

            //validar o usuario e retornar o nome valido 
            nome = Menu.ExisteJogador(nome);

            if (Json.jogadores.Any(player => player.Nome == nome))
            {
                return;
            }
           

            //criar um jogador utulizando a classe e o construtor 
            Jogador jogador = new Jogador(nome);

            //dicionar um jogador 
            jogadores.Add(jogador);

            //enviar para o json
            Serializar();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n\t Jogador cadastrado com sucesso.");
            Console.WriteLine("\n\t Pressione uma tecla para voltar ao menu");
            Console.ReadKey();

            Console.ResetColor();
            
        }
        public static void Remover()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n\t Deletar Jogador.");
            Console.ResetColor();
            string nome = Menu.PegarNome();
            nome = Menu.NaoExisteJogadorParaDeletar(nome);

            if (!Json.jogadores.Any(player => player.Nome == nome))
            {
                return;
            }

            jogadores.RemoveAll(player => player.Nome == nome);
            Serializar();

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\n\t Jogador deletado com sucesso!");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n\t Pressione uma tecla para voltar ao menu");
            Console.ReadKey();
            Console.ResetColor();
            return;

        }

       /* public static void Atualizar()
        {
            Console.Clear();
            Console.ForegroundColor= ConsoleColor.DarkYellow;

        }*/


        public static void Serializar()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(sw, jogadores);
                }
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n\t{e.Message}");
                Console.ResetColor();
            }
        }

        public static List<Jogador> Desserializar()
        {
            List<Jogador> jogadores = new List<Jogador>();
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string jsonString = sr.ReadToEnd();
                    jogadores = JsonConvert.DeserializeObject<List<Jogador>>(jsonString);
                }
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n\t{e.Message}");
                Console.ResetColor();
            }
            return jogadores;
        }

 
    }
}
