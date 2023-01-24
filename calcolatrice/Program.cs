using System.Runtime.CompilerServices;

namespace calcolatrice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //somma + - sottrazione - - moltiplicazione * - divisione /

            string? simbolo;
            double somma;
            double sottrazione;
            double moltiplicazione;
            double divisione;
            double x1;
            double x2;

            Console.WriteLine("CALCOLATRICE");
            Console.WriteLine("+ --> addizione");
            Console.WriteLine("- --> sottrazione");
            Console.WriteLine("* --> moltiplicazione");
            Console.WriteLine("/ --> divisione");
            Console.WriteLine("Inserisci il simbolo corrispondente all'operazione che vuoi eseguire: ");
            simbolo = Console.ReadLine();

            switch (simbolo)
            {
                case "+":
                    Console.WriteLine("Si è scelto di effettuare un'addizione");
                    Somma();
                    
                    break;


                case "-":
                    Console.WriteLine("Si è scelto di effettuare una sottrazione");
                    Sottrazione();                    
                    break;


                case "*":
                    Console.WriteLine("Si è scelto di effettuare una moltiplicazione");
                    Moltiplicazione();                    
                    break;


                case "/":
                    Console.WriteLine("Si è scelto di effettuare una divisione");
                    Divisione();
                    break;


                case "eq2g":
                    Console.WriteLine("Si è scelto di risolvere una equazione di secondo grado");
                    Soluzione2g();
                    break;


                default:
                    Console.WriteLine("Il valore inserito non corrisponde a nessuna operazione disponibile");
                    break;
            }

            static void ChiediNumeri( out double num1, out double num2)
            {                

                do
                {
                    Console.WriteLine("Inserisci il primo numero da sommare: ");
                } while (!double.TryParse(Console.ReadLine(), out num1));

                do
                {
                    Console.WriteLine("Inserisci il secondo numero da sommare: ");
                } while (!double.TryParse(Console.ReadLine(), out num2));
            }

            static void Soluzione2g()
            {

                double a,b,c;

                do
                {
                    Console.WriteLine("Quale valore vuoi assegnare ad A?");
                } while (!double.TryParse(Console.ReadLine(), out a));

                do
                {
                    Console.WriteLine("Quale valore vuoi assegnare ad B?");
                } while (!double.TryParse(Console.ReadLine(), out b));

                do
                {
                    Console.WriteLine("Quale valore vuoi assegnare ad C?");
                } while (!double.TryParse(Console.ReadLine(), out c));

                double delta = 0;
                double x1 = 0;
                double x2 = 0;

                if (a == 0)
                {
                    Console.WriteLine("Attenzione! Non è un'equazione di secondo grado se a = 0");
                }

                if (b == 0 && c != 0) //3) b = 0 && c != 0  ---> equazione pura  ---> +/-(sqrt(-(c/a)))
                {
                    delta = -(c / a);

                    //x1 = Math.Sqrt(-(c / a));
                    //x2 = -(Math.Sqrt(-(c / a)));
                    Console.WriteLine("Essendo un equazione pura (b = 0) la soluzione di questa equazione è: ");
                    Console.WriteLine($"x1 = sqrt({delta})");
                    Console.WriteLine($"x2 = -sqrt({delta})");
                }
                else if (b != 0 && c == 0) //4) b != 0 && c = 0  ---> equazione spuria  --->  x(ax+b)=0   x1=0;x2= -(b/a)
                {
                    delta = -(b / a);
                    Console.WriteLine("Essendo un equazione spuria (c = 0) la soluzione di questa equazione è: ");
                    Console.WriteLine("x1 = 0");
                    Console.WriteLine($"x2 = {delta}");
                }
                else  //2) a,b,c != 0 ---> formula completa
                {
                    delta = ((b * b) - 4 * (a * c));

                    if (delta > 0) //2.1) delta > 0  ---> x1 != x2
                    {
                        x1 = ((-b + (Math.Sqrt(delta))) / 2 * a);
                        x2 = ((-b - (Math.Sqrt(delta))) / 2 * a);
                        Console.WriteLine("la soluzione di questa equazione è: ");
                        Console.WriteLine($"x1 = {x1}");
                        Console.WriteLine($"x2 = {x2}");
                    }
                    else if (delta == 0) //2.2) delta = 0  ---> (x1 == x2) = -(b/2a)
                    {
                        x1 = -(b / (2 * a));
                        Console.WriteLine("delta = 0 quindi la soluzione di questa equazione è: ");
                        Console.WriteLine($"(x1 == x2) = {x1}");
                    }
                    else //2.3) delta < 0  ---> impossibile
                    {
                        Console.WriteLine("delta < 0 quindi la soluzione di questa equazione è: Impossibile");
                    }
                }

            }

            static void Somma()
            {
                double num1;
                double num2;

                ChiediNumeri(out num1, out num2);

                double sum = num1 + num2;
                Console.WriteLine($"la somma di {num1} e {num2} è {sum}");
            }

            static void Sottrazione()
            {
                double num1;
                double num2;

                ChiediNumeri(out num1, out num2);

                double sottr = num1 - num2;
                Console.WriteLine($"la sottrazione di {num1} e {num2} è {sottr}");
            }

            static void Moltiplicazione()
            {
                double num1;
                double num2;

                ChiediNumeri(out num1, out num2);

                double molt = num1 * num2;
                Console.WriteLine($"La moltiplicazione di {num1} e {num2} è {molt}");
            }

            static void Divisione()
            {
                double num1;
                double num2;
                double max;
                double min;

                ChiediNumeri(out num1, out num2);

                if (num1 > num2)
                {
                    max = num1;
                    min = num2;
                }
                else
                {
                    max = num2;
                    min = num1;
                }

                double quoz = (max / min);
                Console.WriteLine($"La divisione di {num1} e {num2} è {quoz}");
            }

        }
    }
}