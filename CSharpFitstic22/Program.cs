using Es3B;

namespace CSharpFitstic22
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Che esrcizio vuoi caricare? Inserire numero: ");
            Console.WriteLine("1. Esercizio 3B");

            string? temp = Console.ReadLine();
            int.TryParse(temp, out int e);

            if (e == 1)
            {
                new Exercise().Execute();
            }


        }
    }
}