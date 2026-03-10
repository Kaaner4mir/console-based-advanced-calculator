using Calculator.Services;
using Calculator.UI;
using System.Text;

class Initializer
{
    public static void Main()
    {
        Console.InputEncoding = Encoding.UTF8;
        Console.OutputEncoding = Encoding.UTF8;
        Console.Title = "🧮 Advanced Calculator";

        while (true)
        {
            try
            {
                ConsoleHelper.ClearScreen();
                Menu.MainMenu();

                byte operation = ConsoleHelper.GetInput<byte>("\n ➡️ Select the operation you want to perform numerically: ");
                ConsoleHelper.ClearScreen();

                double? currentResult = null;
                bool shouldWait = true;

                switch (operation)
                {
                    case 1: currentResult = Elementary.Operations(SymbolsElementary.Addition, (inputVal1, inputVal2) => inputVal1 + inputVal2); break;
                    case 2: currentResult = Elementary.Operations(SymbolsElementary.Subtraction, (inputVal1, inputVal2) => inputVal1 - inputVal2); break;
                    case 3: currentResult = Elementary.Operations(SymbolsElementary.Multiplication, (inputVal1, inputVal2) => inputVal1 * inputVal2); break;
                    case 4: currentResult = Elementary.Operations(SymbolsElementary.Division, (inputVal1, inputVal2) => inputVal1 / inputVal2); break;
                    case 5: currentResult = Advanced.Exponentiation(SymbolsAdvanced.Exponentiation, (inputVal1, inputVal2) => Math.Pow(inputVal1, inputVal2)); break;
                    case 6: currentResult = Advanced.Root(SymbolsAdvanced.Root, (inputVal1, inputVal2) => Math.Pow(inputVal2, 1.0 / inputVal1)); break;
                    case 7: currentResult = Advanced.Factorial(SymbolsAdvanced.Factorial); break;
                    case 8: currentResult = Advanced.Modulo(SymbolsAdvanced.Modulo, (inputVal1, inputVal2) => inputVal1 % inputVal2); break;
                    case 9: Trigonometry.Operations(); shouldWait = false; break;
                    case 10: Logarithm.Operations(); shouldWait = false; break;
                    case 11: EquationSolver.Operations(); shouldWait = false; break;
                    case 12: Statistics.Operations(); shouldWait = false; break;
                    case 13: Converters.Operations(); shouldWait = false; break;
                    case 14: History.Show(); break;
                    case 15: Memory.Operations(); shouldWait = false; break;
                    case 16:
                        ConsoleHelper.WriteColored("\n Goodbye! Exiting the application...", ConsoleColor.Cyan);
                        Environment.Exit(0);
                        break;
                    default: ConsoleHelper.WriteColored("\n❓ You have made an invalid transaction!", ConsoleColor.DarkRed); break;
                }

                if (currentResult.HasValue)
                {
                    StateManager.LastResult = currentResult;
                }

                if (shouldWait) ConsoleHelper.WaitingScreen();
            }
            catch (Exception ex)
            {
                ConsoleHelper.WriteColored($"\n ⚠️ An error has occured: {ex.Message}", ConsoleColor.DarkRed);
            }
        }
    }
}