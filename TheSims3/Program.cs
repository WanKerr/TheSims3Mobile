using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sims3;

class Program
{
    static void Main(string[] args)
    {
        using (var game = new TheSims3())
        {
            game.Run();
        }
    }
}

