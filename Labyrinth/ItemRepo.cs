using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth
{
    class ItemRepo
    {
        private readonly List<Keys> _keyDirectory = new List<Keys>();

        //Create key method
        public bool AddKeyToDirectory(Keys newKey)
        {
            int startingCount = _keyDirectory.Count;

            _keyDirectory.Add(newKey);

            bool wasAddedCorrectly = (_keyDirectory.Count > startingCount) ? true : false;
            return wasAddedCorrectly;
        }

        //Read Key method
        public List<Keys> GetKeys()
        {
            return _keyDirectory;
        }

        public Keys GetKeyByColor(string color)
        {
            foreach (Keys newKey in _keyDirectory)
            {
                if (newKey.KeyColor == color)
                {
                    return newKey;
                }
            }
            return null;
        }

        //Delete key method
        public void DeleteExistingKey (string keyColor)
        {
            Keys keyToDelete = GetKeyByColor(keyColor);
            _keyDirectory.Remove(keyToDelete);
        }
    }
}
