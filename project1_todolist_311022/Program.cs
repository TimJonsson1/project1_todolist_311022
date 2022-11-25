
using project1_todolist_311022;
using System.Collections;
using System.Linq;

bool isRunning = true;
List<Todolist> tasks = new List<Todolist>();

tasks.Add(new Todolist("ToDo",new DateTime(2023,04,20),"not done","April Project"));
tasks.Add(new Todolist("Other", new DateTime(2022,11,26), "not done", "November Project"));
tasks.Add(new Todolist("A Letter", new DateTime(2022, 12, 08), "not done", "Aplha Project"));
tasks.Add(new Todolist("B Letter", new DateTime(2023, 05, 01), "not done", "Alpha Project"));
tasks.Add(new Todolist("C Letter", new DateTime(2022, 04, 15), "not done", "Aplha Project"));
tasks.Add(new Todolist("D Letter", new DateTime(2022, 01, 01), "DONE", "Alpha Project"));
// replace X and Y with amount later when you can read a file

string title = "Title";
string duedate = "Duedate";
string status = "Status";
string project = "Project";
string nr = "Nr";

int spacing = 15;

while (isRunning)
{
    Console.WriteLine("Welcome to ToDoList \n" +
    "You have X tasks todo and Y taskt are done!\n" +
    "Pick an option:\n" +
    "(1) Show Task List (by date or project)\n" +
    "(2) Add new Task\n" +
    "(3) Edit Project/Task (update, mark as done, remove)\n" +
    "(4) Save and Quit\n");
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

    DateTime dateNow = DateTime.Now;

    Console.WriteLine("(1) sort by date - closes to Duedate or late first\n" +
        "(2) sort by project A-Z");

    string choice = Console.ReadLine();
    switch (choice)
    {
        case "1":

            Console.WriteLine(title.PadRight(spacing) + " " + duedate.PadRight(spacing) + " " +
           status.PadRight(spacing) + " " + project.PadRight(spacing) + "\n" +
           title.Replace(title, "----- ").PadRight(spacing) + duedate.Replace(duedate, " ------- ").PadRight(spacing) +
           status.Replace(status, "  ------").PadRight(spacing) + project.Replace(project, "   -------").PadRight(spacing) + "\n");

            List<Todolist> sortedTodoListByDate = tasks.OrderBy(date => date.dueDate).ToList();

            foreach (Todolist task in sortedTodoListByDate)
            {
                TimeSpan diff = task.dueDate - dateNow;
                
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
                Console.WriteLine(task.title.PadRight(spacing) + " " + task.dueDate.ToString("dd/MM/yyyy").PadRight(spacing) + " " + task.status.PadRight(spacing) + " " + task.project.PadRight(spacing) + "\n");
                Console.ResetColor();
            }

            break;
                        
        case"2":

            Console.WriteLine(title.PadRight(spacing) + " " + duedate.PadRight(spacing) + " " +
           status.PadRight(spacing) + " " + project.PadRight(spacing) + "\n" +
           title.Replace(title, "----- ").PadRight(spacing) + duedate.Replace(duedate, " ------- ").PadRight(spacing) +
           status.Replace(status, "  ------").PadRight(spacing) + project.Replace(project, "   -------").PadRight(spacing) + "\n");
            
            List<Todolist> sortedTodoListByProject = tasks.OrderBy(project => project.project).ToList(); 

            foreach (Todolist task in sortedTodoListByProject)
            {

                TimeSpan diff = task.dueDate - dateNow;

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

                Console.WriteLine(task.title.PadRight(spacing) + " " + task.dueDate.ToString("dd/MM/yyyy").PadRight(spacing) + " " + task.status.PadRight(spacing) + " " + task.project.PadRight(spacing) + "\n");
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
    //Todolist task1 = new Todolist("Title","duedate","Status","Project");
    //tasks.Add(task1);
    
    Console.Write("Add title: ");
    string title = Console.ReadLine();
    
    Console.Write("Add duedate (dd/mm/yyyy): ");
    string duedate = Console.ReadLine();
    DateTime date = Convert.ToDateTime(duedate);
    
    Console.Write("Add Status(blank = not done): ");
    string status = Console.ReadLine().ToUpper();
    if (status.Equals(""))
    {
        status = "not done";
    }
    
    Console.Write("Name of project project: ");
    string project = Console.ReadLine();

    Todolist task = new Todolist(title, date, status, project);
    tasks.Add(task);


}

void updateTask()
{
    Console.WriteLine("select the number of the task you want to change");
    Console.WriteLine(nr.PadRight(4) + " " + title.PadRight(spacing) + " " + duedate.PadRight(spacing) + " " +
           status.PadRight(spacing) + " " + project.PadRight(spacing) + "\n" +
           nr.Replace(nr,"--").PadRight(4) + " " + title.Replace(title, "----- ").PadRight(spacing) + duedate.Replace(duedate, " ------- ").PadRight(spacing) +
           status.Replace(status, "  ------").PadRight(spacing) + project.Replace(project, "   -------").PadRight(spacing) + "\n");
    for (int i = 0; i < tasks.Count; i++)
    {
        Console.WriteLine("("+(i+1)+")  " + tasks[i].title.PadRight(spacing) + " " + tasks[i].dueDate.ToString("dd/MM/yyyy").PadRight(spacing) +
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

                }
            }
            else if (editChoice.Equals("2"))
            {
                //code for changing the duedate
                Console.WriteLine("New Duedate for Project: " + tasks[taskChoice].project + "\nWith Title: " + tasks[taskChoice].title);
                string duedate = Console.ReadLine();
                DateTime date = Convert.ToDateTime(duedate);

                Console.WriteLine("new Duedate is: " + date + "\nif you regrett this choice press Q else press ENTER");
                if (Console.ReadLine().ToUpper().Equals("Q"))
                {

                    break;
                }
                else
                {
                    tasks[taskChoice].dueDate = date;

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
               
            }
            else
            {
                break;
            }
            break;
    }
    
}


