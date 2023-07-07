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
      cmds.Add(new string[] { "remove", "rm", "rmdir", "del" });
      cmds.Add(new string[] { "listar", "gstar", "gst" });
      cmds.Add(new string[] { "addstar", "star", "st" });
      cmds.Add(new string[] { "gostar", "goto", "cd" });
      
      Console.OutputEncoding = System.Text.Encoding.Unicode;
      Dictionary<string[], Action> ops = new Dictionary<string[], Action>();

      ops.Add(cmds[0], () => Functions.Compile());
      ops.Add(cmds[1], () => Functions.Create());
      ops.Add(cmds[2], () => Functions.AriaCmd());
      ops.Add(cmds[3], () => Functions.List());
      ops.Add(cmds[4], () => Functions.Cmd());
      ops.Add(cmds[5], () => Functions.Remove());
      ops.Add(cmds[6], () => Functions.GetStars());
      ops.Add(cmds[7], () => Functions.AddStar());
      ops.Add(cmds[8], () => Functions.GoThere());

      Dictionary<string[], string> hlp = new Dictionary<string[], string>();
  
      hlp.Add(cmds[0], "Compiles a file written in C, C++, C# or Java (Requires GCC/CSC/JDK).");
      hlp.Add(cmds[1], "Creates a new file.");
      hlp.Add(cmds[3], "Lists files and directories.");
      hlp.Add(cmds[4], "Executes a given cmd command.");
      hlp.Add(cmds[5], "Deletes a given file or directory.");
      hlp.Add(cmds[6], "Lists every starred directory.");
      hlp.Add(cmds[7], "Adds the current directory to the stars list with a given name");
      hlp.Add(cmds[8], "Opens a new console window with the directory set to the given star name.");

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
        catch (Exception e){
          Visuals.WriteColor("Not a valid command.", ConsoleColor.Red);
          Console.WriteLine(e);
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
              Visuals.WriteColorN(", "+h.Key[c]+"\n", ConsoleColor.DarkGray);
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

