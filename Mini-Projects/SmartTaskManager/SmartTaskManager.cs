using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTaskManager
{
    public class SmartTaskManager
    {

       

        private List<TaskItem> _tasks;

        private int _NextId;

        public SmartTaskManager()
        {

            _tasks = new List<TaskItem>();
            _NextId = 1;
            
        }

        private List<TaskItem> GetTasks(TaskItem.TaskStatus status)
        {
            if (IsNullOrEmptyTaskList(_tasks))
            {
                return new List<TaskItem>();
            }


            List<TaskItem> importantTasks = _tasks.Where(t => t.Status == status).ToList();

            return importantTasks;
        }

        private  TaskItem FindTaskById(int Id)
        {

            TaskItem Results = _tasks.Find(x => x.Id == Id);

            return Results;
        }

        private bool IsAVAlidPeriority(int Periority)
        {

            return Periority >= 1 && Periority <= 5;

        }

        private bool IsTitleNullOrWhitSpace(string Title)
        {

            return !string.IsNullOrWhiteSpace(Title);
        }

        private List<string> CleanTags(List<string> tags)
        {

            if (tags == null) return new List<string>(); 


             List<string> CleanedTags = new List<string>();
             
            string trimmedTag = string.Empty;

            foreach (string tag in tags)
            {

                if(String.IsNullOrWhiteSpace(tag)) continue;

                trimmedTag = tag.Trim();

                if (!CleanedTags.Any(t => String.Equals(t,trimmedTag , StringComparison.OrdinalIgnoreCase)))
                {
                    CleanedTags.Add(trimmedTag);
                }
                
            }


            return CleanedTags;
          

        }

        private bool IsvalidTaskInput(string Title , int priority)
        {
            return !string.IsNullOrWhiteSpace(Title) 
                && priority >= 1 && priority <= 5;
        }

        private bool IsNullOrEmptyTaskList(List<TaskItem> Task)
        {
            return Task == null || Task.Count == 0;

        }

        private bool IsNullTask(TaskItem Task)
        {
            return Task == null;

        }

        public void AddTask(string title, int priority, DateTime dueDate, bool isImportant, List<string> tags)
        {

            if (!IsvalidTaskInput(title , priority)) { Console.WriteLine("The Title shouuld be Valid and Priority between 1 and 5 "); return; }

            List<string> CleanedTags = CleanTags(tags);

            TaskItem task = new TaskItem(_NextId, title.Trim(), priority, dueDate, isImportant, CleanedTags);

            _tasks.Add(task);

            _NextId++;
            
        }

        public void AddManyTasks(List<TaskItem> tasks)
        {

            if (IsNullOrEmptyTaskList(tasks)) { Console.WriteLine("The Tasks should not be null or empty"); return; }

            List<TaskItem> ValidTasks = new List<TaskItem>();

            foreach (var task in tasks)
            {

                if(IsNullTask(task)) { continue; }

                if (!IsvalidTaskInput(task.Title, task.Priority)) { continue; }

                List<string> CleanedTags = CleanTags(task.Tags);

                TaskItem tsk = new TaskItem(_NextId, task.Title.Trim(), task.Priority, task.DueDate, task.IsImportant, CleanedTags);

                ValidTasks.Add(tsk);

                _NextId++;

            }

            _tasks.AddRange(ValidTasks);



        }

        public  void  CompleteTask(int id)
        {

            TaskItem Task = FindTaskById(id);

            if (IsNullTask(Task))
            {

                Console.WriteLine($"No Task Found with this ID : {id} Try Another Valid Id ");

                return;

            }

            if(Task.Status == TaskItem.TaskStatus.Completed)
            {

                Console.WriteLine("This Task Already Completed");
                return;

            }

            if (Task.Status == TaskItem.TaskStatus.Archived)
            {


                Console.WriteLine("This Task its alraedy Archived");
                return;


            }

            Task.Status = TaskItem.TaskStatus.Completed;
            Task.CompletedAT = DateTime.Now;

        }

        public  void UpdateTaskTitle(int id, string newTitle)
        {

            if (!IsTitleNullOrWhitSpace(newTitle))
            {
                Console.WriteLine("You Should Enter a Valid Title ex: 'First Work'");
                return;
            }

            TaskItem task = FindTaskById(id);

            if (IsNullTask(task))
            {

                Console.WriteLine($"No Task Found with this id {id} to update try with a valid Id");
                return;

            }

            task.Title = newTitle.Trim();


        }

        public  void UpdatePriority(int id, int newPriority)
        {


            if (!IsAVAlidPeriority(newPriority))
            {
                Console.WriteLine("You Should Enter a Valid Priority between 1 And 5");
                return;
            }

            TaskItem task = FindTaskById(id);

            if (IsNullTask(task))
            {

                Console.WriteLine($"No Task Found with this id {id} to update try with a valid Id");
                return;

            }

            task.Priority = newPriority;

        }

        public void DeleteTask(int id)
        {


            TaskItem Task = FindTaskById(id);

            if (IsNullTask(Task)) { Console.WriteLine($"No Task Found with This id {id} To delete try a valid id"); return; }


            if(Task.IsImportant == true)
            {
                Console.WriteLine("You Cannot delete this Task Directly Becuase its Important use Force Delete Task to achive That");
                return;
            }

            _tasks.Remove(Task);

        }

        public  void ForceDeleteTask(int id)
        {

            TaskItem Task = FindTaskById(id);

            if (IsNullTask(Task)) { Console.WriteLine($"No Task Found with This id {id} To delete try a valid id"); return; }

            _tasks.Remove(Task);

        }

        public void MarkOverdueTasks()
        {


            foreach (var Taskitem in _tasks)
            {


                if(Taskitem.DueDate <  DateTime.Today && Taskitem.Status != TaskItem.TaskStatus.Completed && Taskitem.Status != TaskItem.TaskStatus.Archived)
                {

                    Taskitem.Status = TaskItem.TaskStatus.OverDue;
                }
                


            }


        }

        public void ArchiveTask(int id)
        {

            TaskItem task = FindTaskById(id);


            if (IsNullTask(task)) { Console.WriteLine($"No Task Found with this id {id}"); return;  }

            if(task.Status != TaskItem.TaskStatus.Completed)
            {
                Console.WriteLine("Cannot Archived This Task Beacuse still incompleted");
                return;
            }

            task.Status = TaskItem.TaskStatus.Archived;

        }

        public void ArchiveCompletedTasks()
        {

            int count = 0;

            foreach (var item in _tasks)
            {
                
                if(item.Status == TaskItem.TaskStatus.Completed)
                {
                    item.Status = TaskItem.TaskStatus.Archived;
                    count++;
                }
            
            }

            if(count > 0)
            {

                Console.WriteLine($"{count} tasks Archived Successfuly");

            }
            else
            {
                Console.WriteLine("No completed tasks to archive");
            }

           



        }

        public void RemoveArchivedTasks()
        {

            int Results =  _tasks.RemoveAll(t => t.Status == TaskItem.TaskStatus.Archived);

            if(Results == 0)
            {
                Console.WriteLine("No Archived Tasks to Remove");
                return;
            }

        }

        public List<TaskItem> GetPendingTasks()
        {

           return GetTasks(TaskItem.TaskStatus.Pending);

        }

        public  List<TaskItem> GetCompletedTasks()
        {
            return GetTasks(TaskItem.TaskStatus.Completed);
        }

        public  List<TaskItem> GetOverdueTasks()
        {
            return GetTasks(TaskItem.TaskStatus.OverDue);
        }

        public  List<TaskItem> GetImportantTasks()
        {

            if (IsNullOrEmptyTaskList(_tasks))
            {
                return new List<TaskItem>();
            }


            List<TaskItem> ImportantTasks = _tasks.Where(t => t.IsImportant == true).ToList();

            return ImportantTasks;

        }

        public List<TaskItem> SearchByKeyword(string keyword)
        {
            if (!IsTitleNullOrWhitSpace(keyword))
            {
                return new List<TaskItem>();
            }

            keyword = keyword.Trim();

            return _tasks
                .Where(t => t.Title != null &&
                            t.Title.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();
        }

        public List<TaskItem> GetTasksByTag(string tag)
        {
            if (!IsTitleNullOrWhitSpace(tag))
            {
                return new List<TaskItem>();
            }

            tag = tag.Trim();

            return _tasks
                .Where(t => t.Tags != null &&
                            t.Tags.Any(taskTag =>
                                string.Equals(taskTag, tag, StringComparison.OrdinalIgnoreCase)))
                .ToList();
        }

        public List<TaskItem> GetTopUrgentTasks(int count)
        {

            if(count <= 0)
            {
                return new List<TaskItem>();
            }

           return  _tasks.OrderByDescending(t => t.IsImportant).ThenBy(t => t.DueDate).ThenByDescending(t => t.Priority).ThenBy(t => t.Title).Take(count).ToList();

        }

        public List<TaskItem> GetSortedByDueDate()
        {

           return _tasks.OrderBy(t => t.DueDate).ToList();

        }

        public void SortOriginalByDueDate()
        {

            _tasks.Sort((x , y) => x.DueDate.CompareTo(y.DueDate));

        }

        public void ShowTasksGroupedByStatus()
        {

            var Groups = _tasks.GroupBy(t => t.Status).ToList();

            foreach (var Group in Groups)
            {

                Console.WriteLine(Group.Key);

                foreach (TaskItem Task in Group)
                {

                    Console.WriteLine($"{Task.Id} | {Task.Title}\n");

                }
               

            }

        }

        public void ShowStatistics()
        {





            try
            {

                int PendingTAsks = _tasks.Count(t => t.Status == TaskItem.TaskStatus.Pending);
                int CompletedTAsks = _tasks.Count(t => t.Status == TaskItem.TaskStatus.Completed);
                int OverDueTAsks = _tasks.Count(t => t.Status == TaskItem.TaskStatus.OverDue);
                int ArchivedTAsks = _tasks.Count(t => t.Status == TaskItem.TaskStatus.Archived);
                int ImportantTAsks = _tasks.Count(t => t.IsImportant == true);
                List<TaskItem> duetask = _tasks.OrderBy(t => t.DueDate).Take(1).ToList();
                List<TaskItem> HighstPrioritytask = _tasks.OrderByDescending(t => t.Priority).Take(1).ToList();

                Console.WriteLine("\t   Statistics  \t");

                Console.WriteLine("\n-------------------------------------------------------------- \n\n");
                Console.WriteLine($"Total Tasks           : {_tasks.Count}");
                Console.WriteLine($"Total pending Tasks   : {PendingTAsks}");
                Console.WriteLine($"Total Completed Tasks : {CompletedTAsks}");
                Console.WriteLine($"Total OverDue Tasks   : {OverDueTAsks}");
                Console.WriteLine($"Total Archived Tasks  : {ArchivedTAsks}");
                Console.WriteLine($"Total Important Tasks : {ImportantTAsks}");
                Console.WriteLine("Nearset due task       : \n");
                Console.WriteLine("-----------------------: \n");
                ShowTasks(duetask);
                Console.WriteLine("-----------------------: \n");
                Console.WriteLine("Highset Priority task  : \n");
                Console.WriteLine("-----------------------: \n");
                ShowTasks(HighstPrioritytask);
                Console.WriteLine("-----------------------: \n");
                Console.WriteLine($"Does list contain Any Over Due Task : {(_tasks.Any(t => t.Status == TaskItem.TaskStatus.OverDue) ? " Yes " : " No ")}");
                Console.WriteLine($"Are All Tasks Completed             : {(_tasks.Count > 0 && _tasks.All(t => t.Status == TaskItem.TaskStatus.Completed) ? " Yes " : " No ")}");
                Console.WriteLine($"Current Count       : {_tasks.Count}");
                Console.WriteLine($"Current Capacity    : {_tasks.Capacity}");
                Console.WriteLine("\n-------------------------------------------------------------- \n\n");



            }
            catch (Exception ex)
            {


                Console.WriteLine(ex.ToString());

            }



        }

        public void ShowAllTasks()
        {
            ShowTasks(_tasks);
        }

        public void ShowTasks(List<TaskItem> tasks)
        {

            if (IsNullOrEmptyTaskList(tasks))
            {
                Console.WriteLine("No Tasks to show");
                return;
            }


            Console.WriteLine(" The List Of Tasks ");

            foreach (var item in tasks)
            {
                Console.WriteLine("\n--------------------------------------------------------\n");
                Console.WriteLine($"Id           : {item.Id}");
                Console.WriteLine($"Title        : {item.Title}");
                Console.WriteLine($"Priority     : {item.Priority}");
                Console.WriteLine($"DueDate      : {item.DueDate}");
                Console.WriteLine($"Status       : {item.Status}");
                Console.WriteLine($"Is Important : {(item.IsImportant == true ? " Yes " : " No" )}");
                Console.WriteLine($"Created At   : {item.CreatedAT.ToShortDateString()}");
                Console.WriteLine($"Completed At : {(item.CompletedAT == null ? " Is stil Not Completed " : item.CompletedAT.Value.ToShortDateString())}");
                Console.WriteLine($"Tags         : {(item.Tags == null || item.Tags.Count == 0 ? " No Tags " : string.Join(" , " , item.Tags))}");
                Console.WriteLine("\n--------------------------------------------------------\n");
            }

        }

        public void ShowMemoryInfo()
        {

            Console.WriteLine($"Number Of Tasks     : {_tasks.Count}");
            Console.WriteLine($"Number of All Slots : {_tasks.Capacity}");

        }

        public void TrimMemory()
        {

            int OldCApacity = _tasks.Capacity;
            _tasks.TrimExcess();
            int NewCApacity = _tasks.Capacity;

            Console.WriteLine($"Old capacity                   : {OldCApacity}");
            Console.WriteLine($"New Capacity After Trim Excess : {NewCApacity}");


        }




    }

}
