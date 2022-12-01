namespace Es3B
{
    public class Exercise
    {
        public void Execute()
        {
            string tmp;
            bool ok;


            Console.Write("Inserisci un numero: ");
            tmp = Console.ReadLine();
            ok = int.TryParse(tmp, out int numero);

            if (numero % 2 == 0)
            {
                numero--;
            }

            while (numero > 0)
            {
                Console.WriteLine(numero);
                numero = numero - 2;
            }
        }
    }
}