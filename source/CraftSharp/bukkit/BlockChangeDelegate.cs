using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftSharp.bukkit;

public interface BlockChangeDelegate
{
    /// <summary>
    /// Set a block type at the specified coordinates without doing all world updates and notifications.
    /// 
    /// It is safe to have this call World.setTypeId, but it may be slower than World.setRawTypeId.
    /// </summary>
    /// <param name="x">X coordinate</param>
    /// <param name="y">Y coordinate</param>
    /// <param name="z">Z coordinate</param>
    /// <param name="typeId">New block ID</param>
    /// <returns> true if the block was set successfully</returns>
    [Obsolete]
    public bool SetRawTypeId(int x, int y, int z, int typeId);

    /// <summary>
    /// Set a block type and data at the specified coordinates without doing all world updates and notifications.
    /// 
    /// It is safe to have this call World.setTypeId, but it may be slower than World.setRawTypeId.
    /// </summary>
    /// <param name="x">X coordinate</param>
    /// <param name="y">Y coordinate</param>
    /// <param name="z">Z coordinate</param>
    /// <param name="typeId">New block ID</param>
    /// <param name="data">Block data</param>
    /// <returns>true if the block was set successfully</returns>
    [Obsolete]
    public bool SetRawTypeIdAndData(int x, int y, int z, int typeId, int data);

    /// <summary>
    /// Set a block type at the specified coordinates.
    /// 
    /// This method cannot call World.setRawTypeId, a full update is needed.
    /// </summary>
    /// <param name="x">X coordinate</param>
    /// <param name="y">Y coordinate</param>
    /// <param name="z">Z coordinate</param>
    /// <param name="typeId">New block ID</param>
    /// <returns>true if the block was set successfully</returns>
    [Obsolete]
    public bool SetTypeId(int x, int y, int z, int typeId);

    /// <summary>
    /// Set a block type and data at the specified coordinates.
    /// 
    /// This method cannot call World.setRawTypeId, a full update is needed.
    /// </summary>
    /// <param name="x">X coordinate</param>
    /// <param name="y">Y coordinate</param>
    /// <param name="z">Z coordinate</param>
    /// <param name="typeId">New block ID</param>
    /// <param name="data">Block data</param>
    /// <returns>true if the block was set successfully</returns>
    [Obsolete]
    public bool SetTypeIdAndData(int x, int y, int z, int typeId, int data);

    /// <summary>
    /// Get the block type at the location.
    /// </summary>
    /// <param name="x">X coordinate</param>
    /// <param name="y">Y coordinate</param>
    /// <param name="z">Z coordinate</param>
    /// <returns>The block ID</returns>
    [Obsolete]
    public int GetTypeId(int x, int y, int z);

    /// <summary>
    /// Gets the height of the world.
    /// </summary>
    /// <returns>Height of the world</returns>
    public int GetHeight();

    /// <summary>
    /// Checks if the specified block is empty (air) or not.
    /// </summary>
    /// <param name="x">X coordinate</param>
    /// <param name="y">Y coordinate</param>
    /// <param name="z">Z coordinate</param>
    /// <returns>True if the block is considered empty.</returns>
    public bool IsEmpty(int x, int y, int z);
}
