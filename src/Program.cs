using System;
using System.Collections.Generic;
using System.Reflection;
using System.IO;

namespace arialibs {
  public class MainProg {
    public static void Main(String[] args) {
      List<string[]> cmds = new List<string[]>() { };

      cmds.Add(new string[] { "compile", "cp" });
      cmds.Add(new string[] { "create", "touch" });
      cmds.Add(new string[] { "aria" });
      cmds.Add(new string[] { "list", "ls" });
      cmds.Add(new string[] { "cmd", "c" });
      
      Console.OutputEncoding = System.Text.Encoding.Unicode;
      Dictionary<string[], Action> ops = new Dictionary<string[], Action>();

      ops.Add(cmds[0], () => Functions.Compile());
      ops.Add(cmds[1], () => Functions.Create());
      ops.Add(cmds[2], () => Functions.AriaCmd());
      ops.Add(cmds[3], () => Functions.List());
      ops.Add(cmds[4], () => Functions.Cmd());

      Dictionary<string[], string> hlp = new Dictionary<string[], string>();
  
      hlp.Add(cmds[0], "Compiles a file written in C, C++, C# or Java (Requires GCC/CSC/JDK).");
      hlp.Add(cmds[1], "Creates a new file.");
      hlp.Add(cmds[3], "Lists files and directories.");
      hlp.Add(cmds[4], "Executes a given cmd command.");
      
      string[] exec     = new string[] { };

      if (args.Length > 0) {
        // Check args
        foreach(var cmd in cmds) {
          foreach(var alias in cmd) {
            if(args[0]==alias) {
              exec=cmd;
            }
          }
        }

        try {
          ops[exec]();
        }
        catch {
          Visuals.WriteColor("Not a valid command.", ConsoleColor.Red);
          Subfn.Aria(1);
        }
      }
      else {
        foreach(var h in hlp) {
          for(var c=0; c<h.Key.Length; c++) {
            if (c==0) {
              Visuals.WriteColor(h.Key[c], ConsoleColor.Yellow);
            }
            else if (c==1) {
              if (c==h.Key.Length-1) {
                Visuals.WriteColorN("aliases: "+h.Key[c]+"\n", ConsoleColor.DarkGray);
              }
              else {
                Visuals.WriteColorN("aliases: "+h.Key[c], ConsoleColor.DarkGray);
              }
            }
            else if (c==h.Key.Length-1){
              Visuals.WriteColorN(h.Key[c]+"\n", ConsoleColor.DarkGray);
            }
            else {
              Visuals.WriteColorN(", "+h.Key[c], ConsoleColor.DarkGray);
            }
          }
          Visuals.WriteColor("    "+h.Value, ConsoleColor.Blue);
          Console.WriteLine();
        }
        Subfn.Aria(0);
      }
    }
  }
}

