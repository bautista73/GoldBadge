using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_KomodoInsuranceLibrary
{
    public class Badges
    {
        public int BadgeID { get; set; }
        public List<string> DoorNames { get; set; }
        public string Name { get; set; }
        public List<string> BadgeDoorAccess { get; set; }

        public Badges(int badgeId) 
        { 
            BadgeID = badgeId; 
        }

        public Badges(int badgeID, List<string> doorNames, string name)
        {
            BadgeID = badgeID;
            DoorNames = doorNames;
            Name = name;
        }

        public Badges()
        {

        }

        public Badges(int badgeId, List<string> badgeDoorAccess)
        {
            BadgeID = badgeId;
            BadgeDoorAccess = badgeDoorAccess;
        }
    }
}
