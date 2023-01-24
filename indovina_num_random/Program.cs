namespace indovina_num_random
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int range1;
            int range2;
            int count = 0;
            int ftry;


            Random r = new Random();

            ChiediNum("Inserire il valore minimo", out range1);
            ChiediNum("Inserire il valore massimo", out range2);

            Ordina(ref range1, ref range2);

            int n = r.Next(range1, range2);

            Console.WriteLine($" Il numero da indovinare sarà tra {range1} e {range2}");
            Console.WriteLine(n);

            ChiediNum("Prova a indovinare", out ftry);

            do
            {
                if (ftry < n)
                {
                    Console.WriteLine("Prova con un numero più grande");
                }
                else if (ftry > n)
                {
                    Console.WriteLine("Prova con un numero più piccolo");
                }

                ChiediNum("Prova di nuovo", out ftry);
                count++;

            } while (ftry != n);


            Console.WriteLine($"Hai indovinato in {count + 1} tentativi!! Il numero da indovinare era {n}");
        }

        static void ChiediNum(string richiesta, out int n)
        {
            do
            {
                Console.WriteLine($"{richiesta}: ");

            } while (!int.TryParse(Console.ReadLine(), out n));
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