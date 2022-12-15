using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1_todolist_311022
{
    
    internal class Todolist
    {
        public Todolist(string title, string dueDate, string status, string project)
        {
            this.title = title;
            this.dueDate = dueDate;
            this.status = status;
            this.project = project;
        }

        public string title { get; set; }
        public string dueDate { get; set; }
        public string status { get; set; }
        public string project { get; set; }

        public string printAll()
        {
            string all = "Title: " + this.title + "\n" + 
                "Duedate: " + this.dueDate + "\n" + 
                "Status: " + this.status + "\n" +
                "project: " +this.project;
            return all;
        }

        
    }
}
