using System;
using System.Collections.Generic;

public class ConsoleGui {
    public static bool Alive = true;
    public static int Length = 0;
    public static int Lines = 0;
    public static bool clearSelected = false;
    public static bool exitSelected = false;
    public static bool inputSelected = false;
    public static bool enterSelected = false;
    public static string inputString = "";
    public static int[] fakeCursorPosition = { 0, 0 };
    public static List<string> messages = new List<string>();
    public static int MSG_COUNT = 5;
    public static void draw() {
        //Draw Command Window
        ConsoleGui.WriteLine("|| - Commands");
        ConsoleGui.Write("|| ");
        ConsoleGui.Write("|{0}Clear | ", clearSelected ? " *" : " ");
        ConsoleGui.Write("|{0}Exit |", exitSelected ? " *" : " ");
        ConsoleGui.WriteLine();
        ConsoleGui.Write("|{0}Enter |", enterSelected ? " *" : " ");
        ConsoleGui.Write("|{0}", inputString);
        ConsoleGui.WriteLine("\n|| ---------");
        //Draw Message Window
        ConsoleGui.WriteLine("------------");
        ConsoleGui.WriteLine("|| - Messages");
        if (messages.Count > MSG_COUNT) {
            //display last MSG_COUNT number of messages
            for (int i = messages.Count - 1; i >= messages.Count - MSG_COUNT; i--) {
                ConsoleGui.WriteLine("{0} - {1}", i, messages[i]);
            }
        }
        else {
            //display messages
            for (int i = messages.Count - 1; i >= 0; i--) {
                ConsoleGui.WriteLine("{0} - {1}", i, messages[i]);
            }
        }
        ConsoleGui.WriteLine("|| ---------");
    }
    public static void input() {
        //Apply fakeCursor
        //[*,1] applies to command bar
        //  [0,1] applies to clear - [1,1] applies to exit
        //[*,2] applies to input bar
        //  [0,2] applies to enter, [1,2] applies to input string
        switch (ConsoleGui.fakeCursorPosition[1]) {
            case 1:
                switch (ConsoleGui.fakeCursorPosition[0]) {
                    case 0:
                        clearSelected = true;
                        break;
                    case 1:
                        exitSelected = true;
                        break;
                    default:
                        clearSelected = false;
                        exitSelected = false;
                        break;
                }
                break;
            case 2:
                switch (ConsoleGui.fakeCursorPosition[0]) {
                    case 0:
                        enterSelected = true;
                        break;
                    case 1:
                        inputSelected = true;
                        selectInput();
                        break;
                    default:
                        enterSelected = false;
                        inputSelected = false;
                        deselectInput();
                        break;
                }
                break;
            default:
                clearSelected = false;
                exitSelected = false;
                inputSelected = false;
                deselectInput();
                enterSelected = false;
                break;
        }
        while (Console.KeyAvailable) {
            ConsoleKeyInfo key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.UpArrow || key.Key == ConsoleKey.DownArrow) {
                if (key.Key == ConsoleKey.UpArrow)
                    ConsoleGui.fakeCursorPosition[1]--;
                if (key.Key == ConsoleKey.DownArrow)
                    ConsoleGui.fakeCursorPosition[1]++;
            }
            else if (key.Key == ConsoleKey.LeftArrow || key.Key == ConsoleKey.RightArrow) {
                if (key.Key == ConsoleKey.RightArrow)
                    ConsoleGui.fakeCursorPosition[0]++;
                if (key.Key == ConsoleKey.LeftArrow)
                    ConsoleGui.fakeCursorPosition[0]--;
            }
            else if (key.Key == ConsoleKey.Enter) {
                if (clearSelected)
                    ConsoleGui.messages.Clear();
                else if (exitSelected)
                    ConsoleGui.Alive = false;
                else if (enterSelected) {
                    messages.Add(inputString);
                    inputString = "";
                }
            }
            else if (key.Key == ConsoleKey.Backspace) {
                if (inputSelected) {
                    deselectInput();
                    if (inputString.Length > 0)
                        inputString = inputString.Substring(0, inputString.Length - 1);
                    selectInput();
                }
            }
            else {
                if (inputSelected) {
                    deselectInput();
                    inputString += key.KeyChar;
                    selectInput();
                }
            }
        }

        //clamp fakeCursor
        ConsoleGui.fakeCursorPosition[0] = Clamp(ConsoleGui.fakeCursorPosition[0], 0, 2);
        ConsoleGui.fakeCursorPosition[1] = Clamp(ConsoleGui.fakeCursorPosition[1], 0, 3);
    }
    public static int Clamp(int value, int min, int max) {
        if (value > max)
            return max;
        else if (value < min)
            return min;
        return value;
    }
    public static void selectInput() {
        if (inputString.Length == 0)
            inputString += '*';
        else {
            if (inputString[inputString.Length - 1] != '*') {
                inputString += '*';
            }
        }
    }
    public static void deselectInput() {
        if (inputString.Length != 0 && inputString[inputString.Length - 1] == '*')
            inputString = inputString.Substring(0, inputString.Length - 1);
    }
    public static void clear() {
        int top = Console.CursorTop - ConsoleGui.Lines;
        Console.SetCursorPosition(0, Console.CursorTop - ConsoleGui.Lines);
        //Console.Write(new string(' ', ConsoleGui.Length));
        for (int i = 0; i < ConsoleGui.Lines; i++) {
            Console.WriteLine(new string(' ', Console.WindowWidth));
        }
        Console.SetCursorPosition(0, top - 1);
        ConsoleGui.Lines = 0;
        ConsoleGui.Length = 0;
        enterSelected = false;
        exitSelected = false;
        inputSelected = false;
        deselectInput();
        clearSelected = false;
    }
    public static void WriteLine(string s) {
        ConsoleGui.Length += s.Length;
        ConsoleGui.Lines++;
        Console.WriteLine(s);
    }
    public static void WriteLine() {
        ConsoleGui.Lines++;
        ConsoleGui.Length++;
        Console.WriteLine();
    }
    public static void WriteLine(string format, params object[] args) {
        string s = String.Format(format, args);
        ConsoleGui.WriteLine(s);
    }
    public static void Write(string s) {
        ConsoleGui.Length += s.Length;
        Console.Write(s);
    }
    public static void Write(string format, params object[] args) {
        ConsoleGui.Write(String.Format(format, args));
    }
    public static void Main(string[] args) {
        int count = 0;
        int messagesAdded = 0;
        while(ConsoleGui.Alive) {
            ConsoleGui.input();
            ConsoleGui.draw();
            System.Threading.Thread.Sleep(50);
            ConsoleGui.clear();
            count++;
            if (count == 10) {
                ConsoleGui.messages.Add("Message " + messagesAdded);
                messagesAdded++;
                count = 0;
            }
        }
    }
}