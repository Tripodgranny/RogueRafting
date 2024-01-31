using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueRafting.Util
{
    public class Tag
    {
        public readonly String name;

        private Tag (string name)
        {
            this.name = name;
        }

        public static readonly Tag DEFAULT = new Tag("Default");
        public static readonly Tag PLAYER = new Tag("Player");
    }

}
