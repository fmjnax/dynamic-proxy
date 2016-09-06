using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleTriadOffline.Classes
{
    public class GameRules
    {
        //Native rules
        public bool open { get; set; }
        public bool same { get; set; }
        public bool random { get; set; }
        public bool elemental { get; set; }
        public bool suddenDeath { get; set; }
        public bool plus { get; set; }
        public bool sameWall { get; set; }

        //Extended rules
        public bool order { get; set; }
        public bool chaos { get; set; }
        public bool reverse { get; set; }
        public bool fallenAce { get; set; }
        public bool combo { get; set; }
        public bool swap { get; set; }


        //Prize count (0, 1, 3, 5)
        public int prizeCount { get; set; }

        internal void set(string ruleSet)
        {
            throw new NotImplementedException();
        }

        internal void clear()
        {
            open = false;
            same = false;
            random = false;
            elemental = false;
            suddenDeath = false;
            plus = false;
            sameWall = false;

            order = false;
            chaos = false;
            reverse = false;
            fallenAce = false;
            combo = false;
            swap = false;

            prizeCount = 0;
        }
    }
}
