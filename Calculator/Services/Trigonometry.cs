namespace Calculator.Services
{
    public class Trigonometry
    {
        public static void Operations()
        {
            Menu.TrigonometryMenu();

            byte inputVal = ConsoleHelper.GetInput<byte>("\n➡️ Enter the operation you wish to perform numerically: ");
            Console.Clear();

            if (inputVal < 1 || inputVal > 6)
                throw new Exception("INVALID!");

            double degree = ConsoleHelper.GetInput<double>("👉 Enter the degree: ");
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

            ConsoleHelper.WriteColored($"\n✅ {symbol}{inputVal1}° = {result}", ConsoleColor.Green);
            return result;
        }
    }
}
