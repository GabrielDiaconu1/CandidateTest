/*
 *Author: Gabriel Diaconu
 *This C# code sends a POST request to a specified URL, including JSON data containing information such as a GitHub username, email, and a random number with its reason. It then prints out whether the request was successful along with the response content or an error message if the request failed.
 *
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
namespace SendPostRequestNew
{
    internal class Program
    {
       
        public class post
        {
            public string github_username { get; set; }
            public string short_greeting { get; set; }
            public string email { get; set; }
            public string name { get; set; }
            public RandomNumber random_number { get; set; }
            public bool is_test { get; set; }
        }

        public class RandomNumber
        {
            public int number { get; set; }
            public string reason { get; set; }
        }

    

    static void Main(string[] args)
        {
            string url = "https://flow.zoho.com/663067151/flow/webhook/incoming?zapikey=1001.72d0b18a4316a1acc8f0de7fa7dbdf74.4f792bf21ebf81a4d04112d94177a2a1&isdebug=false";

            var client = new RestClient(url);
            var request = new RestRequest();
            var body = new post
            {
                github_username = "GabrielDiaconu1",
                short_greeting = "Hello World",
                email = "gabriel.diaconu@mohawkcollege.ca",
                name = "Gabriel Diaconu",
                
                random_number = new RandomNumber
                {
                    number = new Random().Next(10, 1000),
                    reason = "Random number generated for testing purposes"
                },
                is_test = false
            };

            request.AddJsonBody(body);
            var response = client.Post(request);
            // Check if the request was successful
            if (response.IsSuccessful)
            {
                Console.WriteLine("Request succeeded!");
                Console.WriteLine("Response content:");
                Console.WriteLine(response.Content);
            }
            else
            {
                Console.WriteLine("Request failed!");
                Console.WriteLine("Error message:");
                Console.WriteLine(response.ErrorMessage);
            }

            Console.ReadLine();

        }



    }
}
