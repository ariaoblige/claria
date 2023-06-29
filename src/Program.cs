using System;
using System.Collections.Generic;
using System.Reflection;
using System.IO;

namespace arialibs {
  public class MainProg {
    public static void Main(String[] args) {
      string[] cmds = new string[] {
        "compile",
        "create",
        "aria",
        "list",
      };
      
      Console.OutputEncoding = System.Text.Encoding.Unicode;
      Dictionary<string, Action> ops = new Dictionary<string, Action>();

      ops.Add(cmds[0], () => Functions.Compile());
      ops.Add(cmds[1], () => Functions.Create());
      ops.Add(cmds[2], () => Functions.AriaCmd());
      ops.Add(cmds[3], () => Functions.List());

      Dictionary<string, string> hlp = new Dictionary<string, string>();
  
      hlp.Add(cmds[0], "Compiles a file written in C, C++, C# or Java.");
      hlp.Add(cmds[1], "Creates a new file.");
      hlp.Add(cmds[3], "Lists files and directories.");

      if (args.Length > 0) {
        try {
          ops[args[0]]();
        }
        catch {
          Visuals.WriteColor("Not a valid command.", ConsoleColor.Red);
          Subfn.Aria(1);
        }
      }
      else {
        foreach(var h in hlp) {
          Visuals.WriteColor(h.Key, ConsoleColor.Yellow);
          Visuals.WriteColor("    "+h.Value, ConsoleColor.Blue);
          Console.WriteLine();
        }
        Subfn.Aria(0);
      }
    }
  }
}

