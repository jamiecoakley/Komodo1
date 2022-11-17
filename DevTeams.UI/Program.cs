Program_UI UI = new Program_UI();
UI.Run();

DeveloperTeam dTeam = new DeveloperTeam(); //<<constructor representing line 4 in DeveloperTeams.cs

dTeam.TeamName = "TeamSouthPark";
dTeam.TeamID = 12;
dTeam.Developers = new List<Developer>();

DeveloperTeam dTeam2 = new DeveloperTeam(13, "TeamBobsBurgers", 
new List<Developer>()
{
    new Developer
    {
        ID = 1,
        FirstName = "Stan",
        LastName = "Marsh",
        HasPluralsight = true
    },

    new Developer
    {
        ID = 2,
        FirstName = "Kyle",
        LastName = "Broflovski",
        HasPluralsight = false
    }
});

System.Console.WriteLine(dTeam2.TeamName);
System.Console.WriteLine(dTeam2.TeamID);
foreach(var dev in dTeam2.Developers)
{
    System.Console.WriteLine(dev.FullName);
    System.Console.WriteLine(dev.ID);
    System.Console.WriteLine(dev.HasPluralsight);
}
Console.ReadKey();