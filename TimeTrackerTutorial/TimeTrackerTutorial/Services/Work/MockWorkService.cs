using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TimeTrackerTutorial.Models;

namespace TimeTrackerTutorial.Services.Work
{
    public class MockWorkService : IWorkService
    {
        public List<WorkItem> Items { get; set; }
        public MockWorkService()
        {
            Items = new List<WorkItem>();
        }
        public Task<bool> LogWorkAsync(WorkItem item)
        {
            Items.Add(item);
            return Task.FromResult(true);
        }
    }
}
