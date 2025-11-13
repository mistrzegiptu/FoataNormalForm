using FoataNormalForm;

class Program
{
    public static void Main(string[] args)
    {
        var fileName = args.Length == 1 ? args[0] : "case0.txt";

        if (!File.Exists(fileName))
            fileName = @".\case0.txt";

        var foataInput = InputParser.ParseFile(fileName);

        var relations = new Relations();
        relations.BuildSets(foataInput.Transactions);
        relations.PrintDependenceSet();
        relations.PrintIndependenceSet();

        var mazurkiewiczGraph = new MazurkiewiczGraph();
        mazurkiewiczGraph.BuildGraph(foataInput.Word, relations);

        var graphInDotFormat = mazurkiewiczGraph.ToDotFormat();

        Console.WriteLine(graphInDotFormat);
        Console.WriteLine(mazurkiewiczGraph.ToFoataNormalForm());

        File.WriteAllText("outputGraphDot.txt", graphInDotFormat);
    }
}