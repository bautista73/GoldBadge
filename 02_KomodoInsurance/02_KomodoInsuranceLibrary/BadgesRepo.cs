using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_KomodoInsuranceLibrary
{
    public class BadgesRepo
    {
        public Badges badge = new Badges();

        public Dictionary<int, Badges> _badge = new Dictionary<int, Badges>();

        public void CreateBadge(Badges badge, int badgeNumber)
        {
            _badge.Add(badgeNumber, badge);
        }

        public Dictionary<int, Badges> DisplayBadgeCollection()
        {
            return _badge;
        }

        public Badges DisplayBadgeID(int badgeNumber)
        {
            if (_badge.ContainsKey(badgeNumber))
            {
                return _badge[key: badgeNumber];
            }
            else
            {
                Console.WriteLine("Invalid Badge ID");

                return null;
            }          
        }

        public Badges DeleteBadgeDoorAccess(int badgeNumber)
        {
            if (_badge.ContainsKey(badgeNumber))
            {
                _badge[key: badgeNumber].DoorNames.Clear();

                Console.WriteLine("All door access removed from this badge");
            }
            else
            {
                Console.WriteLine("Invalid Badge ID");
            }
            return null;
        }

        public bool CreateBadge(Badges badge)
        {
            if (_badge.ContainsKey(badge.BadgeID))
            {
                return false;
            }
            else
            {
                _badge.Add(badge.BadgeID, badge);
            }
            return true;
        }
    }
}
