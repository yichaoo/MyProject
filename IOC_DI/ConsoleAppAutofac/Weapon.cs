using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoFacDemo
{
    public class Fireball : IWeapon
    {
        public string Name { get { return "火球术"; } }
    }
    public class Sword : IWeapon
    {
        public string Name { get { return "剑"; } }
    }

  
}
