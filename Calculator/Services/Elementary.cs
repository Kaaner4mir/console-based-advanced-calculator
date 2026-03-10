using Calculator.UI;

namespace Calculator.Services
{
    public class Elementary
    {
        public static double? Operations(SymbolsElementary symbol, Func<double, double, double> operation)
        {
            double inputVal1 = 0;
            bool usePreviousResult = false;

            if (StateManager.LastResult.HasValue)
            {
                string? response = ConsoleHelper.GetInput<string>($"👉 The last result was {StateManager.LastResult.Value}. Do you want to use it as the first value? (Y/N): ", ConsoleColor.Yellow);
                if (response?.Trim().ToUpper() == "Y")
                {
                    inputVal1 = StateManager.LastResult.Value;
                    usePreviousResult = true;
                }
            }

            if (!usePreviousResult)
            {
                inputVal1 = ConsoleHelper.GetInput<double>($"\n👉 Enter the first value: ");
            }

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

            string resultString = $"{inputVal1} {symbol} {inputVal2} = {result}";
            ConsoleHelper.WriteColored($"\n✅ {resultString}", ConsoleColor.Green);
            History.Add(resultString);
            return result;
        }
    }
}
