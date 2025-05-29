using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

class Program
{
    static void Main(string[] args)
    {
        //query the api here
        string json = File.ReadAllText(@"C:\Users\waylo\source\repos\PineappleCat22\search\testdata2.txt");

        JObject obj = JObject.Parse(json);
        JArray organicResults = (JArray)obj["organic_results"];
        JArray relatedQuestions = (JArray)obj["related_questions"];

        int resultCounter = 0;
        foreach (var result in organicResults)
        {
            resultCounter++;
            Console.WriteLine();
            Console.WriteLine("Result #" + resultCounter);
            Console.WriteLine($"Title: {result["title"]?.ToString()}");
            Console.WriteLine($"Snippet: {result["snippet"]?.ToString()}");
            Console.WriteLine();
            Console.WriteLine("Press any key to display the next result, or press q to quit.");
            if (Console.ReadKey().Key == ConsoleKey.Q)
            {
                System.Environment.Exit(0);
            }
            if (resultCounter == 10)
            {
                Console.WriteLine("That was the last result. Lets hope what you're looking for is in the Related Questions.");
            }
        }
        resultCounter = 0;
        foreach (var question in relatedQuestions)
        {
            resultCounter++;
            Console.WriteLine();
            Console.WriteLine("Result #" + resultCounter);
            Console.WriteLine($"Snippet: {question["snippet"]?.ToString()}");
            Console.WriteLine();
            if (resultCounter == 4)
            {
                Console.WriteLine("That was the last result. Exiting...");
                System.Environment.Exit(0);
            }
            Console.WriteLine("Press any key to display the next result, or press q to quit.");
            if (Console.ReadKey().Key == ConsoleKey.Q)
            {
                System.Environment.Exit(0);
            }
        }
    }
}