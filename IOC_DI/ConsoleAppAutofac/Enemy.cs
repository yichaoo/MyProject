using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoFacDemo
{
    public class Orca : IEnemy
    {
        public string Name { get { return "兽人"; } }
    }
    public class Goblin : IEnemy
    {
        public string Name { get { return "哥布林"; } }
    }
}
