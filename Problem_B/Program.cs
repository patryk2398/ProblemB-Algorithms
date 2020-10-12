using System;
namespace Problem_B
{
    class vertex
    {
        public int x, y;
    };
    class coefficients
    {
        public double a, b, c;
    };
    class Program
    {      
        static int counter(coefficients[] array, int n, int ii)
        {          
            int maxL = 1; //maksymalna ilość znalezionych punktów do tej pory
            for (int i = 0; i < n-1-ii; i++)
            {
                int L = 1; //licznik punktów wspóliniowych               
                for (int j = 0; j < n-1-ii; j++)
                {                  
                    if(array[j].c == 123.456) //sprawdzenie czy punkty się pokrywają
                    {
                        L++;
                        continue;
                    }
                    if (array[i].a == array[j].a && array[i].b == array[j].b)  //sprawdzenie czy współczynniki funkcji są identyczne
                    {                       
                        L++;
                    }
                }
                if (L > maxL)
                {
                    maxL = L;
                }
            }
            return (maxL);
        }

        static int line_function(vertex A, vertex B, ref double a, ref double b, ref double c)
        {
            double a1 = (A.y - B.y);
            double a2 = (A.x - B.x);
            if (a2 == 0 && a1 == 0) //punkty pokrywające się
            {
                c = 123.456;
                return 0;
            }
            if (a2 == 0) //punkty o jednakowym x
            {
                b = 654.321;
                return 0;
            }
            a = (a1 / a2);
            b = B.y - (a * B.x);
            a = Math.Round(a, 6);
            b = Math.Round(b, 6);
            return 1;
        }
        static int calculation(vertex[] array, int n)
        {
            int max_number_of_collinears = 0;
            coefficients[] array_coefficients = new coefficients[n];
            for (int i = 0; i < n; i++)
            {
                int k = 0;
                for (int j = i + 1; j < n; j++)
                {                   
                    array_coefficients[k] = new coefficients();
                    line_function(array[i], array[j], ref array_coefficients[k].a, ref array_coefficients[k].b, ref array_coefficients[k].c);                                                          
                    k++;
                }
                int tmp = counter(array_coefficients, n, i);
                if (tmp > max_number_of_collinears)
                {
                    max_number_of_collinears = tmp;                   
                }            
            }
            return max_number_of_collinears;
        }

        static void Main(string[] args)
        {
            string x=" ";
            int j = 0;
            string line; // linia tekstu pobrana z pliku
            char[] sign = { ' ' }; //oddzielenie współrzędnych X i Y w linii
            vertex[] array = new vertex[1000];           
            do
            {                
                int nr = 1;
                do
                {
                    int counter = 0;
                    if(x != " ")
                    {
                        array[0] = new vertex();
                        j = 1;
                        string[] test2 = x.Split(sign);
                        array[0].x = Convert.ToInt32(test2[0]);
                        array[0].y = Convert.ToInt32(test2[1]);
                        counter++;
                    }
                    for (int i = 0 + j; i <= 1000; i++)
                    {
                        line = Console.ReadLine();
                        if (line.Contains("--"))
                        {
                            break;
                        }
                        else
                        {
                            array[i] = new vertex();
                            string[] test2 = line.Split(sign);
                            array[i].x = Convert.ToInt32(test2[0]);
                            array[i].y = Convert.ToInt32(test2[1]);
                            counter++;
                        }
                    }
                    Console.WriteLine(nr++ + ". " + calculation(array, counter));
                    x = Console.ReadLine();
                } while (!x.Contains("--"));
                x = Console.ReadLine();
            }
            while (x != null);
        }
    }
}
