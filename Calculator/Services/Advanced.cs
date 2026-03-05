namespace Calculator.Services
{
    public class Advanced
    {
        public static double? Exponentiation(SymbolsAdvanced symbol, Func<double, double, double> operation)
        {
            try
            {
                double baseNumber = ConsoleHelper.GetInput<double>("👉 Enter the base number: ");
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
            catch (Exception ex)
            {

                ConsoleHelper.WriteColored($"\n⚠️ An error has occured: {ex.Message}", ConsoleColor.DarkRed);
                return null; ;
            }
        }

        public static double? Root(SymbolsAdvanced symbol, Func<int, double, double> operation)
        {
            try
            {
                int degree = ConsoleHelper.GetInput<int>("👉 Enter the degree: ");
                double radicand = ConsoleHelper.GetInput<double>("👉 Enter the radicand: ");

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
            catch (Exception ex)
            {
                ConsoleHelper.WriteColored($"\n⚠️ An error has occured: {ex.Message}", ConsoleColor.Red);
                return null;
            }
        }

        public static long? Factorial(SymbolsAdvanced symbol)
        {
            try
            {
                long result = 1;

                long number = ConsoleHelper.GetInput<long>("👉 Enter the number whose factorial value you want to find: ");

                if (number < 0)
                    throw new Exception("The number entered cannot be negative!");

                if (number % 1 != 0)
                    throw new Exception("The number entered cannot be a decimal number!");

                for (long i = number; i > 0; i--)
                    result *= i;

                return Convert.ToInt64(ShowResult(result, number, 0, symbol));
            }
            catch (Exception ex)
            {
                ConsoleHelper.WriteColored($"\n⚠️ An error has occured: {ex.Message}", ConsoleColor.Red);
                return null;
            }
        }

        public static double? Modulo(SymbolsAdvanced symbol, Func<double, double, double> operation)
        {
            double dividend = ConsoleHelper.GetInput<double>("👉 Enter the dividend number: ");
            double divisor = ConsoleHelper.GetInput<double>("👉 Enter the divisor number: ");

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
                ConsoleHelper.WriteColored($"\n✅ {inputVal1}{symbol} = {result}", ConsoleColor.Green);
                return result;
            }

            ConsoleHelper.WriteColored($"\n✅ {inputVal1} {symbol} {inputVal2} = {result}", ConsoleColor.Green);
            return result;
        }
    }
}
