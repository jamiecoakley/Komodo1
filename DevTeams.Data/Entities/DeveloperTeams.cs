
public class DeveloperTeam //blueprint for a developer team
{
    public DeveloperTeam() {} //<<empty constructor - put it there even if it's not used.

//vv constructor - allows us to assign values on the fly
    public DeveloperTeam(int teamID, string teamName, List<Developer> developers) //full constructor to be able to create a developer team
    {
        TeamID = teamID;
        TeamName = teamName;
        Developers = developers; //didn't run when I had the List<Developer> in front of it; keep this simple (for now)
    }

    public DeveloperTeam(int teamID, string teamName) //method overloading - having all three of these constructors.
    {
        TeamID = teamID;
        TeamName = teamName;
    }


//VV   properties
    public string TeamName { get; set; } //get = we can read the value; set = we can write to/change the value
    public int TeamID { get; set; } 
    public List<Developer> Developers { get; set; } = new List<Developer>(); //<<needs to be here to allocate the space for the list in memory

    

}

