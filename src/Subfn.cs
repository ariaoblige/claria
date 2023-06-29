using System;
using System.Diagnostics;

 /*
 * SUBFN
 *
 * File meant for functions used in the arialibs.Functions namespace.
 * 
 */

namespace arialibs {
  public class Subfn {
    public static void Run(string command) {
      ProcessStartInfo pcss = new ProcessStartInfo("cmd.exe", "/C "+command);
      pcss.UseShellExecute = false;
      var pcssExec = Process.Start(pcss);
      pcssExec.WaitForExit();
    }


    public static string GetName(string dirf) {
      var dir = dirf.Split('\\');

      return dir[dir.Length-1];
    }


    public static void Aria(int which) {
      string[] error = new string[] {
        "uma hora vai n desiste :D",
        "continua tentando vc consegue <3",
        "vc consegue tudo se vc se esforcar <33",
        "n desiste eu confio em vc",
        "apesar de tudo eu ainda confio em vc <3",
        "n se preocupa p mim vc e incrivel <3",
        "acontece vai passar :D",
        "pelo menos vc tentou e isso e oq importa :3",
        "nem smp tudo da certo mas e so vc continuar tentando <33",
      };
      string[] success = new string[] {
        "smp confiei q vc ia conseguir <3",
        "vc e incrivel <333",
        "to mto orgulhosa de vc <3",
        "parabens <33",
        "vc e incrivel nisso to mt feliz por vc <3",
        "vc e uma das pessoas mais incriveis q conheco <3",
        "sempre seja vc mesmo <3",
        "se vc persistir vc e capaz de tudo <333",
        "vc e capaz de ir mto longe <3",
      };
      string[] neutral = new string[] {
        "tentei o meu melhor <3",
        "aq <3",
        "se pcsar de qlq coisa me chama :D",
        "espero q seja o suficiente pra vc <3",
        "oq vc acha :3",
        "oiiiiii :D",
        "aq oq vc me pediu <3",
        "<3",
        "fiz oq sei espero q esteja legal <3",
      };
      
      var rnd = new Random();
      int generated = rnd.Next(0, 9);

      Console.ForegroundColor = ConsoleColor.Blue;
      switch (which) {
        case 0:
          Console.WriteLine(success[generated]);
          break;
        case 1:
          Console.WriteLine(error[generated]);
          break;
        case 2:
          Console.WriteLine(neutral[generated]);
          break;
      }
      Console.ResetColor();
    }
  }
}
