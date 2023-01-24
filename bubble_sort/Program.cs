namespace ordina_array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numeri;
            bool ordered;

            numeri = ChiediNumRandom();

            Console.WriteLine($"L'array creato è: {string.Join(", ", numeri)}");

            do
            {
                ordered = true;

                for (int i = 0; i < numeri.Length - 1; i++)
                {
                    if (Ordina(ref numeri[i], ref numeri[i + 1]))
                    {
                        ordered = false;

                    }
                }
            } while (!ordered);

            Console.WriteLine($"L'array ordinato è: {string.Join(", ", numeri)}");

        }

        static void ChiediNum(string richiesta, ref int n)
        {
            do
            {
                Console.WriteLine($"Inserisci {richiesta}: ");

            } while (!int.TryParse(Console.ReadLine(), out n));
        }

        static int[] ChiediNumRandom()
        {
            int indice = 0;
            Random r = new Random();

            ChiediNum("il totale di numeri da inserire", ref indice);
            int[] array = new int[indice];

            for (int i = 0; i < indice; i++)
            {
                array[i] = r.Next(0, 100);
            }
            return array;
        }

        static bool Ordina(ref int num, ref int num2)
        {
            bool ok = false;

            if (num >= num2)
            {
                int temp = num;
                num = num2;
                num2 = temp;
                ok = true;
            }

            return ok;
        }
    }
}