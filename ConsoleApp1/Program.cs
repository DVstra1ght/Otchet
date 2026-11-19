using System;
using System.Linq; // Добавлено для работы метода расширения .Max()

namespace XmlDocumentationProject
{
    internal class Program
    {
        /// <summary>
        /// Свойство-пример для демонстрации тега value.
        /// </summary>
        /// <value>Хранит текущий масштаб для формул (по умолчанию 1.0).</value>
        public static double Scale { get; set; } = 1.0;

        private static void Main(string[] args)
        {
            Console.WriteLine("=== Демонстрация работы функций ===\n");

            // 1. Вычисление значения
            double area = CalculateCircleArea(5);
            Console.WriteLine($"1. Площадь круга (r=5): {area:F2}");

            // 2. Обработка строки
            string reversed = ReverseString("Привет");
            Console.WriteLine($"2. Перевернутая строка: {reversed}");

            // 3. Работа с массивом
            int[] numbers = { 3, 7, 1, 9, 4 };
            int maxNumber = FindMax(numbers);
            Console.WriteLine($"3. Максимальное число в массиве: {maxNumber}");

            // 4. Проверка условия
            bool isEven = IsEven(8);
            Console.WriteLine($"4. Число 8 четное? {isEven}");

            // 5. Преобразование данных
            int celsius = FahrenheitToCelsius(98);
            Console.WriteLine($"5. 98°F в Цельсиях: {celsius}°C");

            Console.ReadLine();
        }

        /// <summary>
        /// Вычисляет площадь круга по заданному радиусу.
        /// </summary>
        /// <param name="radius">Радиус круга. Должен быть больше нуля.</param>
        /// <returns>Площадь круга в виде числа с плавающей точкой.</returns>
        /// <exception cref="ArgumentException">Выбрасывается, если радиус меньше или равен нулю.</exception>
        public static double CalculateCircleArea(double radius)
        {
            if (radius <= 0)
            {
                throw new ArgumentException("Радиус должен быть больше нуля.");
            }

            return Math.PI * Math.Pow(radius, 2);
        }

        /// <summary>
        /// Разворачивает строку задом наперед.
        /// </summary>
        /// <param name="input">Исходная строка для обработки.</param>
        /// <returns>Новая строка, записанная в обратном порядке.</returns>
        /// <remarks>
        /// Метод использует встроенный метод <see cref="Array.Reverse(Array)"/> для эффективного переворота символов.
        /// </remarks>
        public static string ReverseString(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);

            return new string(charArray);
        }

        /// <summary>
        /// Находит наибольшее число в массиве целых чисел.
        /// </summary>
        /// <param name="numbers">Массив чисел для поиска.</param>
        /// <returns>Наибольшее целое число из массива.</returns>
        /// <example>
        /// Пример использования:
        /// <code>
        /// int[] arr = { 1, 5, 3 };
        /// int max = FindMax(arr); // max будет равен 5
        /// </code>
        /// </example>
        public static int FindMax(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
            {
                throw new ArgumentException("Массив не должен быть пустым.");
            }

            // Оптимизация: вместо ручного цикла foreach и вложенного if используем LINQ
            return numbers.Max();
        }

        /// <summary>
        /// Проверяет, является ли число четным.
        /// </summary>
        /// <param name="number">Целое число для проверки.</param>
        /// <returns>Возвращает <c>true</c>, если число четное; иначе <c>false</c>.</returns>
        public static bool IsEven(int number)
        {
            return number % 2 == 0;
        }

        /// <summary>
        /// Переводит температуру из градусов Фаренгейта в градусы Цельсия.
        /// </summary>
        /// <param name="fahrenheit">Температура в Фаренгейтах.</param>
        /// <returns>Округленное значение температуры в Цельсиях.</returns>
        /// <seealso cref="CalculateCircleArea"/>
        public static int FahrenheitToCelsius(double fahrenheit)
        {
            return (int)Math.Round((fahrenheit - 32) * 5 / 9);
        }
    }
}