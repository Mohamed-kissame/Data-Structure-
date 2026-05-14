using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace SmartTaskManager
{
    public class TaskItem
    {

        public enum TaskStatus
        {
            Pending = 1,
            OverDue = 2,
            Completed = 3,
            Archived = 4


        }

        public int Id { get; set; }

        public string Title { get; set; }

        public int Priority { get; set; }

        public DateTime DueDate { get; set; }

        public TaskStatus Status { get; set; }

        public bool IsImportant { get; set; }

        public DateTime CreatedAT { get; set; }

        public DateTime? CompletedAT { get; set; }

        public List<string> Tags { get; set; }

        public TaskItem(int id , string title , int Priority , DateTime DueTime , bool IsImprotant , List<string> Tag )
        {

            Id = id;
            Title = title;
            this.Priority = Priority;
            this.DueDate = DueTime;
            this.Status = TaskStatus.Pending;
            this.IsImportant = IsImprotant;
            this.CreatedAT = DateTime.Now;
            this.CompletedAT = null;
           
            if(Tag != null )
            {

                this.Tags = new List<string>(Tag);
            }
            else
            {
                this.Tags = new List<string>();
            }
            
        }




    }
}
