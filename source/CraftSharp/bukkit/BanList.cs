using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftSharp.bukkit;

/// <summary>
///  A ban list, containing bans of some
///  <see cref="Type"/>
/// </summary>
public interface BanList
{
    /// <summary>
    /// Represents a ban-type that a <see cref="BanList"/> may track.
    /// </summary>
    public enum Type
    {
        /// <summary>
        /// Banned player names
        /// </summary>
        NAME,
        /// <summary>
        /// Banned player IP addresses
        /// </summary>
        IP,
    }

    /// <summary>
    /// Gets a <see cref="BanEntry"/> by target.
    /// </summary>
    /// <param name="target">entry parameter to search for</param>
    /// <returns> the corresponding entry, or null if none found</returns>
    public BanEntry GetBanEntry(string target);

    /// <summary>
    /// Adds a ban to the this list. If a previous ban exists, this will update the previous entry.
    /// </summary>
    /// <param name="target">the target of the ban</param>
    /// <param name="reason">reason for the ban, null indicates implementation default</param>
    /// <param name="expires">date for the ban's expiration (unban), or null to imply forever</param>
    /// <param name="source"> source of the ban, null indicates implementation default</param>
    /// <returns>the entry for the newly created ban, or the entry for the (updated) previous ban</returns>
    public BanEntry AddBan(string target, string reason, DateTime expires, string source);

    /// <summary>
    /// Gets a set containing every <see cref="BanEntry"/> in this list.
    /// </summary>
    /// <returns> an immutable set containing every entry tracked by this list</returns>
    public HashSet<BanEntry> GetBanEntries();

    /// <summary>
    /// Gets if a <see cref="BanEntry"/> exists for the target, indicating an active ban status.
    /// </summary>
    /// <param name="target">the target to find</param>
    /// <returns>true if a <see cref="BanEntry"/> exists for the name, indicating an active ban status, false otherwise</returns>
    public bool IsBanned(string target);

    /// <summary>
    /// Removes the specified target from this list, therefore indicating a "not banned" status.
    /// </summary>
    /// <param name="target">the target to remove from this list</param>
    public void Pardon(string target);
}
