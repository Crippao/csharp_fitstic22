using Es3B;

namespace CSharpFitstic22
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1 per selezionare l'esercizio 3B");


            Console.Write("Che esrcizio vuoi caricare? Inserire numero: ");
           

            string? temp = Console.ReadLine();
            int.TryParse(temp, out int e);

            switch (e)
            {
                case 1:
                    new Exercise().Execute();
                    break;
            }
        }
    }
}