using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop
{
    
        public class TaskItem
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public string Category { get; set; }
            public DateTime DueDate { get; set; }
            public DateTime CreatedTime { get; set; }
            public bool IsCompleted { get; set; }
            public string DisplayText => $"{Title}\n{CreatedTime:hh:mmtt}\n\n{Description}";
        }
    
}
