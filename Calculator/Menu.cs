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

            ( "\n 💾 Memory & Exit Operations", ConsoleColor.White),
            ( $" {new string(' ',40)}",ConsoleColor.White),
            ( " 11.Memory Operations", ConsoleColor.DarkGreen),
            ( " 12.Exit", ConsoleColor.DarkGreen),
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
            ( " 📐 Trigonometric operations", ConsoleColor.White),
            ( $" {new string(' ',40)}",ConsoleColor.White),
            ( " 1. Sine", ConsoleColor.Blue),
            ( " 2. Cosine", ConsoleColor.Blue),
            ( " 3. Tangent", ConsoleColor.Blue),
            ( " 4. Cotangent", ConsoleColor.Blue),
            ( " 5. Secant", ConsoleColor.Blue),
            ( " 6. Cosecant", ConsoleColor.Blue),
    };

        foreach (var item in trigonometryItems)
        {
            ConsoleHelper.WriteColored(item.text, item.Color);
        }
    }
}
