using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using calculatorLibrary;


namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
           
          

            try
            {
                //Class to convert user input
                InputConverter inputConverter = new InputConverter();

                //Class to perform actual calculations
             

                CalculatorEngineLibrary calculatorEngine = new CalculatorEngineLibrary();



                //isDouble1 and 2 and used to verify code instead of directly sending the Console.ReadLine() value to the InputConverter Class
                //this is mainly used to prevent the user from throwing an exception from a non-numeric number like "six" or "cat"

                Console.WriteLine("write first number");
                String firstNumberPlaceHolder = Console.ReadLine();


                bool isDouble1 = Double.TryParse(firstNumberPlaceHolder, out double firstNumber);

                while (!isDouble1)
                {

                    Console.WriteLine("Enter numeric characters only like '5' or '-34' ");
                    firstNumberPlaceHolder = Console.ReadLine();
                    isDouble1 = Double.TryParse(firstNumberPlaceHolder, out firstNumber);
                }
                firstNumber = inputConverter.ConvertInputToNumeric(firstNumberPlaceHolder);


                Console.WriteLine("write second number");

                String secondNumberPlaceHolder = Console.ReadLine();


                bool isDouble2 = Double.TryParse(secondNumberPlaceHolder, out double secondNumber);

                while (!isDouble2)
                {

                    Console.WriteLine("Enter numeric characters only like '5' or '-34' ");
                    secondNumberPlaceHolder = Console.ReadLine();
                    isDouble2 = Double.TryParse(secondNumberPlaceHolder, out secondNumber);
                }
                secondNumber = inputConverter.ConvertInputToNumeric(secondNumberPlaceHolder);



                //arraylist containing all compatible operators
                ArrayList arrayOfOperators = new ArrayList();
                arrayOfOperators.Add("-");
                arrayOfOperators.Add("+");
                arrayOfOperators.Add("*");
                arrayOfOperators.Add("/");
                arrayOfOperators.Add("add");
                arrayOfOperators.Add("substract");
                arrayOfOperators.Add("multiply");
                arrayOfOperators.Add("divide");
                arrayOfOperators.Add("^");
                arrayOfOperators.Add("exponent");
                String operation = Console.ReadLine();

                //used to check if one of the operators is present
                bool isInArray = false;



                while (!isInArray) 
                {

                    if (arrayOfOperators.Contains(operation.ToLower())) {
                        Console.WriteLine("Calculating....");

                        isInArray = true;
                    }

                    else { 
                    Console.WriteLine("you typed an invalid operator. Please enter one such as '-' or 'divide' ");
                    operation = Console.ReadLine(); }
              
                }


                //displays formated result with stringbuilder and string formatting

                StringBuilder myStringBuild = new StringBuilder();
                double result = calculatorEngine.Calculate(operation, firstNumber, secondNumber);

                myStringBuild.Insert(0, firstNumber + " " + operation + " " + secondNumber);


                myStringBuild.AppendFormat(" equals : {0:n2}", result);
                Console.WriteLine(myStringBuild);





            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                
            }


        }
    }
}
