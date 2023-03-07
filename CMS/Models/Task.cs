using CMS.Interfaces;

namespace CMS.Models
{
    internal class Task : ITask
    {
        public string TaskName { get; set; } = null!;
        public string TaskDescription { get ; set ; } = null!;
        public string TaskStatus { get ; set ; } = null!;
    }
}
