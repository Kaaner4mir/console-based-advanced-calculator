using Calculator.UI;

namespace Calculator.Services
{
    public class Statistics
    {
        public static void Operations()
        {
            var options = new (string text, ConsoleColor Color)[]
            {
                ( " 📊 Statistics Operations", ConsoleColor.White),
                ( $" {new string(' ', 40)}", ConsoleColor.White),
                ( " 1. Mean (Average)", ConsoleColor.Magenta),
                ( " 2. Median", ConsoleColor.Magenta),
                ( " 3. Mode", ConsoleColor.Magenta),
                ( " 4. Standard Deviation", ConsoleColor.Magenta),
                ( " 5. Go Back", ConsoleColor.Gray),
            };

            while (true)
            {
                ConsoleHelper.ClearScreen();
                foreach (var item in options)
                {
                    ConsoleHelper.WriteColored(item.text, item.Color);
                }

                byte inputVal = ConsoleHelper.GetInput<byte>("\n ➡️ Enter your choice: ");

                if (inputVal == 5) return;

                if (inputVal < 1 || inputVal > 4)
                {
                    ConsoleHelper.WriteColored("\n❓ You have made an invalid transaction!", ConsoleColor.DarkRed);
                    ConsoleHelper.WaitingScreen();
                    continue;
                }

                ConsoleHelper.ClearScreen();

                List<double> numbers = GetNumberList();

                if (numbers.Count == 0)
                {
                    ConsoleHelper.WriteColored("\n⚠️ You must enter at least one number.", ConsoleColor.Yellow);
                    ConsoleHelper.WaitingScreen();
                    continue;
                }

                switch (inputVal)
                {
                    case 1:
                        double mean = numbers.Average();
                        ConsoleHelper.WriteColored($"\n✅ Mean: {mean}", ConsoleColor.Green);
                        History.Add($"Stats Mean of [{string.Join(", ", numbers)}] = {mean}");
                        break;
                    case 2:
                        numbers.Sort();
                        double median = numbers.Count % 2 == 0
                            ? (numbers[numbers.Count / 2 - 1] + numbers[numbers.Count / 2]) / 2.0
                            : numbers[numbers.Count / 2];
                        ConsoleHelper.WriteColored($"\n✅ Median: {median}", ConsoleColor.Green);
                        History.Add($"Stats Median of [{string.Join(", ", numbers)}] = {median}");
                        break;
                    case 3:
                        var modeGroups = numbers.GroupBy(n => n).OrderByDescending(g => g.Count());
                        double mode = modeGroups.First().Key;
                        int maxCount = modeGroups.First().Count();
                        ConsoleHelper.WriteColored($"\n✅ Mode: {mode} (appears {maxCount} times)", ConsoleColor.Green);
                        History.Add($"Stats Mode of [{string.Join(", ", numbers)}] = {mode}");
                        break;
                    case 4:
                        double avg = numbers.Average();
                        double sumOfSquaresOfDifferences = numbers.Sum(val => (val - avg) * (val - avg));
                        double standardDeviation = Math.Sqrt(sumOfSquaresOfDifferences / numbers.Count);
                        ConsoleHelper.WriteColored($"\n✅ Standard Deviation: {standardDeviation}", ConsoleColor.Green);
                        History.Add($"Stats StdDev of [{string.Join(", ", numbers)}] = {standardDeviation}");
                        break;
                }

                ConsoleHelper.WaitingScreen();
            }
        }

        private static List<double> GetNumberList()
        {
            List<double> numbers = new List<double>();
            ConsoleHelper.WriteColored("👉 Enter numbers one by one. Type 'q' to stop and calculate.\n", ConsoleColor.Cyan);

            while (true)
            {
                ConsoleHelper.WriteColored($" Enter number {numbers.Count + 1}: ", ConsoleColor.White, false);
                string? input = Console.ReadLine();

                if (input?.Trim().ToLower() == "clear")
                {
                    ConsoleHelper.ClearScreen();
                    ConsoleHelper.WriteColored("👉 Enter numbers one by one. Type 'q' to stop and calculate.\n", ConsoleColor.Cyan);
                    continue;
                }

                if (input?.Trim().ToLower() == "q")
                {
                    break;
                }

                if (double.TryParse(input, out double num))
                {
                    numbers.Add(num);
                }
                else
                {
                    ConsoleHelper.WriteColored(" ⚠️ Invalid number. Try again.", ConsoleColor.Red);
                }
            }
            return numbers;
        }
    }
}
