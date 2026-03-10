using Calculator.UI;

namespace Calculator.Services
{
    public class Memory
    {
        private static double _memoryValue = 0;

        public static void Operations()
        {
            while (true)
            {
                ConsoleHelper.ClearScreen();
                Menu.MemoryMenu();

                byte inputVal = ConsoleHelper.GetInput<byte>("\n➡️ Enter the operation you wish to perform numerically: ");

                if (inputVal == 5) return;

                if (inputVal < 1 || inputVal > 4)
                {
                    ConsoleHelper.WriteColored("\n❓ You have made an invalid transaction!", ConsoleColor.DarkRed);
                    ConsoleHelper.WaitingScreen();
                    continue;
                }

                ConsoleHelper.ClearScreen();
                SymbolsMemory operationType = (SymbolsMemory)(inputVal - 1);

                double inputNumber = 0;
                if (operationType == SymbolsMemory.MemoryAdd || operationType == SymbolsMemory.MemorySubtract)
                {
                    bool usePreviousResult = false;
                    if (StateManager.LastResult.HasValue)
                    {
                        string? response = ConsoleHelper.GetInput<string>($"👉 The last result was {StateManager.LastResult.Value}. Do you want to use it? (Y/N): ", ConsoleColor.Yellow);
                        if (response?.Trim().ToUpper() == "Y")
                        {
                            inputNumber = StateManager.LastResult.Value;
                            usePreviousResult = true;
                        }
                    }

                    if (!usePreviousResult)
                    {
                        inputNumber = ConsoleHelper.GetInput<double>("\n👉 Enter the number: ");
                    }
                }

                switch (operationType)
                {
                    case SymbolsMemory.MemoryAdd:
                        _memoryValue += inputNumber;
                        ConsoleHelper.WriteColored($"\n✅ Added {inputNumber} to memory. Current Memory: {_memoryValue}", ConsoleColor.Green);
                        break;
                    case SymbolsMemory.MemorySubtract:
                        _memoryValue -= inputNumber;
                        ConsoleHelper.WriteColored($"\n✅ Subtracted {inputNumber} from memory. Current Memory: {_memoryValue}", ConsoleColor.Green);
                        break;
                    case SymbolsMemory.MemoryRecall:
                        ConsoleHelper.WriteColored($"\n💾 Memory Recall (MR): {_memoryValue}", ConsoleColor.Blue);
                        break;
                    case SymbolsMemory.MemoryClear:
                        _memoryValue = 0;
                        ConsoleHelper.WriteColored("\n🗑️ Memory Cleared (MC).", ConsoleColor.Green);
                        break;
                }

                ConsoleHelper.WaitingScreen();
            }
        }
    }
}
