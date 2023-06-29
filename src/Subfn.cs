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
        "uma hora vai",
        "continua tentando",
        "vc consegue",
        "n desiste",
        "confio em vc",
        "rlx p mim vc e incrivel <3",
        "acontece",
        "pelo menos vc tentou",
        "nem smp tudo da certo mas e so vc continuar tentando <33",
      };
      string[] success = new string[] {
        "smp confiei q vc ia conseguir <3",
        "eu disse vc e incrivel",
        "to mto orgulhosa de vc",
        "parabens <33",
        "vc manda muito serio msm",
        "isso comprova o meu ponto vc e mto foda",
        "sempre seja vc mesmo",
        "se vc persistir vc e capaz de tudo <333",
        "vc e capaz de ir mto longe",
      };
      string[] neutral = new string[] {
        "tentei o meu melhor nisso",
        "aq <3",
        "se pcsar de qlq coisa me chama",
        "n sei se ficou bom da uma olhada ai",
        "oq vc acha",
        "oiiiiii",
        "tentei isso aq se liga",
        "da uma olhada nisso aq",
        "consegui isso aq se liga",
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
