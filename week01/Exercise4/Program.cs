using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = [];

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        while (true)
        {
            Console.Write("Enter number: ");
            int input = int.Parse(Console.ReadLine());

            if (input == 0)
                break;

            numbers.Add(input);
        }

        int sum = 0;
        foreach (int n in numbers)
            sum += n;

        double average = (double)sum / numbers.Count;
        int largest = numbers[0];
        foreach (int n in numbers)
            if (n > largest)
                largest = n;

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largest}");

        int smallestPositive = int.MaxValue;
        foreach (int n in numbers)
            if (n > 0 && n < smallestPositive)
                smallestPositive = n;

        if (smallestPositive != int.MaxValue)
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");

        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        foreach (int n in numbers)
            Console.WriteLine(n);
    }
}