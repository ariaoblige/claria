using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace arialibs {
  public class Functions {

    public static void Compile() {
      var args = Environment.GetCommandLineArgs();
      if (!args[2].Contains(".")) {
        Visuals.WriteColor("Expected a file extension.", ConsoleColor.Red);
        Subfn.Aria(1);
      }
      else {
        string[] programName = args[2].Split('.');

        if (args.Length==3) {
          var extList = new List<string[]>();

          extList.Add(new string[] { "java" });
          extList.Add(new string[] { "c" });
          extList.Add(new string[] { "cs" });
          extList.Add(new string[] { "cc", "cpp" });

          var commandDict = new Dictionary<string[], string>() { };
          commandDict.Add(extList[0], "javac "+args[2]);
          commandDict.Add(extList[1], "gcc -o "+programName[0]+" "+args[2]);
          commandDict.Add(extList[2], "csc "+args[2]);
          commandDict.Add(extList[3], "gcc -o "+programName[0]+" "+args[2]+" -lstdc++");

          var err = true;
          string[] run = new string[] { };
          string ext="";

          foreach(var value in extList) {
            foreach (string extension in value) {
              if (extension==programName[1]) {
                ext = extension;
                run = value;
                err = false;
              }
            }
          }
          if (!err) {
            Subfn.Run(commandDict[run]);
            Subfn.Aria(2);
          }
          else {
            Visuals.WriteColor("Extension not recognized.", ConsoleColor.Red);
            Subfn.Aria(1);
          }
        }
        else {
          Visuals.WriteColor("Expected a file name.", ConsoleColor.Red);
          Subfn.Aria(1);
        }
      }
    }


    public static void Create() {
      var args = Environment.GetCommandLineArgs();
      var err  = false;

      try {
        string filename = args[2];
      }
      catch {
        Visuals.WriteColor("Expected a file name.", ConsoleColor.Red);
        err=true;
        Subfn.Aria(1);
      }
      if (!err) {
        string filename = args[2];
        File.Create(Directory.GetCurrentDirectory()+"/"+filename);
        Visuals.WriteColor("Successfully created file '"+filename+"'.", ConsoleColor.Green);
        Subfn.Aria(0);
      }
    }
    

    public static void AriaCmd() {
      var rnd = new Random();
      int gen = rnd.Next(0, 2);
      Visuals.WriteColor(new string[] { "ok", "blz" }[gen], ConsoleColor.Blue);
    }


    public static void List() {
      Visuals.ChangeColor(ConsoleColor.Cyan);
      foreach(var dir in Directory.GetDirectories(Directory.GetCurrentDirectory())) {
        Console.WriteLine("\uf07b "+Subfn.GetName(dir));
      }
      Visuals.ChangeColor(ConsoleColor.Magenta);
      foreach(var file in Directory.GetFiles(Directory.GetCurrentDirectory())) {
        Console.WriteLine("\udb80\ude14 "+Subfn.GetName(file));
      }
      Console.ResetColor();
      Console.WriteLine();
      Subfn.Aria(0);
    }


    public static void Cmd() {
      var args = Environment.GetCommandLineArgs();
      
      if (args.Length>2) {
        string comando = "";
        
        for(int c=2; c<args.Length; c++) {
          comando+=args[c]+" ";
        }

        Subfn.Run(comando);
        Subfn.Aria(2);
      }
      else {
        Visuals.WriteColor("No command given.", ConsoleColor.Red);
        Subfn.Aria(1);
      }
    }
  }
}
