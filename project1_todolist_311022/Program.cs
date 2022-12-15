
using project1_todolist_311022;
using System.Collections;
using System.IO;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.Serialization;
using System.Xml;
using System.Threading.Tasks;

List<Todolist> tasks = new List<Todolist>();

//tasks.Add(new Todolist("ToDo", new DateTime(2023, 04, 20), "not done", "April Project"));

string title = "Title";
string duedate = "Duedate";
string status = "Status";
string project = "Project";
string nr = "Nr";

int spacing = 15;
bool isRunning = true;
string filePath = "C:\\Users\\TimJo\\source\\project1_todolist_311022\\project1_todolist_311022\\TextFile1.txt";

//string writeText = "Hello World";
//File.WriteAllText("listfile.txt", writeText);


//code for loading the text file info back to class objects before loading the rest of the program 
FileInfo fi = new FileInfo("C:\\Users\\TimJo\\source\\project1_todolist_311022\\project1_todolist_311022\\TextFile1.txt");
FileStream fs = fi.Open(FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read);
StreamReader sr = new StreamReader(fs);
string fileContent = sr.ReadToEnd();

sr.Close();
fs.Close();

int count = 1;

string[] words = fileContent.Split(' ');


foreach (string word in words)
{
    

    if (count == 1)
    {
        
        title = word;
    }

    if (count == 2)
    {
        
        duedate = word;
    }

    if(count == 3)
    {
        status = word;
    }

    //when the counter reached 4 it will reset to 1 so code will be executed to put all the info gathered into the class array and repeat until done
    if (count == 4)
    {
        project = word;

        tasks.Add(new Todolist(title, duedate, status, project));


    }


    count++;

    if (count == 5)
    {
        count = 1;
    }
    

}

int tasksNotDone = 0;
int tasksDone = 0;

while (isRunning)
{
    foreach(var task in tasks)
    {
        if(task.status == "not-done")
        {
            tasksNotDone++;
        }else if (task.status == "DONE")
        {
            tasksDone++;
        }
    }
    Console.WriteLine("Welcome to ToDoList \n" +
    "You have " + tasksNotDone + " tasks todo and " + tasksDone + " taskt are done!\n" +
    "Pick an option:\n" +
    "(1) Show Task List (by date or project)\n" +
    "(2) Add new Task\n" +
    "(3) Edit Project/Task (update, mark as done, remove)\n" +
    "(4) Save and Quit\n");
    tasksDone = 0;
    tasksNotDone = 0;

    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            //view all the tasks
            viewTasks();

            break;

        case "2":
            //creating a task
            createTask();


            break;

        case "3":
            //update an existing task
            updateTask();
            break;

        case "4":
            //quit the program
            isRunning = false;
            break;


        default:
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("oops something went wrong please try to only use 1 - 4 as an option\n" +
                "Press enter to continue");
            Console.ReadLine();
            printOptions();

            break;
    }



}

void printOptions()
{
    Console.ResetColor();
    Console.WriteLine("\nWelcome to ToDoList \n" +
    "You have X tasks todo and Y taskt are done!\n" +
    "Pick an option:\n" +
    "(1) Show Task List (by date or project)\n" +
    "(2) Add new Task\n" +
    "(3) Edit Test (update, mark as done, remove)\n" +
    "(4) Save and Quit\n");
}

