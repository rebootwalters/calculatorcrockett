using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator
{
    class Program
    {
        static double add(double left, double right)
        {
            return left + right;
        }
        static double sub(double left, double right)
        {
            return left - right;
        }

        static double div(double left, double right)
        {
            return left / right;
        }
        static double mul(double left, double right)
        {
            return left * right;
        }
        static double mod(double left, double right)
        {
            return left % right;
        }

        static char inputchar(string message, calculator calc)
        {
            while (true)
            {
                Console.Write(message);
                string input;
                input = Console.ReadLine();
                if (0 < input.Length)
                {
                    if (calc.ValidOp(input[0]))
                    {return input[0]; }
                    
                }
                Console.WriteLine("Your response was invalid");
            }
        }

        static double inputdouble(string message)
        {
            double rv;
            while (true)
            {
                Console.Write(message);
                string input;
                input = Console.ReadLine();
                if (double.TryParse(input,out rv))
                {

                    return rv;
                }
                Console.WriteLine("Your response was invalid");
            }
        }
        static void Main(string[] args)
        {
            calculator calc = new calculator();
            calc.operations.Add('+', add);
            calc.operations.Add('-', sub);
            calc.operations.Add('*', mul);
            calc.operations.Add('/', div);
            calc.operations.Add('%', mod);

          
            
            while(true)
            {
                calc.Left = inputdouble("Enter a Left Number:");

                while (true)
                {
                    char c = inputchar("Enter a valid operation +-*/% :", calc);
                    calc.SetOperation(c );

                    calc.Right = inputdouble("Enter a Right Number: ");
                    calc.invoke();
                    Console.WriteLine($"Left is now: {calc.Left}");
                }
               

            }

            calc.Left = 10;
            calc.SetOperation('+');
            calc.Right = 20;
            
            calc.invoke();
            Console.WriteLine(calc.Left);
        }
    }

    delegate double op(double left, double right);

    class calculator
    {
        public double Left { get; set; }

        op _operation;

        public bool SetOperation(char operation)
        {
            op data;
            bool isFound;
            isFound = operations.TryGetValue(operation, out data);
            if (isFound)
            {
                _operation = data;
            }
            return isFound;
        }

        public double Right { get; set; }
       

        public Dictionary<char, op> operations = new Dictionary<char, op>();
        public void invoke()
        {
            if (null == _operation)
            {
                throw new Exception("Operation is NULL"); 
            }
            Left = _operation(Left, Right);
            _operation = null;
            Right = 0;
        }

        public bool ValidOp(char c)
        {
            
             return(operations.ContainsKey(c));
            
        }
        
    }
}
