namespace Calculator.Services
{
    public class Converters
    {
        public static void Operations()
        {
            var options = new (string text, ConsoleColor Color)[]
            {
                ( " 🔄 Unit Converters", ConsoleColor.White),
                ( $" {new string(' ', 40)}", ConsoleColor.White),
                ( " 1. Length (km <-> miles, m <-> feet)", ConsoleColor.Yellow),
                ( " 2. Weight (kg <-> lbs)", ConsoleColor.Yellow),
                ( " 3. Temperature (C <-> F <-> K)", ConsoleColor.Yellow),
                ( " 4. Go Back", ConsoleColor.Gray),
            };

            while (true)
            {
                ConsoleHelper.ClearScreen();
                foreach (var item in options)
                {
                    ConsoleHelper.WriteColored(item.text, item.Color);
                }

                byte inputVal = ConsoleHelper.GetInput<byte>("\n➡️ Enter your choice: ");

                if (inputVal == 4) return;

                if (inputVal < 1 || inputVal > 3)
                {
                    ConsoleHelper.WriteColored("\n❓ You have made an invalid transaction!", ConsoleColor.DarkRed);
                    ConsoleHelper.WaitingScreen();
                    continue;
                }

                ConsoleHelper.ClearScreen();

                switch (inputVal)
                {
                    case 1: Length(); break;
                    case 2: Weight(); break;
                    case 3: Temperature(); break;
                }

                ConsoleHelper.WaitingScreen();
            }
        }

        private static void Length()
        {
            ConsoleHelper.WriteColored(" 📏 Length Converter\n", ConsoleColor.Cyan);
            ConsoleHelper.WriteColored(" 1. Kilometers to Miles", ConsoleColor.White);
            ConsoleHelper.WriteColored(" 2. Miles to Kilometers", ConsoleColor.White);
            ConsoleHelper.WriteColored(" 3. Meters to Feet", ConsoleColor.White);
            ConsoleHelper.WriteColored(" 4. Feet to Meters", ConsoleColor.White);

            byte choice = ConsoleHelper.GetInput<byte>("\n👉 Choice: ");
            double value = 0;
            bool usePreviousResult = false;

            if (StateManager.LastResult.HasValue)
            {
                string? response = ConsoleHelper.GetInput<string>($"\n👉 The last result was {StateManager.LastResult.Value}. Do you want to use it? (Y/N): ", ConsoleColor.Yellow);
                if (response?.Trim().ToUpper() == "Y")
                {
                    value = StateManager.LastResult.Value;
                    usePreviousResult = true;
                }
            }

            if (!usePreviousResult)
            {
                value = ConsoleHelper.GetInput<double>("\n👉 Value: ");
            }
            double result = 0;
            string strResult = "";

            switch (choice)
            {
                case 1:
                    result = value * 0.621371;
                    strResult = $"{value} km = {result} miles";
                    break;
                case 2:
                    result = value / 0.621371;
                    strResult = $"{value} miles = {result} km";
                    break;
                case 3:
                    result = value * 3.28084;
                    strResult = $"{value} m = {result} feet";
                    break;
                case 4:
                    result = value / 3.28084;
                    strResult = $"{value} feet = {result} m";
                    break;
                default: throw new Exception("INVALID!");
            }
            ConsoleHelper.WriteColored($"\n✅ {strResult}", ConsoleColor.Green);
            History.Add(strResult);
        }

        private static void Weight()
        {
            ConsoleHelper.WriteColored(" ⚖️ Weight Converter\n", ConsoleColor.Cyan);
            ConsoleHelper.WriteColored(" 1. Kilograms to Pounds", ConsoleColor.White);
            ConsoleHelper.WriteColored(" 2. Pounds to Kilograms", ConsoleColor.White);

            byte choice = ConsoleHelper.GetInput<byte>("\n👉 Choice: ");
            double value = 0;
            bool usePreviousResult = false;

            if (StateManager.LastResult.HasValue)
            {
                string? response = ConsoleHelper.GetInput<string>($"\n👉 The last result was {StateManager.LastResult.Value}. Do you want to use it? (Y/N): ", ConsoleColor.Yellow);
                if (response?.Trim().ToUpper() == "Y")
                {
                    value = StateManager.LastResult.Value;
                    usePreviousResult = true;
                }
            }

            if (!usePreviousResult)
            {
                value = ConsoleHelper.GetInput<double>("\n👉 Value: ");
            }
            double result = 0;
            string strResult = "";

            switch (choice)
            {
                case 1:
                    result = value * 2.20462;
                    strResult = $"{value} kg = {result} lbs";
                    break;
                case 2:
                    result = value / 2.20462;
                    strResult = $"{value} lbs = {result} kg";
                    break;
                default: throw new Exception("INVALID!");
            }
            ConsoleHelper.WriteColored($"\n✅ {strResult}", ConsoleColor.Green);
            History.Add(strResult);
        }

        private static void Temperature()
        {
            ConsoleHelper.WriteColored(" 🌡️ Temperature Converter\n", ConsoleColor.Cyan);
            ConsoleHelper.WriteColored(" 1. Celsius to Fahrenheit", ConsoleColor.White);
            ConsoleHelper.WriteColored(" 2. Fahrenheit to Celsius", ConsoleColor.White);
            ConsoleHelper.WriteColored(" 3. Celsius to Kelvin", ConsoleColor.White);
            ConsoleHelper.WriteColored(" 4. Kelvin to Celsius", ConsoleColor.White);

            byte choice = ConsoleHelper.GetInput<byte>("\n👉 Choice: ");
            double value = 0;
            bool usePreviousResult = false;

            if (StateManager.LastResult.HasValue)
            {
                string? response = ConsoleHelper.GetInput<string>($"\n👉 The last result was {StateManager.LastResult.Value}. Do you want to use it? (Y/N): ", ConsoleColor.Yellow);
                if (response?.Trim().ToUpper() == "Y")
                {
                    value = StateManager.LastResult.Value;
                    usePreviousResult = true;
                }
            }

            if (!usePreviousResult)
            {
                value = ConsoleHelper.GetInput<double>("\n👉 Value: ");
            }
            double result = 0;
            string strResult = "";

            switch (choice)
            {
                case 1:
                    result = (value * 9 / 5) + 32;
                    strResult = $"{value}°C = {result}°F";
                    break;
                case 2:
                    result = (value - 32) * 5 / 9;
                    strResult = $"{value}°F = {result}°C";
                    break;
                case 3:
                    result = value + 273.15;
                    strResult = $"{value}°C = {result}K";
                    break;
                case 4:
                    result = value - 273.15;
                    strResult = $"{value}K = {result}°C";
                    break;
                default: throw new Exception("INVALID!");
            }
            ConsoleHelper.WriteColored($"\n✅ {strResult}", ConsoleColor.Green);
            History.Add(strResult);
        }
    }
}
