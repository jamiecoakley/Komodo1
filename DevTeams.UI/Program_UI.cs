
public class Program_UI
{
    private readonly Developer_Repository _repo = new Developer_Repository();
    private readonly DevTeams_Repository _teamsRepo = new DevTeams_Repository();
    
    public void Run()
    {
        SeedDeveloperList();
        SeedDeveloperTeamList();
        RunApplication();
    }

    public void RunApplication()
    {
        bool isRunning = true;
        while(isRunning)
        {
            Console.Clear();
            System.Console.WriteLine("Menu:\n" +
                                    "________\n\n" +
                                    "1. Developer Directory\n" +
                                    "2. Developer Team Directory\n" +
                                    "3. Run Pluralsight License Report\n" +
                                    "0. Exit Application"
                                    );
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    DevDirectory();
                    break;
                case "2":
                    DevTeamDirectory();
                    break;
                case "3":
                    GetPluralsightReport();
                    break;
                case "0":
                    isRunning = false;
                    System.Console.WriteLine("Press any key to exit application.");
                    Console.ReadKey();
                    break;
                default:
                    System.Console.WriteLine("Invalid selection. Please try again!");
                    break;

            }
        }
    }



//Run Application Case 1
    private void DevDirectory()
    {
        System.Console.WriteLine("Developer Directory\n" + 
        "________________________\n\n" + 
        "1) Search Developers by First Name\n" +
        "2) Search Developers by Last Name\n" +
        "3) Search Developers by ID Number\n" +
        "4) See All Developers\n" +
        "5) Add New Developer\n" +
        "0) Back to Menu");
        string Input1 = Console.ReadLine();

        switch(Input1)
        {
            case "1":
                SearchDevByFirstName();
                break;
            case "2":
                SearchDevByLastName(); 
                break;
            case "3":
                SearchDevByID();
                break;
            case "4":
                SeeAllDevs();
                break;
            case "5":
                AddDeveloper();
                break;
            case "0":
                Console.Clear();
                return;
            default:
                System.Console.WriteLine("Invalid selection. Please try again!");
                break;

        }

    }

//Run Application Case 2
    private void DevTeamDirectory()
    {
        System.Console.WriteLine("Developer Team Directory\n" + 
                                "__________________________\n\n" +
                                "1) Search Team by Name\n" + 
                                "2) Search Team by ID Number\n" +
                                "3) See all Teams\n" +
                                "0) Return to Menu");
        string Input2 = Console.ReadLine();

        switch(Input2)
        {
            case "1":
                SearchTeamByName();
                break;
            case "2":
                SearchTeamByID();
                break;
            case "3":
                SeeAllDevTeams();
                break;
            case "0":
                Console.Clear();
                return;
            default: 
                System.Console.WriteLine("Invalid selction. Please try again!");
                break;        
        }
    }

    public void SearchTeamByName()
    {
        Console.Clear();
        System.Console.WriteLine("Enter the Team Name:");
        string teamNameInput = Console.ReadLine();

        DeveloperTeam team = _teamsRepo.GetTeamByName(teamNameInput);

        if (team != null)
        {
            SeeTeamDetails(team);
            System.Console.WriteLine("Changes: \n" +
                        "1) Change Team Name\n" +
                        "2) Delete Team\n" +
                        "0) Back to Menu" );
            string updateInput = Console.ReadLine();
            switch(updateInput)
            {
                case "1":
                    //
                    break;
                case "2":
                    //
                    break;
                case "0":
                    Console.Clear();
                    return;           
                default:
                    System.Console.WriteLine("Incorrect input; please try again.");
                    break;
            }
        }
        else
        {
            System.Console.WriteLine("Can't find that team; try again!");
        }
        System.Console.WriteLine("Press any key to return to continue");
        Console.ReadKey();
    }

    public void SearchTeamByID()
    {
        Console.Clear();
        System.Console.WriteLine("Enter the Team ID");
        int teamIDInput = int.Parse(Console.ReadLine());

        DeveloperTeam team = _teamsRepo.GetTeamByID(teamIDInput);

        if (team != null)
        {
            SeeTeamDetails(team);
        }
        else
        System.Console.WriteLine("Can't find that team; try again!");
    }

    private void SeeTeamDetails(DeveloperTeam team)
    {
        System.Console.WriteLine($"Team ID: {team.TeamID}\n" +
                                $" Name: {team.TeamName}\n");
    }

    //Case 3
    private void GetPluralsightReport()
    {
        Console.Clear();
        List<Developer> needsPs = _repo.GetAllDevelopersWithoutPluralsight();            
        if (needsPs.Count > 0)
        {
            foreach (var dev in needsPs)
            {
                SeeAllDevsDetails(dev);
            }
        }
        else
        {
            System.Console.WriteLine("Everyone's got their license!");
        }
        System.Console.WriteLine("Press any key to return to continue");
        Console.ReadKey();
    }

//Dev Directory Case 1
    private void SearchDevByFirstName()
    {
        Console.Clear();
        System.Console.WriteLine("Enter the Developer's First Name:");
        string devFirstNameInput = Console.ReadLine();

        Developer developer = _repo.GetDeveloperByFirstName(devFirstNameInput);

        if (developer != null)
        {
            SeeAllDevsDetails(developer);
        }
        else
        {
            System.Console.WriteLine("Can't find the developer; try again!");
        }
        System.Console.WriteLine("Press any key to return to continue");
        Console.ReadKey();
    }

