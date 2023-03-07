namespace CMS.Interfaces
{
    internal interface ITask
    {
        string TaskName { get; set; }
        string TaskDescription { get; set; }
        string TaskStatus { get; set; }
    }
}