void viewTasks()
{
    string title = "Title";
    string duedate = "Duedate";
    string status = "Status";
    string project = "Project";
    DateTime dateNow = DateTime.Now;

    Console.WriteLine("(1) sort by date\n" +
        "(2) sort by project A-Z");

    string choice = Console.ReadLine();
    switch (choice)
    {
        //code to show the list of tasks and projects and sorted by date
        case "1":
            
                Console.WriteLine(title.PadRight(spacing) + " " + duedate.PadRight(spacing) + " " +
               status.PadRight(spacing) + " " + project.PadRight(spacing) + "\n" +
               title.Replace(title, "----- ").PadRight(spacing) + duedate.Replace(duedate, " ------- ").PadRight(spacing) +
               status.Replace(status, "  ------").PadRight(spacing) + project.Replace(project, "   -------").PadRight(spacing) + "\n");
            

            List<Todolist> sortedTodoListByDate = tasks.OrderByDescending(date => date.dueDate).ToList();

            foreach (Todolist task in sortedTodoListByDate)
            {
                DateTime tempDateTime = DateTime.Parse(task.dueDate);
                TimeSpan diff = tempDateTime - dateNow;
                
                if(diff.Days < 10)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                } 
                else if (diff.Days < 20)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }

                if (task.status.Equals("DONE"))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                Console.WriteLine(task.title.PadRight(spacing) + " " + task.dueDate.PadRight(spacing) + " " + task.status.PadRight(spacing) + " " + task.project.PadRight(spacing) + "\n");
                Console.ResetColor();
            }

            break;
                        
        case"2":
            //code to show the list of tasks and projects and sorted by A-Z

            try
            {
                Console.WriteLine(title.PadRight(spacing) + " " + duedate.PadRight(spacing) + " " +
               status.PadRight(spacing) + " " + project.PadRight(spacing) + "\n" +
               title.Replace(title, "----- ").PadRight(spacing) + duedate.Replace(duedate, " ------- ").PadRight(spacing) +
               status.Replace(status, "  ------").PadRight(spacing) + project.Replace(project, "   -------").PadRight(spacing) + "\n");
            }
            catch (ArgumentException ae)
            {

            }
            
            List<Todolist> sortedTodoListByProject = tasks.OrderBy(project => project.project).ToList(); 

            foreach (Todolist task in sortedTodoListByProject)
            {
                DateTime tempDateTime = DateTime.Parse(task.dueDate);
                TimeSpan diff = tempDateTime - dateNow;

                if (diff.Days < 10)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else if (diff.Days < 20)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }

                if (task.status.Equals("Done"))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }

                Console.WriteLine(task.title.PadRight(spacing) + " " + task.dueDate.PadRight(spacing) + " " + task.status.PadRight(spacing) + " " + task.project.PadRight(spacing) + "\n");
                Console.ResetColor();
            }


            break;

            
        default :
            Console.WriteLine("Please choose (1) or (2) as the input");
            break;

    }

    Console.WriteLine("press Enter to contine");
    Console.ReadLine();

    
}

void createTask()
{
    //code to create a task by adding title, duedate, status(automatic if left empty) and the project name
    
    Console.Write("Add title: ");
    string title = Console.ReadLine();
    
    Console.Write("Add duedate (dd/mm/yyyy): ");
    string duedate = Console.ReadLine();
    
    Console.Write("Add Status(blank = not done): ");
    string status = Console.ReadLine().ToUpper();
    if (status.Equals(""))
    {
        status = "not done";
    }
    
    Console.Write("Name of project project: ");
    string project = Console.ReadLine();

    Todolist task = new Todolist(title, duedate, status, project);
    tasks.Add(task);

    
        string stringToFile = task.title.Replace(" ","-").Trim() + " " + task.dueDate.Trim() + " " +
            task.status.Replace(" ", "-").Trim() + " " + task.project.Replace(" ", "-").Trim() + " ";
        File.AppendAllText("C:\\Users\\TimJo\\source\\project1_todolist_311022\\project1_todolist_311022\\TextFile1.txt", stringToFile);
        //File.AppendAllLines("C:\\Users\\TimJo\\source\\project1_todolist_311022\\project1_todolist_311022\\TextFile1.txt",
        //    stringToFile.Split(Environment.NewLine.ToString()).ToList<string>());
   


}

