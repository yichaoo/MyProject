using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoFacDemo
{
    interface InterfaceGame
    {
    }

    /// <summary>
    /// 玩家
    /// </summary>
    public interface IPlayer
    {
        string Name { get; }
        void Attack();
    }
    /// <summary>
    /// 敌人
    /// </summary>
    public interface IEnemy
    {
        string Name { get; }
    }
    /// <summary>
    /// 武器
    /// </summary>
    public interface IWeapon
    {
        string Name { get; }
    }
    
}
