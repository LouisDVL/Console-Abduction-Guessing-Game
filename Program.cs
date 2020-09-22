using System;

namespace Spaceman
{
  class Program
  {
    static void Main(string[] args)
    {
            Game g = new Game();
            g.Greet();
            while(g.DidWin() != true && g.DidLose() != true)
            {
                g.Display();
                g.Ask();
            }
    }
  }
}
