namespace Calculator.Services
{
    public class Elementary
    {
        public static double? Operations(SymbolsElementary symbol, Func<double, double, double> operation)
        {
            try
            {
                double inputVal1 = ConsoleHelper.GetInput<double>($"👉 Enter the first value: ");
                double inputVal2 = ConsoleHelper.GetInput<double>($"👉 Enter the second value: ");

                if (symbol == SymbolsElementary.Division)
                {
                    if (inputVal1 == 0 && inputVal2 == 0)
                    {
                        throw new Exception($"UNDEFINED!");
                    }

                    if (inputVal2 == 0)
                    {
                        throw new Exception("Divisor cannot be zero.");
                    }
                }

                double result = operation(inputVal1, inputVal2);
                return ShowResult(result, inputVal1, inputVal2, symbol);
            }
            catch (Exception ex)
            {
                ConsoleHelper.WriteColored($"\n⚠️ An error has occured: {ex.Message}", ConsoleColor.DarkRed);
                return null;
            }
        }

        public static double ShowResult(double result, double inputVal1, double inputVal2, SymbolsElementary operationType)
        {
            string symbol = operationType switch
            {
                SymbolsElementary.Addition => "+",
                SymbolsElementary.Subtraction => "-",
                SymbolsElementary.Multiplication => "x",
                SymbolsElementary.Division => "/",
                _ => "?",
            };

            ConsoleHelper.WriteColored($"\n✅ {inputVal1} {symbol} {inputVal2} = {result}", ConsoleColor.Green);
            return result;
        }
    }
}
