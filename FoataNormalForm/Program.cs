using FoataNormalForm;

class Program
{
    public static void Main(string[] args)
    {
        var fileName = args.Length == 2 ? args[1] : "C:\\Users\\mistr\\Desktop\\studyja\\FoataNormalForm\\FoataNormalForm\\case1.txt";

        InputParser.ParseFile(fileName);

        Console.WriteLine("Dupa");
    }
}