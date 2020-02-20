using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_BadgesClasses
{
    public class Badge
    {
        public Badge () { }
        public Badge(int id, List<string> access)
        {
            BadgeID = id;
            DoorAccess = access;
        }

        public int BadgeID { get; set; }
        public List<string> DoorAccess { get; set; }
    }
}