//Dev Directory Case 2
        private void SearchDevByLastName()
    {
        Console.Clear();
        System.Console.WriteLine("Enter the Developer's Last Name:");
        string devLastNameInput = Console.ReadLine();

        Developer developer = _repo.GetDeveloperByLastName(devLastNameInput);

        if (developer != null)
        {
            SeeAllDevsDetails(developer);
        }
        else
        {
            System.Console.WriteLine("Can't find the developer; try again!");
        }
        System.Console.WriteLine("Press any key to return to continue");
        Console.ReadKey();
    }

//Dev Directory Case 3
        private void SearchDevByID()
    {
        Console.Clear();
        System.Console.WriteLine("Enter the Developer's ID Number:");
        int devIDInput = int.Parse(Console.ReadLine());


        Developer developer = _repo.GetDeveloperByID(devIDInput);

        if (developer != null)
        {
            SeeAllDevsDetails(developer);
            System.Console.WriteLine("Changes: \n" +
                        "1) Add Developer to a Team\n" +
                        "2) Change Developer Name\n" +
                        "3) Delete Developer\n" +
                        "0) Back to Menu" );
            
            string updateInput = Console.ReadLine();
            switch(updateInput)
            {
                case "1":
                    //
                    break;
                case "2":
                    //
                    break;
                case "3":
                    //
                    break;
                case "0":
                    Console.Clear();
                    return;           
                default:
                    System.Console.WriteLine("Incorrect input; please try again.");
                    break;
            }
        }
        else
        {
            System.Console.WriteLine("Can't find the developer; try again!");
        }
    }

    

//Dev Directory Case 4
    private void SeeAllDevs()
    {
        Console.Clear();
        List<Developer> listOfDevs = _repo.GetAllDevelopers();

        if (listOfDevs.Count>0)
        {
            foreach(var dev in listOfDevs)
            {
                SeeAllDevsDetails(dev);
            }
        }
        else
        {
            System.Console.WriteLine("Can't find the developers; please try again.");
        }
        Console.ReadKey();
    }
    

        private void SeeAllDevsDetails(Developer dev)
    {
        System.Console.WriteLine($"Developer ID: {dev.ID}\n" +
                                $" Name: {dev.FullName}\n" +
                                $"Has Pluralslight License: {dev.HasPluralsight}\n");
    }

    private void SeeAllDevTeams()
        {
            Console.Clear();
            List<DeveloperTeam> listOfDevTeams = _teamsRepo.SeeAllTeams();

            if (listOfDevTeams.Count>0)
            {
                foreach(var team in listOfDevTeams)
                {
                    SeeAllDevTeamDetails(team);
                }
            }
            else
            {
                System.Console.WriteLine("Can't find the team; please try again.");
            }
            Console.ReadKey();
        }
    private void SeeAllDevTeamDetails(DeveloperTeam team)
    {
        System.Console.WriteLine($"Developer Team ID: {team.TeamID}/n" +
                                $"Developer Team Name: {team.TeamName}"
        );
    }

//Case 5
    private void AddDeveloper() //cookie cutter!
    {
        Console.Clear();
        Developer dev = new Developer();
        System.Console.WriteLine("Input Developer's first name.");
        dev.FirstName = Console.ReadLine();
        System.Console.WriteLine("Input Developer's last name.");
        dev.LastName = Console.ReadLine();
        System.Console.WriteLine("Does this developer have Pluralsight? (y/n)");
        string userInput = Console.ReadLine();
        if (userInput == "y".ToLower())
        {
            dev.HasPluralsight = true;
        }
        else //if user types anything but "y"
        {
            dev.HasPluralsight = false;
        }

        if (_repo.Add_Developer(dev))
        {
            System.Console.WriteLine("SUCCESS!");
        }
        else
        {
            System.Console.WriteLine("FAILURE.");
        }
        Console.ReadKey();
    }

    public void DeleteDeveloper()
    {
        Console.Clear();

    }

    private void AddDeveloperToTeam()
    {

    }

    private void SeedDeveloperList()
    {
        Developer dev1 = new Developer(1, "Stan", "Marsh", true);   
        Developer dev2 = new Developer(2, "Kyle", "Broflovski", true);
        Developer dev3 = new Developer(3, "Eric", "Cartman", true);
        Developer dev4 = new Developer(4, "Kenny", "McCormick", true);
        Developer dev5 = new Developer(5, "Tina", "Belcher", false);
        Developer dev6 = new Developer(6, "Jimmy Jr.", "Pesto", false);
        Developer dev7 = new Developer(7, "Calvin", "Fischoder", false);
        Developer dev8 = new Developer(8, "Linda", "Belcher", false);

        _repo.Add_Developer(dev1);
        _repo.Add_Developer(dev2);
        _repo.Add_Developer(dev3);
        _repo.Add_Developer(dev4);
        _repo.Add_Developer(dev5);
        _repo.Add_Developer(dev6);
        _repo.Add_Developer(dev7);
        _repo.Add_Developer(dev8);
    }

    private void SeedDeveloperTeamList()
    {
        // //List<Developer>dList1 = new List<Developer>(DeveloperTeams teamName, DeveloperTeams teamID);
        // DeveloperTeam devTeam1 = new DeveloperTeams(1000, "Team SouthPark", List<Developer>());
        // DeveloperTeam devTeam2 = new DeveloperTeams(2000, "Team FamilyGuy", List<Developer>());
        // DeveloperTeam devTeam3 = new DeveloperTeams(3000, "Team BobsBurgers", List<Developer>());

        // _teamsRepo.Add_Team(devTeam1);
        // _teamsRepo.Add_Team(devTeam2);
        // _teamsRepo.Add_Team(devTeam3);

    }
}