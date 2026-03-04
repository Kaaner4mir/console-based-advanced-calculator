namespace Calculator.Services
{
    public class Elementary
    {
        public static decimal? Operations(SymbolsElementary symbol, Func<decimal, decimal, decimal> operation)
        {
            try
            {
                decimal inputVal1 = ConsoleHelper.GetInput<decimal>($"👉 Enter the first value: ");
                decimal inputVal2 = ConsoleHelper.GetInput<decimal>($"👉 Enter the second value: ");

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

                decimal result = operation(inputVal1, inputVal2);
                return ShowResult(result, inputVal1, inputVal2, symbol);
            }
            catch (Exception ex)
            {
                ConsoleHelper.WriteColored($"\n⚠️ An error has occured: {ex.Message}", ConsoleColor.DarkRed);
                return null;
            }
        }

        public static decimal ShowResult(decimal result, decimal inputVal1, decimal inputVal2, SymbolsElementary operationType)
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
