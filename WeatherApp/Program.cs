using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace WeatherApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //5f9d424a60c4322fda510165e6461176

            var client = new HttpClient();

            Console.WriteLine("Enter your API Key: ");
            var api_Key = Console.ReadLine();
            
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Please Enter the city name: ");
                var city_name = Console.ReadLine();
                var weatherURL = $"http://api.openweathermap.org/data/2.5/weather?q={city_name}&appid={api_Key}";
               
                var response = client.GetStringAsync(weatherURL).Result;

                var formattedResponse = JObject.Parse(response).GetValue("main").ToString();
                Console.WriteLine(formattedResponse);
                Console.WriteLine();
                Console.WriteLine("Would you like to choose a different city");
                var userInput = Console.ReadLine();
                Console.WriteLine();
                if (userInput.ToLower() == "no")
                {
                    break; 
                }

            }

        }
    }
}
