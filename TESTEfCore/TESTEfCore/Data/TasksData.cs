using System.Collections.Generic;
using System.Linq;
using TESTEfCore.Models;

namespace TESTEfCore.Data
{
    public class TasksData
    {
        public static int AddNewTask(string name) {
            using (AppContext app = new AppContext()) {
                app.Tasks.Add(new Task() { Name = name });
                return app.SaveChanges();
            }
        }

        public static List<Task> GetTasks() {
            using (AppContext app = new AppContext()) {
                return app.Tasks.ToList();
            }
        }
    }
}
