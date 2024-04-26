using System;
using System.IO;
using System.Windows;

namespace FileInteraction
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GenerateNumbersButton_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            int[] numbers = new int[100];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(1, 1000); 
            }

            string primes = "";
            string fibonacci = "";
            foreach (int number in numbers)
            {
                if (IsPrime(number))
                {
                    primes += number + Environment.NewLine;
                }
                if (IsFibonacci(number))
                {
                    fibonacci += number + Environment.NewLine;
                }
            }

            string primesFilePath = "primes.txt";
            File.WriteAllText(primesFilePath, primes);

            string fibonacciFilePath = "fibonacci.txt";
            File.WriteAllText(fibonacciFilePath, fibonacci);

            StatisticsTextBlock.Text = $"Згенеровано 100 чисел.\n" +
                                       $"Прості числа збережено у файл {primesFilePath}.\n" +
                                       $"Числа Фібоначчі збережено у файл {fibonacciFilePath}.";
        }

        private bool IsPrime(int number)
        {
            if (number <= 1)
                return false;
            if (number == 2)
                return true;
            if (number % 2 == 0)
                return false;
            for (int i = 3; i <= Math.Sqrt(number); i += 2)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }

        private bool IsFibonacci(int number)
        {
            int a = 0;
            int b = 1;
            while (b < number)
            {
                int temp = a;
                a = b;
                b = temp + b;
            }
            return b == number;
        }
    }
}