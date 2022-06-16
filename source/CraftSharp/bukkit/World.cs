namespace CraftSharp.bukkit;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface World
{
    /// <summary>
    /// Gets the Seed for this world.
    /// </summary>
    public long Seed { get; set; }
}
