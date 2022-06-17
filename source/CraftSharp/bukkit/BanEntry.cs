using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftSharp.bukkit;

/* TODO: long original comment up here I'll look into adding it later */
public interface BanEntry
{
    /// <summary>
    /// Gets the target involved. This may be in the form of an IP or a player name.
    /// </summary>
    /// <returns>the target name or IP address</returns>
    public string GetTarget();

    /// <summary>
    /// Gets the date this ban entry was created.
    /// </summary>
    /// <returns>the creation date</returns>
    public DateTime GetCreated();

    /// <summary>
    /// Sets the date this ban entry was created.
    /// </summary>
    /// <param name="created">the new created date, cannot be null</param>
    /// <seealso cref="save"/>
    public void SetCreated(DateTime created);

    /// <summary>
    /// Gets the source of this ban.
    /// 
    /// Note: A source is considered any String, although this is generally a  player name.
    /// </summary>
    /// <returns>the source of the ban</returns>
    public string GetSource();

    /// <summary>
    /// Sets the source of this ban.
    ///  
    /// Note: A source is considered any String, although this is generally a player name.
    /// </summary>
    /// <param name="source">the new source where null values become empty strings</param>
    /// <seealso cref="save"/>
    public void SetSource(string source);

    /// <summary>
    ///  Gets the date this ban expires on, or null for no defined end date.
    /// </summary>
    /// <returns>the expiration date</returns>
    public DateTime GetExpiration();

    /// <summary>
    /// Sets the date this ban expires on. Null values are considered "infinite" bans.
    /// </summary>
    /// <param name="expiration">expiration the new expiration date, or null to indicate an eternity</param>
    /// <seealso cref="save"/>
    public void SetExpiration(DateTime expiration);

    /// <summary>
    /// Gets the reason for this ban.
    /// </summary>
    /// <returns>the ban reason, or null if not set</returns>
    public string GetReason();

    /// <summary>
    /// Sets the reason for this ban. Reasons must not be null.
    /// </summary>
    /// <param name="reason">reason the new reason, null values assume the implementation default</param>
    /// <seealso cref="save"/>
    public void SetReason(string reason);

    /// <summary>
    /// Saves the ban entry, overwriting any previous data in the ban list.
    ///  
    /// Saving the ban entry of an unbanned player will cause the player to be banned once again.
    /// </summary>
    public void save();
}
