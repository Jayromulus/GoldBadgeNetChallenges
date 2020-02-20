using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_BadgesClasses
{
    public class BadgeRepo
    {
        private Dictionary<int, List<string>> _badgeRepo = new Dictionary<int, List<string>>();

        public bool AddBadgeToRepo(Badge newBadge)
        {
            int before = _badgeRepo.Count();
            _badgeRepo.Add(newBadge.BadgeID, newBadge.DoorAccess);
            bool addedProperly = before + 1 == _badgeRepo.Count();

            return addedProperly;
        }

        public bool UpdateBadgeByID(int id, List<string> newAccess)
        {
            List<string> oldAccess;
            if (_badgeRepo.TryGetValue(id, out oldAccess))
            {
                _badgeRepo[id] = newAccess;
                return true;
            }
            else
            {
                Console.WriteLine("Could not find the specified key.");
                return false;
            }
        }

        public Dictionary<int, List<string>> GetAllBadges()
        {
            return _badgeRepo;
        }
    }
}
