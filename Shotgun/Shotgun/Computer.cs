using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shotgun
{
    public class Computer
    {
        public int AmountOfAmmo { get; set; }

        public Computer(int ammo)
        {
            AmountOfAmmo = ammo;
        }
        public string Action()
        {
            string[] actions = { "Shoot", "Load", "Block" };
            Random rand = new Random();
            int index = rand.Next(actions.Length);
            return (actions[index]);
        }
    }
}
