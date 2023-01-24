namespace Fibonacci
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int indice;
            int[] fibonacci;

            do
            {
                Console.WriteLine("Quanti numeri della sequenza di Fibonacci vuoi vedere?");

            } while (!int.TryParse(Console.ReadLine(), out indice));

            fibonacci = new int[indice];

            if (indice == 1)
            {
                fibonacci[0] = 1;
                
            } else if (indice == 2) 
            {
                fibonacci[0] = 1;
                fibonacci[1] = 1;
            } else if (indice > 3) 
            {
                for (int i = 2; i < indice; i++)
                {
                    fibonacci[0] = 1;
                    fibonacci[1] = 1;

                    fibonacci[i] = fibonacci[i - 1] + fibonacci[i - 2];
                    Console.WriteLine(fibonacci[i]);
                }
            }

            

        }
    }
}