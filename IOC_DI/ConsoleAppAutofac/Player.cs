using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace AutoFacDemo
{
    public class Knight : IPlayer
    {
        IWeapon _weapon;
        IEnemy _enemy;

        public Knight(IWeapon weapon, IEnemy enemy)
        {
            _weapon = weapon;
            _enemy = enemy;
        }

        public string Name { get { return "骑士"; } }

        public void Attack()
        {
            Console.WriteLine("{0}拔出了{1}，奋力攻击{2}", this.Name, _weapon.Name, _enemy.Name);
        }
    }
    public class Archmage : IPlayer
    {
        IWeapon _weapon;
        IEnemy _enemy;

        public Archmage(IWeapon weapon, IEnemy enemy)
        {
            _weapon = weapon;
            _enemy = enemy;
        }

        public string Name { get { return "大法师"; } }

        public void Attack()
        {
            Console.WriteLine("{0}开始吟唱{1}，{2}被{1}炸飞", this.Name, _weapon.Name, _enemy.Name);
        }
    }


}
