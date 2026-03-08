using Calculator.UI;

namespace Calculator.Services
{
    public class EquationSolver
    {
        public static void Operations()
        {
            var options = new (string text, ConsoleColor Color)[]
            {
                ( " 📐 Equation Solver", ConsoleColor.White),
                ( $" {new string(' ', 40)}", ConsoleColor.White),
                ( " 1. Linear (ax + b = 0)", ConsoleColor.Yellow),
                ( " 2. Quadratic (ax² + bx + c = 0)", ConsoleColor.Yellow),
                ( " 3. Go Back", ConsoleColor.Gray),
            };

            while (true)
            {
                ConsoleHelper.ClearScreen();
                foreach (var item in options)
                {
                    ConsoleHelper.WriteColored(item.text, item.Color);
                }

                byte inputVal = ConsoleHelper.GetInput<byte>("\n ➡️ Enter your choice: ");

                if (inputVal == 3) return;

                if (inputVal < 1 || inputVal > 2)
                {
                    ConsoleHelper.WriteColored("\n❓ You have made an invalid transaction!", ConsoleColor.DarkRed);
                    ConsoleHelper.WaitingScreen();
                    continue;
                }

                ConsoleHelper.ClearScreen();

                switch (inputVal)
                {
                    case 1:
                        Linear();
                        break;
                    case 2:
                        Quadratic();
                        break;
                }

                ConsoleHelper.WaitingScreen();
            }
        }

        private static void Linear()
        {
            ConsoleHelper.WriteColored(" Solving ax + b = 0\n", ConsoleColor.Cyan);
            double a = ConsoleHelper.GetInput<double>("👉 Enter 'a': ");
            double b = ConsoleHelper.GetInput<double>("👉 Enter 'b': ");

            if (a == 0)
            {
                if (b == 0)
                {
                    ConsoleHelper.WriteColored("\n✅ Infinite solutions (0 = 0)", ConsoleColor.Green);
                    History.Add("Linear: 0x + 0 = 0 -> Infinite solutions");
                }
                else
                {
                    ConsoleHelper.WriteColored("\n❌ No solution (contradiction)", ConsoleColor.Red);
                    History.Add($"Linear: 0x + {b} = 0 -> No solution");
                }
                return;
            }

            double x = -b / a;
            string resStr = $"Linear: {a}x + {b} = 0 -> x = {x}";
            ConsoleHelper.WriteColored($"\n✅ x = {x}", ConsoleColor.Green);
            History.Add(resStr);
        }

        private static void Quadratic()
        {
            ConsoleHelper.WriteColored(" Solving ax² + bx + c = 0\n", ConsoleColor.Cyan);
            double a = ConsoleHelper.GetInput<double>("👉 Enter 'a' (must not be 0): ");

            if (a == 0)
            {
                ConsoleHelper.WriteColored("\n⚠️ 'a' cannot be 0 in a quadratic equation. Attempting linear solve instead.", ConsoleColor.Yellow);
                Linear();
                return;
            }

            double b = ConsoleHelper.GetInput<double>("👉 Enter 'b': ");
            double c = ConsoleHelper.GetInput<double>("👉 Enter 'c': ");

            double delta = Math.Pow(b, 2) - 4 * a * c;

            if (delta > 0)
            {
                double root1 = (-b + Math.Sqrt(delta)) / (2 * a);
                double root2 = (-b - Math.Sqrt(delta)) / (2 * a);
                string resStr = $"Quadratic: {a}x² + {b}x + {c} = 0 -> x1 = {root1}, x2 = {root2}";
                ConsoleHelper.WriteColored($"\n✅ Two distinct real roots: x1 = {root1}, x2 = {root2}", ConsoleColor.Green);
                History.Add(resStr);
            }
            else if (delta == 0)
            {
                double root = -b / (2 * a);
                string resStr = $"Quadratic: {a}x² + {b}x + {c} = 0 -> x = {root} (double root)";
                ConsoleHelper.WriteColored($"\n✅ One double real root: x = {root}", ConsoleColor.Green);
                History.Add(resStr);
            }
            else
            {
                double realPart = -b / (2 * a);
                double imaginaryPart = Math.Sqrt(-delta) / (2 * a);
                string root1Str = $"{realPart} + {imaginaryPart}i";
                string root2Str = $"{realPart} - {imaginaryPart}i";
                string resStr = $"Quadratic: {a}x² + {b}x + {c} = 0 -> x1 = {root1Str}, x2 = {root2Str}";
                ConsoleHelper.WriteColored($"\n✅ Two complex roots: x1 = {root1Str}, x2 = {root2Str}", ConsoleColor.Green);
                History.Add(resStr);
            }
        }
    }
}
