using System;

namespace arialibs {
  public class Visuals {
    public static void WriteColorN(string write, ConsoleColor fg=ConsoleColor.Gray, ConsoleColor bg=ConsoleColor.Black) {
      Console.ForegroundColor = fg;
      Console.BackgroundColor = bg;
      Console.Write(write);
      Console.ResetColor();
    }


    public static void WriteColor(string write, ConsoleColor fg=ConsoleColor.Gray, ConsoleColor bg=ConsoleColor.Black) {
      Console.ForegroundColor = fg;
      Console.BackgroundColor = bg;
      Console.WriteLine(write);
      Console.ResetColor();
    }


    public static void ChangeColor(ConsoleColor fg=ConsoleColor.Gray, ConsoleColor bg=ConsoleColor.Black) {
      Console.ForegroundColor = fg;
      Console.BackgroundColor = bg;
    }
  }
}
