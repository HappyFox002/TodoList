using System;
using System.Collections.Generic;
using System.Linq;
using TodoList.Models;

namespace TodoList.Data
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
                var p = app.Purposes.Where(p => p.TaskId == t.Id).ToList();
                if (t != null) {
                    app.Purposes.RemoveRange(p);
                    app.Tasks.Remove(t);
                    app.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public static List<Purpose> GetPurposes(string taskName) {
            using (AppContext app = new AppContext())
            {
                return app.Purposes.Where(p => p.Task.Name == taskName).ToList();
            }
        }

        public static List<Purpose> GetPurposes(int id) {
            using (AppContext app = new AppContext()) {
                return app.Purposes.Where(p => p.Id == id).ToList();
            }
        }

        public static Purpose AddPurpose(string name, string taskName, DateTime endTime, string text = "")
        {
            using (AppContext app = new AppContext()) {
                Task t = app.Tasks.Where(n => n.Name == taskName).FirstOrDefault();
                Purpose exsistsP = app.Purposes.Where(p => p.Task.Id == t.Id && p.Header == name).FirstOrDefault();
                if (t != null && exsistsP == null) {
                    Purpose p = new Purpose() { Header = name, Text = text, CreateTime = DateTime.Now, EndTime = endTime, Status = PurposeStatus.CurrentTask, Task = t };
                    app.Purposes.Add(p);
                    app.SaveChanges();
                    return p;
                }
                return null;
            }
        }

        public static bool DelPurpose(int id) {
            using (AppContext app = new AppContext()) {
                Purpose p = app.Purposes.Where(p => p.Id == id).FirstOrDefault();
                app.Remove(p);
                app.SaveChanges();
                return true;
            }
            return false;
        }

        public static Purpose ChangePurpose(int id, PurposeStatus st) {
            using (AppContext app = new AppContext()) {
                Purpose p = app.Purposes.Where(p => p.Id == id).FirstOrDefault();
                if (p != null) {
                    p.Status = st;
                    app.SaveChanges();
                    return p;
                }
                return null;
            }
        }
    }
}
