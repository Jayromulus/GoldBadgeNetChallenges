using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_CafeClasses
{
    public class CafeRepo
    {
        private readonly List<MenuItem> _menuRepository = new List<MenuItem>();

        public bool AddMenuItemToRepository(MenuItem newItem)
        {
            int oldLength = _menuRepository.Count();
            _menuRepository.Add(newItem);
            return oldLength + 1 == _menuRepository.Count();
        }

        public bool RemoveMenuItemFromRepository(MenuItem item)
        {
            int oldLength = _menuRepository.Count();
            _menuRepository.Remove(item);
            return oldLength - 1 == _menuRepository.Count();
        }

        public List<MenuItem> GetAllMenuItems()
        {
            return _menuRepository;
        }
    }
}
