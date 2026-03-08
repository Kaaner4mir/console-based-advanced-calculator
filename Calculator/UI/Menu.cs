public class Menu
{
    public static void MainMenu()
    {
        var mainMenuItems = new (string text, ConsoleColor Color)[]
    {
            ( " 🧮 Elementary Operations", ConsoleColor.White),
            ( $" {new string(' ',40)}",ConsoleColor.White),
            ( " 1. Addition", ConsoleColor.Blue),
            ( " 2. Subtraction", ConsoleColor.Blue),
            ( " 3. Multiplication", ConsoleColor.Blue),
            ( " 4. Division", ConsoleColor.Blue),

            ( "\n 🔢 Advanced Mathematical Operations", ConsoleColor.White),
            ( $" {new string(' ',40)}",ConsoleColor.White),
            ( " 5. Exponentiation", ConsoleColor.DarkYellow),
            ( " 6. Root", ConsoleColor.DarkYellow),
            ( " 7. Factorial", ConsoleColor.DarkYellow),
            ( " 8. Modulo", ConsoleColor.DarkYellow),

            ( "\n 📐 Trigonometric & Logarithmic Functions", ConsoleColor.White),
            ( $" {new string(' ',40)}",ConsoleColor.White),
            ( " 9. Trigonometric Functions", ConsoleColor.DarkRed),
            ( " 10.Logarithmic Functions", ConsoleColor.DarkRed),

            ( "\n 💾 Additional & Memory Operations", ConsoleColor.White),
            ( $" {new string(' ',40)}",ConsoleColor.White),
            ( " 11.Equation Solver", ConsoleColor.DarkMagenta),
            ( " 12.Statistics", ConsoleColor.DarkMagenta),
            ( " 13.Unit Converters", ConsoleColor.DarkMagenta),
            ( " 14.View History\n", ConsoleColor.DarkMagenta),
            ( " 15.Memory Operations", ConsoleColor.DarkGreen),
            ( " 16.Exit", ConsoleColor.DarkGreen),
    };

        foreach (var item in mainMenuItems)
        {
            ConsoleHelper.WriteColored(item.text, item.Color);
        }
    }

    public static void TrigonometryMenu()
    {
        var trigonometryItems = new (string text, ConsoleColor Color)[]
    {
            ( " 📐 Trigonometric Operations", ConsoleColor.White),
            ( $" {new string(' ',40)}",ConsoleColor.White),
            ( " 1. Sine", ConsoleColor.DarkRed),
            ( " 2. Cosine", ConsoleColor.DarkRed),
            ( " 3. Tangent", ConsoleColor.DarkRed),
            ( " 4. Cotangent", ConsoleColor.DarkRed),
            ( " 5. Secant", ConsoleColor.DarkRed),
            ( " 6. Cosecant", ConsoleColor.DarkRed),
            ( " 7. Go Back", ConsoleColor.Gray),
    };

        foreach (var item in trigonometryItems)
        {
            ConsoleHelper.WriteColored(item.text, item.Color);
        }
    }

    public static void LogarithmMenu()
    {
        var logarithmItems = new (string text, ConsoleColor Color)[]
    {
            ( " 📏 Logarithmic Operations", ConsoleColor.White),
            ( $" {new string(' ',40)}",ConsoleColor.White),
            ( " 1. Logarithm to a specified base", ConsoleColor.DarkRed),
            ( " 2. Natural Logarithm", ConsoleColor.DarkRed),
            ( " 3. Common Logarithm", ConsoleColor.DarkRed),
            ( " 4. Binary Logarithm", ConsoleColor.DarkRed),
            ( " 5. Go Back", ConsoleColor.Gray),
    };

        foreach (var item in logarithmItems)
        {
            ConsoleHelper.WriteColored(item.text, item.Color);
        }
    }

    public static void MemoryMenu()
    {
        var memoryItems = new (string text, ConsoleColor Color)[]
        {
            ( " 💾 Memory Operations", ConsoleColor.White),
            ( $" {new string(' ', 40)}", ConsoleColor.White),
            ( " 1. Memory Add (M+)", ConsoleColor.DarkGreen),
            ( " 2. Memory Subtract (M-)", ConsoleColor.DarkGreen),
            ( " 3. Memory Recall (MR)", ConsoleColor.DarkGreen),
            ( " 4. Memory Clear (MC)", ConsoleColor.DarkGreen),
            ( " 5. Go Back", ConsoleColor.Gray),
        };

        foreach (var item in memoryItems)
        {
            ConsoleHelper.WriteColored(item.text, item.Color);
        }
    }
}
