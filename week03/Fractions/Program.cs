using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction wholeOne = new Fraction();    
        Fraction five = new Fraction(5); 
        Fraction threeFourths = new Fraction(3, 4);
        Fraction oneThird = new Fraction(1, 3);

        PrintFraction(wholeOne);
        PrintFraction(five);
        PrintFraction(threeFourths);
        PrintFraction(oneThird);

        Console.WriteLine("\nTesting setters:");
        Fraction testFraction = new Fraction(1, 2);
        PrintFraction(testFraction);

        testFraction.SetTop(6);
        testFraction.SetBottom(7);
        Console.WriteLine("After calling SetTop(6) and SetBottom(7):");
        PrintFraction(testFraction);
    }

    static void PrintFraction(Fraction fraction)
    {
        Console.WriteLine(fraction.GetFractionString());
        Console.WriteLine(fraction.GetDecimalValue());
    }
}