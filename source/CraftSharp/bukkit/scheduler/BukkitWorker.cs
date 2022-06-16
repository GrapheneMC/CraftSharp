using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftSharp.bukkit.scheduler
{
    /// <summary>
    /// Represents a worker thread for the scheduler. This gives information about
    /// the Thread object for the task, owner of the task and the taskId.
    /// 
    /// Workers are used to execute async tasks.
    /// </summary>
    internal interface BukkitWorker
    {
        /// <summary>
        /// Returns the taskId for the task being executed by this worker.
        /// </summary>
        /// <returns>Task id number/returns>
        public Int32 GetTaskId();

        /*public Plugin GetOwner*/

        /// <summary>
        /// Returns the thread for the worker.
        /// </summary>
        /// <returns>The Thread object for the worker</returns>
        public Thread GetThread();
    }
}
