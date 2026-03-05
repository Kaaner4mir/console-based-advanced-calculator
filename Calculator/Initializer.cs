using Calculator;
using Calculator.Services;
using System.Text;

class Initializer
{
    public static void Main()
    {
        Console.InputEncoding = Encoding.UTF8;
        Console.OutputEncoding = Encoding.UTF8;

        while (true)
        {
            try
            {
                Menu.MainMenu();

                byte operation = ConsoleHelper.GetInput<byte>("\n ➡️ Select the operation you want to perform numerically: ");
                Console.Clear();

                switch (operation)
                {
                    case 1: Elementary.Operations(SymbolsElementary.Addition, (inputVal1, inputVal2) => inputVal1 + inputVal2); break;
                    case 2: Elementary.Operations(SymbolsElementary.Subtraction, (inputVal1, inputVal2) => inputVal1 - inputVal2); break;
                    case 3: Elementary.Operations(SymbolsElementary.Multiplication, (inputVal1, inputVal2) => inputVal1 * inputVal2); break;
                    case 4: Elementary.Operations(SymbolsElementary.Division, (inputVal1, inputVal2) => inputVal1 / inputVal2); break;
                    case 5: Advanced.Exponentiation(SymbolsAdvanced.Exponentiation, (inputVal1, inputVal2) => Math.Pow(inputVal1, inputVal2)); break;
                    case 6: Advanced.Root(SymbolsAdvanced.Root, (inputVal1, inputVal2) => Math.Pow(inputVal2, 1.0 / inputVal1)); break;
                    case 7: Advanced.Factorial(SymbolsAdvanced.Factorial); break;
                    case 8: Advanced.Modulo(SymbolsAdvanced.Modulo, (inputVal1, inputVal2) => inputVal1 % inputVal2); break;
                    default: ConsoleHelper.WriteColored("\n❓ You have made an invalid transaction!", ConsoleColor.DarkRed); break;
                }
                ConsoleHelper.WaitingScreen();
            }
            catch (Exception ex)
            {
                ConsoleHelper.WriteColored($"\n ⚠️ An error has occured: {ex.Message}", ConsoleColor.DarkRed);
            }
        }
    }
}