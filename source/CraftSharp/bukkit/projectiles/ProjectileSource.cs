using CraftSharp.bukkit.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftSharp.bukkit.projectiles;

public interface ProjectileSource
{
    /*
     * This is providing hard to implement
     * 
     */

    /*'typeof(T) projectile' should be passed, but unsure how to make it work.*/
    public T LauchProjectile<T>(T projectile) where T : Projectile;

    public T LauchProjectile<T>(T projectile, Vector velocity) where T : Projectile;
}
