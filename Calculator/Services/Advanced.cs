using Calculator.UI;
using System.Numerics;

namespace Calculator.Services
{
    public class Advanced
    {
        public static double? Exponentiation(SymbolsAdvanced symbol, Func<double, double, double> operation)
        {
            double baseNumber = 0;
            bool usePreviousResult = false;

            if (StateManager.LastResult.HasValue)
            {
                string? response = ConsoleHelper.GetInput<string>($"👉 The last result was {StateManager.LastResult.Value}. Do you want to use it as the base number? (Y/N): ", ConsoleColor.Yellow);
                if (response?.Trim().ToUpper() == "Y")
                {
                    baseNumber = StateManager.LastResult.Value;
                    usePreviousResult = true;
                }
            }

            if (!usePreviousResult)
            {
                baseNumber = ConsoleHelper.GetInput<double>("👉 Enter the base number: ");
            }

            double exponent = ConsoleHelper.GetInput<double>("👉 Enter the exponent: ");

            if (exponent == 0)
            {
                if (baseNumber == 0)
                {
                    throw new Exception("UNDEFINIED!");
                }
                throw new DivideByZeroException();
            }

            double result = operation(baseNumber, exponent);
            return ShowResult(result, baseNumber, exponent, symbol);
        }

        public static double? Root(SymbolsAdvanced symbol, Func<int, double, double> operation)
        {
            int degree = 0;
            double radicand = 0;
            bool usePreviousResult = false;

            if (StateManager.LastResult.HasValue)
            {
                string? response = ConsoleHelper.GetInput<string>($"\n👉 The last result was {StateManager.LastResult.Value}. Do you want to use it as the radicand? (Y/N): ", ConsoleColor.Yellow);
                if (response?.Trim().ToUpper() == "Y")
                {
                    radicand = StateManager.LastResult.Value;
                    usePreviousResult = true;
                }
            }

            degree = ConsoleHelper.GetInput<int>("👉 Enter the degree: ");
            if (!usePreviousResult)
            {
                radicand = ConsoleHelper.GetInput<double>("👉 Enter the radicand: ");
            }

            if (degree == 0)
            {
                throw new Exception("The root degree cannot be 0.");
            }
            if (degree % 2 == 0 && radicand < 0)
            {
                throw new Exception("UNDEFINIED!");
            }

            double result = operation(degree, radicand);

            return ShowResult(result, degree, radicand, symbol);
        }

        public static double? Factorial(SymbolsAdvanced symbol)
        {
            BigInteger result = 1;
            long number = 0;

            if (StateManager.LastResult.HasValue)
            {
                string? response = ConsoleHelper.GetInput<string>($"\n👉 The last result was {StateManager.LastResult.Value}. Do you want to use it? (Y/N): ", ConsoleColor.Yellow);
                if (response?.Trim().ToUpper() == "Y")
                {
                    number = (long)StateManager.LastResult.Value;
                }
                else
                {
                    number = ConsoleHelper.GetInput<long>("👉 Enter the number: ");
                }
            }
            else
            {
                number = ConsoleHelper.GetInput<long>("👉 Enter the number: ");
            }

            if (number < 0)
                throw new Exception("The number entered cannot be negative!");

            for (long i = number; i > 0; i--)
                result *= i;

            string resStr = $"{number}! = {result}";
            ConsoleHelper.WriteColored($"\n✅ {resStr}", ConsoleColor.Green);
            History.Add(resStr);

            return (double)result;
        }

        public static double? Modulo(SymbolsAdvanced symbol, Func<double, double, double> operation)
        {
            double dividend = 0;
            double divisor = 0;
            bool usePreviousResult = false;

            if (StateManager.LastResult.HasValue)
            {
                string? response = ConsoleHelper.GetInput<string>($"\n👉 The last result was {StateManager.LastResult.Value}. Do you want to use it as the dividend? (Y/N): ", ConsoleColor.Yellow);
                if (response?.Trim().ToUpper() == "Y")
                {
                    dividend = StateManager.LastResult.Value;
                    usePreviousResult = true;
                }
            }

            if (!usePreviousResult)
            {
                dividend = ConsoleHelper.GetInput<double>("👉 Enter the dividend number: ");
            }
            divisor = ConsoleHelper.GetInput<double>("👉 Enter the divisor number: ");

            if (dividend == 0 && divisor == 0)
            {
                throw new Exception($"UNDEFINED!");
            }

            if (divisor == 0)
            {
                throw new Exception("Divisor cannot be zero.");
            }

            double result = operation(dividend, divisor);

            return ShowResult(result, dividend, divisor, symbol);
        }

        public static double ShowResult(double result, double inputVal1, double inputVal2, SymbolsAdvanced operationType)
        {
            string symbol = operationType switch
            {

                SymbolsAdvanced.Exponentiation => "^",
                SymbolsAdvanced.Root => "√",
                SymbolsAdvanced.Factorial => "!",
                SymbolsAdvanced.Modulo => "%",
                _ => "?",
            };

            if (operationType == SymbolsAdvanced.Factorial)
            {
                string resStrFact = $"{inputVal1}{symbol} = {result}";
                ConsoleHelper.WriteColored($"\n✅ {resStrFact}", ConsoleColor.Green);
                History.Add(resStrFact);
                return result;
            }

            string resStr = $"{inputVal1} {symbol} {inputVal2} = {result}";
            ConsoleHelper.WriteColored($"\n✅ {resStr}", ConsoleColor.Green);
            History.Add(resStr);
            return result;
        }
    }
}
