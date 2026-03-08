using Calculator.UI;

namespace Calculator.Services
{
    public class Trigonometry
    {
        public static void Operations()
        {
            while (true)
            {
                ConsoleHelper.ClearScreen();
                Menu.TrigonometryMenu();

                byte inputVal = ConsoleHelper.GetInput<byte>("➡️ Enter the operation you wish to perform numerically: ");

                if (inputVal == 7) return;

                if (inputVal < 1 || inputVal > 6)
                {
                    ConsoleHelper.WriteColored("\n❓ You have made an invalid transaction!", ConsoleColor.DarkRed);
                    ConsoleHelper.WaitingScreen();
                    continue;
                }

                ConsoleHelper.ClearScreen();

                double degree = 0;
                bool usePreviousResult = false;

                if (StateManager.LastResult.HasValue)
                {
                    string? response = ConsoleHelper.GetInput<string>($"\n👉 The last result was {StateManager.LastResult.Value}. Do you want to use it as the degree? (Y/N): ", ConsoleColor.Yellow);
                    if (response?.Trim().ToUpper() == "Y")
                    {
                        degree = StateManager.LastResult.Value;
                        usePreviousResult = true;
                    }
                }

                if (!usePreviousResult)
                {
                    degree = ConsoleHelper.GetInput<double>("👉 Enter the degree: ");
                }

                double radian = DegreeToRadian(degree);

                SymbolsTrigonometry operationType = (SymbolsTrigonometry)(inputVal - 1);

                double result = operationType switch
                {
                    SymbolsTrigonometry.Sine => Math.Sin(radian),
                    SymbolsTrigonometry.Cosine => Math.Cos(radian),
                    SymbolsTrigonometry.Tangent => Math.Tan(radian),
                    SymbolsTrigonometry.Cotangent => 1.0 / Math.Tan(radian),
                    SymbolsTrigonometry.Secant => 1.0 / Math.Cos(radian),
                    SymbolsTrigonometry.Cosecant => 1.0 / Math.Sin(radian),
                    _ => throw new Exception("Unknown operation")
                };

                ShowResult(degree, result, operationType);
                ConsoleHelper.WaitingScreen();
            }
        }

        public static double DegreeToRadian(double degree)
        {
            return degree * (Math.PI / 180);
        }


        public static double ShowResult(double inputVal1, double result, SymbolsTrigonometry operationType)
        {
            string symbol = operationType switch
            {
                SymbolsTrigonometry.Sine => "Sin",
                SymbolsTrigonometry.Cosine => "Cos",
                SymbolsTrigonometry.Tangent => "Tan",
                SymbolsTrigonometry.Cotangent => "Cot",
                SymbolsTrigonometry.Secant => "Sec",
                SymbolsTrigonometry.Cosecant => "Cosc",
                _ => "?",
            };

            string resStr = $"{symbol}{inputVal1}° = {result}";
            ConsoleHelper.WriteColored($"\n✅ {resStr}", ConsoleColor.Green);
            History.Add(resStr);
            return result;
        }
    }
}
