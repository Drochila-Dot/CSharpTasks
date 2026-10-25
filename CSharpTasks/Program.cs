using System;
using System.Collections.Generic;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        // Установка кодировки для корректного отображения кириллицы в консоли
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Task1();
        Task2();
        Task3();
        Task4();
        Task5();
        Task6();
        Task7();
        Task8();
        Task9();
        Task10();
        Task11();
        Task12();
        Task13();
        Task14();
    }

    #region Задание 1. Hello, World + текущая дата
    static void Task1()
    {
        Console.WriteLine("=== Задание 1 ===");
        Console.WriteLine("Привет, мир!");
        Console.WriteLine($"Текущая дата: {DateTime.Now:dd.MM.yyyy}");
        Console.WriteLine();
    }
    #endregion

    #region Задание 2. Переменные примитивных типов
    static void Task2()
    {
        Console.WriteLine("=== Задание 2 ===");
        int i = 10;
        long l = 100L;
        double d = 5.5;
        float f = 4.2f;
        decimal dec = 19.99m;
        bool b = true;
        char c = 'X';
        string s = "C# Sharp";

        object[] vars = { i, l, d, f, dec, b, c, s };
        string[] names = { nameof(i), nameof(l), nameof(d), nameof(f), nameof(dec), nameof(b), nameof(c), nameof(s) };

        for (int idx = 0; idx < vars.Length; idx++)
        {
            Console.WriteLine($"{names[idx]} = {vars[idx]} ({vars[idx].GetType().Name})");
        }
        Console.WriteLine();
    }
    #endregion

    #region Задание 3. Калькулятор с обработкой деления на ноль
    static void Task3()
    {
        Console.WriteLine("=== Задание 3 ===");
        // Пример автоматической демонстрации работы калькулятора
        double a = 10;
        double b = 0;
        string op = "/";

        Console.WriteLine($"Выражение: {a} {op} {b}");
        bool success = true;
        double result = 0;

        switch (op)
        {
            case "+": result = a + b; break;
            case "-": result = a - b; break;
            case "*": result = a * b; break;
            case "/":
                if (b == 0)
                {
                    Console.WriteLine("Ошибка: деление на ноль!");
                    success = false;
                }
                else
                {
                    result = a / b;
                }
                break;
            default:
                Console.WriteLine("Неизвестная операция");
                success = false;
                break;
        }

        if (success)
        {
            Console.WriteLine($"Результат: {result}");
        }
        Console.WriteLine();
    }
    #endregion

    #region Задание 4. Чётность числа (два способа)
    static bool IsEvenMethod1(int n) => n % 2 == 0;
    static bool IsEvenMethod2(int n) => (n % 2 == 0) ? true : false;

    static void Task4()
    {
        Console.WriteLine("=== Задание 4 ===");
        int testNumber = 7;
        Console.WriteLine($"Число: {testNumber}");
        Console.WriteLine($"Способ 1 (% 2 == 0): {IsEvenMethod1(testNumber)}");
        Console.WriteLine($"Способ 2 (тернарный): {IsEvenMethod2(testNumber)}");
        Console.WriteLine();
    }
    #endregion

    #region Задание 5. Таблица умножения 10×10
    static void Task5()
    {
        Console.WriteLine("=== Задание 5 ===");
        Console.Write("   ");
        for (int i = 1; i <= 10; i++) Console.Write($"{i,4}");
        Console.WriteLine();
        Console.WriteLine(new string('-', 45));

        for (int i = 1; i <= 10; i++)
        {
            Console.Write($"{i,2}|");
            for (int j = 1; j <= 10; j++)
            {
                Console.Write($"{i * j,4}");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
    #endregion

    #region Задание 6. Сумма цифр числа (строка + арифметика)
    static int SumString(int n)
    {
        n = Math.Abs(n);
        string s = n.ToString();
        int sum = 0;
        for (int i = 0; i < s.Length; i++)
            sum += s[i] - '0';
        return sum;
    }

    static int SumArithmetic(int n)
    {
        n = Math.Abs(n);
        int sum = 0;
        while (n > 0)
        {
            sum += n % 10;
            n /= 10;
        }
        return sum;
    }

    static void Task6()
    {
        Console.WriteLine("=== Задание 6 ===");
        int[] numbers = { 1234, -567, 905 };
        foreach (var num in numbers)
        {
            Console.WriteLine($"Число: {num} | Через строку: {SumString(num)} | Арифметика: {SumArithmetic(num)}");
        }
        Console.WriteLine();
    }
    #endregion

    #region Задание 7. Реверс строки без LINQ
    static string ReverseString(string s)
    {
        if (string.IsNullOrEmpty(s)) return s;
        char[] chars = new char[s.Length];
        int index = 0;
        for (int i = s.Length - 1; i >= 0; i--)
        {
            chars[index++] = s[i];
        }
        return new string(chars);
    }

    static void Task7()
    {
        Console.WriteLine("=== Задание 7 ===");
        string[] tests = { "abc", "a", "", "Hello" };
        foreach (var t in tests)
        {
            Console.WriteLine($"\"{t}\" -> \"{ReverseString(t)}\"");
        }
        Console.WriteLine();
    }
    #endregion

    #region Задание 8. FizzBuzz 1–100
    static void Task8()
    {
        Console.WriteLine("=== Задание 8 (FizzBuzz) ===");
        for (int i = 1; i <= 100; i++)
        {
            if (i % 15 == 0) Console.Write("FizzBuzz ");
            else if (i % 3 == 0) Console.Write("Fizz ");
            else if (i % 5 == 0) Console.Write("Buzz ");
            else Console.Write($"{i} ");
        }
        Console.WriteLine("\n");
    }
    #endregion

    #region Задание 9. Массивы: min/max/sum/avg
    static int GetMin(int[] arr)
    {
        if (arr == null || arr.Length == 0) throw new ArgumentException("Массив пуст");
        int m = arr[0];
        for (int i = 1; i < arr.Length; i++) if (arr[i] < m) m = arr[i];
        return m;
    }

    static int GetMax(int[] arr)
    {
        if (arr == null || arr.Length == 0) throw new ArgumentException("Массив пуст");
        int m = arr[0];
        for (int i = 1; i < arr.Length; i++) if (arr[i] > m) m = arr[i];
        return m;
    }

    static long GetSum(int[] arr)
    {
        long s = 0;
        if (arr == null) return 0;
        for (int i = 0; i < arr.Length; i++) s += arr[i];
        return s;
    }

    static double GetAvg(int[] arr)
    {
        if (arr == null || arr.Length == 0) return 0;
        return (double)GetSum(arr) / arr.Length;
    }

    static void Task9()
    {
        Console.WriteLine("=== Задание 9 ===");
        int[] arr = { 10, 20, 30, 40, 50 };
        Console.WriteLine($"Массив: [{string.Join(", ", arr)}]");
        Console.WriteLine($"Min: {GetMin(arr)}, Max: {GetMax(arr)}, Sum: {GetSum(arr)}, Avg: {GetAvg(arr)}");
        Console.WriteLine();
    }
    #endregion

    #region Задание 10. Сортировка пузырьком + вставками
    static void BubbleSort(int[] array)
    {
        int n = array.Length;
        for (int i = 0; i < n - 1; i++)
        {
            bool swapped = false;
            for (int j = 0; j < n - i - 1; j++)
            {
                if (array[j] > array[j + 1])
                {
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                    swapped = true;
                }
            }
            if (!swapped) break;
        }
    }

    static void InsertionSort(int[] array)
    {
        int n = array.Length;
        for (int i = 1; i < n; ++i)
        {
            int key = array[i];
            int j = i - 1;
            while (j >= 0 && array[j] > key)
            {
                array[j + 1] = array[j];
                j = j - 1;
            }
            array[j + 1] = key;
        }
    }

    static void Task10()
    {
        Console.WriteLine("=== Задание 10 ===");
        int size = 10000;
        Random rnd = new Random();
        int[] original = new int[size];
        for (int i = 0; i < size; i++) original[i] = rnd.Next(1, 100000);

        int[] arr1 = (int[])original.Clone();
        int[] arr2 = (int[])original.Clone();

        Stopwatch sw = Stopwatch.StartNew();
        BubbleSort(arr1);
        sw.Stop();
        Console.WriteLine($"BubbleSort время: {sw.ElapsedMilliseconds} мс");

        sw.Restart();
        InsertionSort(arr2);
        sw.Stop();
        Console.WriteLine($"InsertionSort время: {sw.ElapsedMilliseconds} мс");
        Console.WriteLine();
    }
    #endregion

    #region Задание 11. Диагональ матрицы N×N
    static void Task11()
    {
        Console.WriteLine("=== Задание 11 ===");
        int n = 3;
        int[,] matrix = new int[n, n];
        Random rnd = new Random();

        Console.WriteLine($"Матрица {n}x{n}:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matrix[i, j] = rnd.Next(1, 10);
                Console.Write($"{matrix[i, j],4}");
            }
            Console.WriteLine();
        }

        int diagSum = 0;
        for (int i = 0; i < n; i++)
        {
            diagSum += matrix[i, i];
        }
        Console.WriteLine($"Сумма главной диагонали: {diagSum}\n");
    }
    #endregion

    #region Задание 12. Палиндром
    static bool IsPalindrome(string s)
    {
        if (string.IsNullOrEmpty(s)) return true;
        char[] buffer = new char[s.Length];
        int len = 0;
        for (int i = 0; i < s.Length; i++)
        {
            char c = char.ToLower(s[i]);
            if (char.IsLetterOrDigit(c))
            {
                buffer[len++] = c;
            }
        }

        int left = 0, right = len - 1;
        while (left < right)
        {
            if (buffer[left] != buffer[right]) return false;
            left++;
            right--;
        }
        return true;
    }

    static void Task12()
    {
        Console.WriteLine("=== Задание 12 ===");
        string t1 = "А роза упала на лапу Азора";
        string t2 = "hello";
        Console.WriteLine($"\"{t1}\" -> {IsPalindrome(t1)}");
        Console.WriteLine($"\"{t2}\" -> {IsPalindrome(t2)}");
        Console.WriteLine();
    }
    #endregion

    #region Задание 13. Счётчик вхождений слов в тексте
    static void Task13()
    {
        Console.WriteLine("=== Задание 13 ===");
        string text = "C# это отличный язык. C# популярен и удобен.";
        string[] words = text.Split(new char[] { ' ', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

        Dictionary<string, int> counts = new Dictionary<string, int>();
        foreach (string w in words)
        {
            string word = w.ToLower();
            if (counts.ContainsKey(word)) counts[word]++;
            else counts[word] = 1;
        }

        var sortedList = new List<KeyValuePair<string, int>>(counts);
        sortedList.Sort((a, b) => b.Value.CompareTo(a.Value));

        foreach (var pair in sortedList)
        {
            Console.WriteLine($"{pair.Key} -> {pair.Value}");
        }
        Console.WriteLine();
    }
    #endregion

    #region Задание 14. Возраст по дате рождения
    static void Task14()
    {
        Console.WriteLine("=== Задание 14 ===");
        string birthDateStr = "2005-06-15";
        if (DateTime.TryParse(birthDateStr, out DateTime birthDate))
        {
            DateTime today = DateTime.Today;
            int years = today.Year - birthDate.Year;
            int months = today.Month - birthDate.Month;
            int days = today.Day - birthDate.Day;

            if (days < 0)
            {
                months--;
                days += DateTime.DaysInMonth(today.AddMonths(-1).Year, today.AddMonths(-1).Month);
            }
            if (months < 0)
            {
                years--;
                months += 12;
            }

            Console.WriteLine($"Дата рождения: {birthDate:dd.MM.yyyy} | Возраст: {years} лет, {months} месяцев, {days} дней");
        }
        else
        {
            Console.WriteLine("Некорректная дата!");
        }
        Console.WriteLine();
    }

    #endregion
}
