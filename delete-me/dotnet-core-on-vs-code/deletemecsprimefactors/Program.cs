using System;
using System.Collections;

namespace deletemecsprimefactors
{
    class Program
    {
        static void Main(string[] args)
        {
            int workingNumber;
            // hold all the factors
            ArrayList list = new ArrayList();
            do
            {
                Console.WriteLine("Enter Number");
                string inputString = Console.ReadLine();
                bool success = int.TryParse(inputString, out int inputNumber);
                // leave the inputNumber as it is and instead use workingNumber to work down the factors
                workingNumber = inputNumber;
                if (success)
                {
                    // try all the factors starting at 2
                    for (int i = 2; i <= inputNumber; i++)
                    {
                        System.Console.WriteLine($"i is {i}");
                        // be aware multiple factors might exist so set this to false until sure all the factors are exhausted eg 24 = 2x2x2x3
                        bool exhaustedMultipleFactors = false;
                        while (exhaustedMultipleFactors == false)
                        {
                            // is i a factor
                            if (workingNumber % i == 0)
                            {
                                workingNumber = workingNumber / i;
                                list.Add(i);
                            }
                            else{
                                exhaustedMultipleFactors = true;
                            }
                        }
                    }
                }
                else
                {
                    System.Console.WriteLine("Invalid number - try again");
                }
            }
            // keep iterating until finally divide by itself to get 1 and so exit loop
            while (workingNumber > 1);

            foreach(int i in list){
                System.Console.WriteLine(i);
            } 

        }
    }
}
