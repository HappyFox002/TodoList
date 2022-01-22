using System.Collections.Generic;
using System.Linq;
using TESTEfCore.Models;

namespace TESTEfCore.Data
{
    public class TasksData
    {
        public static bool AddNewTask(string name) {
            using (AppContext app = new AppContext()) {
                Task t = app.Tasks.Where(t => t.Name == name).FirstOrDefault();
                if (t == null)
                {
                    app.Tasks.Add(new Task() { Name = name });
                    app.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public static List<Task> GetTasks() {
            using (AppContext app = new AppContext()) {
                return app.Tasks.ToList();
            }
        }

        public static bool DelTask(string name) {
            using (AppContext app = new AppContext()) {
                Task t = app.Tasks.Where(n => n.Name == name).FirstOrDefault();
                if (t != null) {
                    app.Tasks.Remove(t);
                    app.SaveChanges();
                    return true;
                }
                return false;
            }
        }
    }
}