void updateTask()
{
    //code to uppdate a task 
    Console.WriteLine("select the number of the task you want to change");
    
    for (int i = 0; i < tasks.Count; i++)
    {
        Console.WriteLine("("+(i+1)+")  " + tasks[i].title.PadRight(spacing) + " " + tasks[i].dueDate.PadRight(spacing) +
            " " + tasks[i].status.PadRight(spacing) + " " + tasks[i].project.PadRight(spacing));
    }

    Console.Write("\nselect the task you want to update: ");
    int taskChoice = int.Parse(Console.ReadLine());
    taskChoice--;

    Console.WriteLine("\nwhat do you want to change?\n" +
        "(1) edit\n" +
        "(2) mark as done\n" +
        "(3) remove task");
    string choice = Console.ReadLine();

    switch (choice)
    {
        //Code to edit the taks by changing title, duedate or the project name
        case "1":

            Console.WriteLine("\nwhat do you want to edit?\n" +
            "(1) title\n" +
            "(2) duedate\n" +
            "(3) project name");

            string editChoice = Console.ReadLine();

            if (editChoice.Equals("1"))
            {
                //code for changing the title
                Console.WriteLine("New title for Project: " + tasks[taskChoice].project + "\nWith Title: " + tasks[taskChoice].title);
                string newTitle = Console.ReadLine();

                Console.WriteLine("new Title is: " + newTitle + "\nif you regrett this choice press Q else press ENTER");

                if (Console.ReadLine().ToUpper().Equals("Q"))
                {

                    break;
                }
                else
                {
                    tasks[taskChoice].title = newTitle;
                    updateTextFile();
                }

                
            }
            else if (editChoice.Equals("2"))
            {
                //code for changing the duedate
                Console.WriteLine("New Duedate for Project: " + tasks[taskChoice].project + "\nWith Title: " + tasks[taskChoice].title);
                string duedate = Console.ReadLine();
                

                Console.WriteLine("new Duedate is: " + duedate + "\nif you regrett this choice press Q else press ENTER");
                if (Console.ReadLine().ToUpper().Equals("Q"))
                {

                    break;
                }
                else
                {
                    tasks[taskChoice].dueDate = duedate;
                    updateTextFile();

                }

            }
            else if (editChoice.Equals("3"))
            {
                //code for changing the project name
                Console.WriteLine("New Project name for Project: " + tasks[taskChoice].project + "\nWith Title: " + tasks[taskChoice].title);
                string newProjectName = Console.ReadLine();

                Console.WriteLine("new Project name is: " + newProjectName + "\nif you regrett this choice press Q else press ENTER");

                if (Console.ReadLine().ToUpper().Equals("Q"))
                {

                    break;
                }
                else
                {
                    tasks[taskChoice].project = newProjectName;
                    updateTextFile();

                }
            }
            else
            {
                Console.WriteLine("You can only use option 1, 2 and 3");
            }

            break;
            
        case "2":
            //code for marking a task as done

            Console.WriteLine("Do you want to mark Project: " + tasks[taskChoice].project + " With Title: " + tasks[taskChoice].title + " as done?\n" +
                "Y/N");
            string yesNo = Console.ReadLine().ToUpper().Trim().Remove(1);

            if (yesNo.Equals("Y"))
            {
                tasks[taskChoice].status = "DONE";
                updateTextFile();
            } else
            {
                break;
            }



            break;
        
        case "3":
            //code for removing a task

            Console.WriteLine("Do you want to remove Project: " + tasks[taskChoice].project + " With Title: " + tasks[taskChoice].title + "?\n" +
                " (WARNING YOU CAN NOT UNDO THIS ACTION OF REMOVAL)" +
                "Y/N");

            yesNo = Console.ReadLine().ToUpper().Trim().Remove(1);
            if (yesNo.Equals("Y"))
            {
                tasks.RemoveAt(taskChoice);
                updateTextFile();

            }
            else
            {
                break;
            }
            break;
    }

    void updateTextFile()
    {
        File.WriteAllText(filePath, "");
        foreach (Todolist task in tasks)
        {
            string stringToFile = task.title.Replace(" ", "-").Trim() + " " + task.dueDate.Trim() + " " +
            task.status.Replace(" ", "-").Trim() + " " + task.project.Replace(" ", "-").Trim() + " ";
            File.AppendAllText(filePath, stringToFile);
        }
    }
    
}

