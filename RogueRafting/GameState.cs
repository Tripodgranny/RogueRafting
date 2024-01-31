using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueRafting
{
    internal class GameState
    {
        public static State state;

        public enum State
        {
            Running,
            Paused
        }
    }
}
