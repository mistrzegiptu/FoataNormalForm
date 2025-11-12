using FoataNormalForm;

class Program
{
    public static void Main(string[] args)
    {
        var fileName = args.Length == 2 ? args[1] : @".\case1.txt";

        var foataInput = InputParser.ParseFile(fileName);

        var relations = new Relations();
        relations.BuildSets(foataInput.Transactions);
        relations.PrintDependenceSet();
        relations.PrintIndependenceSet();

        var mazurkiewiczGraph = new MazurkiewiczGraph();
        mazurkiewiczGraph.BuildGraph(foataInput.Word, relations);

        Console.WriteLine(mazurkiewiczGraph.ToDotFormat());
        Console.WriteLine(mazurkiewiczGraph.ToFoataNormalForm());
    }
}