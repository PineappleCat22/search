using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

class Program
{
    static void Main(string[] args)
    {
        string json = File.ReadAllText("testdata.txt");

        JObject obj = JObject.Parse(json);
        JArray organicResults = (JArray)obj["organic_results"];

        foreach (var result in organicResults)
        {
            string title = result["title"]?.ToString();
            string snippet = result["snippet"]?.ToString();

            Console.WriteLine($"Title: {title}");
            Console.WriteLine($"Snippet: {snippet}");
            Console.WriteLine();

            Console.WriteLine("data exists now");
        }
    }
}