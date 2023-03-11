// See https://aka.ms/new-console-template for more information
using System.Globalization;
using WhatsThePower.Repo;
string todaysTime = $"{DateTime.Now.Date.ToString("yyyy/MM-dd",CultureInfo.InvariantCulture)}_SE3.json";
ApiRepo apiService = new ApiRepo();

var prices = await apiService.GetData(todaysTime);
foreach (var price in prices)
    Console.WriteLine($"Pris: {price.SEK_Per_kWh} kr : Mellan {price.StartTime} - {price.EndTime}\n\n");