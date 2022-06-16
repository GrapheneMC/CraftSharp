using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftSharp.bukkit.scheduler;

public interface BukkitTask
{
    /// <summary>
    /// Returns the taskId for the task.
    /// </summary>
    /// <returns>Task id number</returns>
    public Int32 GetTaskId();

    /*public Plugin GetOwner */

    /// <summary>
    /// Returns true if the Task is a sync task.
    /// </summary>
    /// <returns>true if the task is run by main thread</returns>
    public Boolean IsSync();

    /// <summary>
    /// Will attempt to cancel this task.
    /// </summary>
    public void cancel();
}
