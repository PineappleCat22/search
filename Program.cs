using Newtonsoft.Json.Linq;
using SerpApi;
using System.Collections;


class Program
{
    static void Main(string[] args)
    {
        Hashtable ht = new Hashtable();
        ht.Add("engine", "google_light");

        Console.WriteLine("ENTER QUERY");
        ht.Add("q", Console.ReadLine());

        Console.WriteLine("PASTE API KEY REMOVE THIS"); //better than hardcoding it
        GoogleSearch search = new GoogleSearch(ht, Console.ReadLine());

        JObject obj = search.GetJson();
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
            if (resultCounter == 10) //this is terrible and breaks in some contexts
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
            if (resultCounter == 4) //this also breaks in some contexts
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