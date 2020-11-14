using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace TesteHttpClient
{
    class Program
    {

        static async Task Main(string[] args)
        {
            var client = new HttpClient();

            Console.Write("Digigte o login do usuario: ");
            var userName = Console.ReadLine();

            client.DefaultRequestHeaders.Add("User-Agent", "Other");
            var response = await client.GetStringAsync("https://api.github.com/users/" + userName);
            var posts = JsonConvert.DeserializeObject<Post>(response);

            Console.WriteLine();
            Console.WriteLine($"Login: {posts.Login}");
            Console.WriteLine($"Id: {posts.Id}");
            Console.WriteLine($"Nome: {posts.Name}");
            Console.WriteLine($"Repositórios Publicados: {posts.Public_Repos}");
            Console.WriteLine($"Numero de Seguidores: {posts.Followers}");
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine();
        }
    }   
}
