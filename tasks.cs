namespace Homework1
{
    internal class tasks
    {
        // Задание 1: "Дано трехзначное число. Обнулить в нем разряд десятков."

        /// <summary>
        /// Обнуляет разряд десятков в трехзначном числе
        /// </summary>
        static void Zero_tenplace(ref int x)
        {
            if (x < -1000 || (x > -100 && x < 100) || x > 1000)
            {
                throw new ArgumentException("x must be three digit number");
            }
            x = Math.Abs(x);
            x = (x / 100) * 100 + (x % 10);
        }

        // Задание 2: "Даны координаты поля шахматной доски x, y (целые числа, лежащие в диапазоне 1–8). Учитывая, что левое нижнее поле доски (1, 1) является черным, вывести, какой цвет имеет поле с данными координатами."

        /// <summary>
        /// Определяет цвет поля с заданными координатами
        /// </summary>
        static void Color_Chess_board(int x, int y)
        {
            if ((x < 1) || (y < 1) || (x > 8) || (y > 8))
            {
                throw new ArgumentException("x and y must be in (1, 8)");
            }

            if (x % 2 == y % 2)
                Console.WriteLine($"Поле ({x}, {y}) - черное");
            else
                Console.WriteLine($"Поле ({x}, {y}) - белое");
        }


        // Задание 3: "Даны числа A, B, C (число A не равно 0). Вернуть количество вещественных корней квадратного уравнения Ax^2+Bx+c=0."

        /// <summary>
        /// Возвращает количество вещественных корней квадратного уравнения Ax^2+Bx+c=0
        /// </summary>
        static int Quadratic(double A, double B, double C)
        {
            if (A == 0)
            {
                throw new ArgumentException("A mustn't be 0");
            }
            double discriminant = B * B - 4 * A * C;
            if (discriminant < 0)
                return 0;
            else if (discriminant == 0)
                return 1;
            else
                return 2;
        }

        // Задание 4: "Создать функцию, которая возвращает минимум из двух переданных вещественных чисел."

        /// <summary>
        /// Возвращает минимум из двух переданных вещественных чисел
        /// </summary>
        static double Min_func(double x, double y) => x < y ? x : y;

        // Задание 5: "Даны целые числа A и B. Найти произведение всех чётных целых чисел от A до B включительно."

        /// <summary>
        /// Возвращает произведение всех чётных целых чисел от A до B включительно
        /// </summary>
        static double Prod_even(int A, int B)
        {
            if (A > B)
                (A, B) = (B, A);

            if (A % 2 != 0)
                A += 1;

            if (A > B)
                return 0;

            double res = 1;
            for (int i = A; i <= B; i += 2)
                res *= i;

            return res;
        }

        // Задание 6: "Дано целое число K и набор ненулевых целых чисел; признак его завершения — число 0. Вычислить количество чисел в наборе, меньших K, а также количество чисел, делящихся на K нацело."

        /// <summary>
        /// Возвращает количество чисел в наборе, меньших K, а также количество чисел, делящихся на K нацело
        /// </summary>
        static void Seq_div_less_K(out int cnt_less_K, out int cnt_div_K)
        {
            Console.WriteLine("Введите целое число K:");
            int K = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите последовательность:");
            int x = 0;
            cnt_less_K = 0;
            cnt_div_K = 0;
            do
            {
                x = int.Parse(Console.ReadLine());
                if (x < K)
                    cnt_less_K++;
                if (K == 0) // Делить на 0 нельзя
                    cnt_div_K = 0;
                else if (x % K == 0)
                    cnt_div_K++;
            } while (x != 0);
        }

        // Задание 7: "Описать перечислимый тип Seasons (времена года). Создать метод, который по номеру месяца [1..12] возвращает время года."

        enum Seasons // Времена года
        {
            WIN = 1,
            SPR,
            SUM,
            AUT
        }

        /// <summary>
        /// По номеру месяца [1..12] возвращает время года
        /// </summary>
        static string Return_Seasons(int month)
        {
            if (month < 1 || month > 12)
            {
                throw new ArgumentException("month must be in [1, 12]");
            }

            string res = "";
            switch (month)
            {
                case 1 or 2 or 12:
                    res = "Зима";
                    break;
                case 3 or 4 or 5:
                    res = "Весна";
                    break;
                case 6 or 7 or 8:
                    res = "Лето";
                    break;
                case 9 or 10 or 11:
                    res = "Осень";
                    break;
            }
            return res;
        }

        // Задание 8: "Описать метод, выводящий на консоль N строк "Месяц №<номер месяца>, его сезон: <сезон для этого месяца>". Номера месяцев генерируются случайно."

        /// <summary>
        /// Выводит на консоль N строк "Месяц №<номер месяца>, его сезон: <сезон для этого месяца>"
        /// </summary>
        static void Print_Month()
        {
            Console.WriteLine("Введите целое число N:");
            int N = int.Parse(Console.ReadLine());

            Random r = new Random();
            for (int i = 0; i < N; i++)
            {
                var month = r.Next(1, 13);
                Console.WriteLine($"Месяц №{month}, его сезон: {Return_Seasons(month)}");
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Задание 1:");

            int y1 = 375;
            Console.WriteLine($"Исходное число: {y1}");
            Zero_tenplace(ref y1);
            Console.WriteLine($"Результат: {y1}");

            int y2 = 100;
            Console.WriteLine($"Исходное число: {y2}");
            Zero_tenplace(ref y2);
            Console.WriteLine($"Результат: {y2}");

            int y3 = 999;
            Console.WriteLine($"Исходное число: {y3}");
            Zero_tenplace(ref y3);
            Console.WriteLine($"Результат: {y3}");

            Console.WriteLine();

            Console.WriteLine("Задание 2:");
            Color_Chess_board(1, 1);
            Color_Chess_board(2, 5);
            Color_Chess_board(3, 7);
            
            Console.WriteLine();

            Console.WriteLine("Задание 3:");
            Console.WriteLine($"Количество вещественных корней уравнения x^2+x+1=0: {Quadratic(1, 1, 1)}");
            Console.WriteLine($"Количество вещественных корней уравнения x^2+2x+1=0: {Quadratic(1, 2, 1)}");
            Console.WriteLine($"Количество вещественных корней уравнения 3x^2+5x+2=0: {Quadratic(3, 5, 2)}");

            Console.WriteLine();

            Console.WriteLine("Задание 4:");
            Console.WriteLine($"Минимум из 3.5 и 4.6,: {Min_func(3.5, 4.6)}");
            Console.WriteLine($"Минимум из -7 и 6.3: {Min_func(-7, 6.3)}");
            Console.WriteLine($"Минимум из 0 и 0: {Min_func(0, 0)}");

            Console.WriteLine();

            Console.WriteLine("Задание 5:");
            Console.WriteLine($"Произведение всех чётных целых чисел от 1 до 5: {Prod_even(1, 5)}");
            Console.WriteLine($"Произведение всех чётных целых чисел от 176 до 176: {Prod_even(176, 176)}");
            Console.WriteLine($"Произведение всех чётных целых чисел от 9 до 2: {Prod_even(9, 2)}");

            Console.WriteLine();
            
            Console.WriteLine("Задание 6:");
            Seq_div_less_K(out var cnt_less_K, out var cnt_div_K);
            Console.WriteLine($"Kоличество чисел, меньших K: {cnt_less_K}. Kоличество чисел, делящихся на K нацело: {cnt_div_K} ");
            
            Console.WriteLine();

            Console.WriteLine("Задание 7:");
            Console.WriteLine($"1 месяц - {Return_Seasons(1)}");
            Console.WriteLine($"8 месяц - {Return_Seasons(8)}");
            Console.WriteLine($"12 месяц - {Return_Seasons(12)}");

            Console.WriteLine();

            Console.WriteLine("Задание 8:");
            Print_Month();
        }
    }
}

/*
Задание 1:
Исходное число: 375
Результат: 305
Исходное число: 100
Результат: 100
Исходное число: 999
Результат: 909

Задание 2:
Поле (1, 1) - черное
Поле (2, 5) - белое
Поле (3, 7) - черное

Задание 3:
Количество вещественных корней уравнения x^2+x+1=0: 0
Количество вещественных корней уравнения x^2+2x+1=0: 1
Количество вещественных корней уравнения 3x^2+5x+2=0: 2

Задание 4:
Минимум из 3.5 и 4.6,: 3,5
Минимум из -7 и 6.3: -7
Минимум из 0 и 0: 0

Задание 5:
Произведение всех чётных целых чисел от 1 до 5: 8
Произведение всех чётных целых чисел от 176 до 176: 176
Произведение всех чётных целых чисел от 9 до 2: 384

Задание 6:
Введите целое число K:
10
Введите последовательность:
5
30
10
-10
-7
11
0
Kоличество чисел, меньших K: 4. Kоличество чисел, делящихся на K нацело: 4

Задание 7:
1 месяц - Зима
8 месяц - Лето
12 месяц - Зима

Задание 8:
Введите целое число N:
5
Месяц №6, его сезон: Лето
Месяц №4, его сезон: Весна
Месяц №12, его сезон: Зима
Месяц №3, его сезон: Весна
Месяц №9, его сезон: Осень
*/