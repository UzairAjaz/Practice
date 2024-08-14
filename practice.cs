

    class Menu
    {
        List<IDeveloper> developers = new List<IDeveloper>();
        public void MainMenu()
        {
            Console.WriteLine("--------------- Project Evaluator ---------------");
            Console.WriteLine("1 - Developer Details");
            Console.WriteLine("2 - Project Details");

            Console.Write("Select an option");
            int userchoice = int.Parse(Console.ReadLine());

            Process(userchoice);

        }
        public void DeveloperDetails()
        {
            string userdecision;
            do
            {
                Console.Write("Name : ");
                string name = Console.ReadLine();
                Console.Write("Hourly Rate : ");
                double hourlyrate = double.Parse(Console.ReadLine());

                developers.Add(new Developer { Name = name, HourlyRate = hourlyrate });

                Console.Write("Do you want to add another (y/n) : ");
                userdecision = Console.ReadLine().ToLower();
            } while (userdecision == "y");

            if (userdecision == "n")
            {
                MainMenu();
            }
            else
            {
                Console.WriteLine("invalid choice.......");
            }
        }
        public void ProjectDetails()
        {
            Console.Write("Project Name : ");
            string name = Console.ReadLine();
            Console.Write("Hours : ");
            double hours = double.Parse(Console.ReadLine());

            if (hours > 0)
            {
                foreach (var i in developers)
                {
                    double bill = hours * i.HourlyRate;
                    Console.WriteLine($"{i.Name}");
                    Console.WriteLine($"Bill : {bill}$");
                }
            }
        }
        public void Process(int userchoice)
        {
            if (userchoice == 1)
            {
                DeveloperDetails();
                Console.ReadKey();
            }
            else if (userchoice == 2)
            {
                ProjectDetails();
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("invalid choice........");
            }
        }
    }

    class Project
    {
        public string Name { get; set; }
        public double Hours { get; set; }

    }

    interface IDeveloper
    {
        public string Name { get; set; }
        public double HourlyRate { get; set; }
    }
    class Developer : IDeveloper
    {
        public string Name { get; set; }
        public double HourlyRate { get; set; }
    }
    class Program
    {
        public static void Main()
        {
            try
            {
                Menu menu = new Menu();
                menu.MainMenu();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
