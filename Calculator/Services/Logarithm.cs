using Calculator.UI;

namespace Calculator.Services
{
    public class Logarithm
    {
        public static void Operations()
        {
            while (true)
            {
                ConsoleHelper.ClearScreen();
                Menu.LogarithmMenu();

                byte inputVal = ConsoleHelper.GetInput<byte>("\n➡️ Enter the operation you wish to perform numerically: ");

                if (inputVal == 5) return;

                if (inputVal < 1 || inputVal > 4)
                {
                    ConsoleHelper.WriteColored("\n❓ You have made an invalid transaction!", ConsoleColor.DarkRed);
                    ConsoleHelper.WaitingScreen();
                    continue;
                }

                ConsoleHelper.ClearScreen();

                SymbolsLogarithms operationType = (SymbolsLogarithms)(inputVal - 1);

                if (operationType == SymbolsLogarithms.SpecifiedBaseLogarithm)
                {
                    SpecifiedBaseLogarithm();
                }
                else
                {
                    double argument = 0;
                    bool usePreviousResult = false;

                    if (StateManager.LastResult.HasValue)
                    {
                        string? response = ConsoleHelper.GetInput<string>($"👉 The last result was {StateManager.LastResult.Value}. Do you want to use it as the argument? (Y/N): ", ConsoleColor.Yellow);
                        if (response?.Trim().ToUpper() == "Y")
                        {
                            argument = StateManager.LastResult.Value;
                            usePreviousResult = true;
                        }
                    }

                    if (!usePreviousResult)
                    {
                        argument = ConsoleHelper.GetInput<double>("\n👉 Enter the argument: ");
                    }

                    if (argument <= 0)
                    {
                        ConsoleHelper.WriteColored("\n⚠️ The argument of a logarithm must be greater than 0.", ConsoleColor.DarkRed);
                        ConsoleHelper.WaitingScreen();
                        continue;
                    }

                    double result = operationType switch
                    {
                        SymbolsLogarithms.NaturalLogarithm => Math.Log(argument),
                        SymbolsLogarithms.CommonLogarithm => Math.Log10(argument),
                        SymbolsLogarithms.BinaryLogarithm => Math.Log2(argument),
                        _ => throw new Exception("Unknown operation")
                    };

                    ShowResult(argument, result, operationType);
                }

                ConsoleHelper.WaitingScreen();
            }
        }

        public static void SpecifiedBaseLogarithm()
        {
            double baseNumber = ConsoleHelper.GetInput<double>("👉 Enter the base number: ");
            double argument = 0;
            bool usePreviousResult = false;

            if (StateManager.LastResult.HasValue)
            {
                string? response = ConsoleHelper.GetInput<string>($"👉 The last result was {StateManager.LastResult.Value}. Do you want to use it as the argument? (Y/N): ", ConsoleColor.Yellow);
                if (response?.Trim().ToUpper() == "Y")
                {
                    argument = StateManager.LastResult.Value;
                    usePreviousResult = true;
                }
            }

            if (!usePreviousResult)
            {
                argument = ConsoleHelper.GetInput<double>("\n👉 Enter the argument: ");
            }

            if (baseNumber <= 0 || baseNumber == 1)
            {
                throw new Exception("The base of a logarithm must be greater than 0 and not equal to 1.");
            }
            if (argument <= 0)
            {
                throw new Exception("The argument of a logarithm must be greater than 0.");
            }

            double result = Math.Log(argument, baseNumber);

            string resStr = $"log_{baseNumber}({argument}) = {result}";
            ConsoleHelper.WriteColored($"\n✅ {resStr}", ConsoleColor.Green);
            History.Add(resStr);
        }

        public static double ShowResult(double argument, double result, SymbolsLogarithms operationType)
        {
            string symbol = operationType switch
            {
                SymbolsLogarithms.NaturalLogarithm => "ln",
                SymbolsLogarithms.CommonLogarithm => "log",
                SymbolsLogarithms.BinaryLogarithm => "log2",
                _ => "?",
            };

            string resStr = $"{symbol}({argument}) = {result}";
            ConsoleHelper.WriteColored($"\n✅ {resStr}", ConsoleColor.Green);
            History.Add(resStr);
            return result;
        }
    }
}
