namespace Calculator.Services
{
    public static class History
    {
        private static readonly List<string> _history = new List<string>();

        public static void Add(string record)
        {
            _history.Add(record);
        }

        public static void Show()
        {
            ConsoleHelper.WriteColored(" 📜 Calculation History", ConsoleColor.Cyan);
            ConsoleHelper.WriteColored($" {new string(' ', 20)}", ConsoleColor.Cyan);

            if (_history.Count == 0)
            {
                ConsoleHelper.WriteColored(" 📭 History is empty.", ConsoleColor.DarkGray);
                return;
            }

            for (int i = 0; i < _history.Count; i++)
            {
                ConsoleHelper.WriteColored($" {i + 1}. {_history[i]}", ConsoleColor.White);
            }

            ConsoleHelper.WriteColored($" {new string(' ', 40)}", ConsoleColor.Cyan);
        }

        public static void Clear()
        {
            _history.Clear();
            ConsoleHelper.WriteColored("\n 🗑️ History Cleared.", ConsoleColor.Green);
        }
    }
}
