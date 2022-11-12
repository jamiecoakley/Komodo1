
public class DeveloperTeams
{
    public DeveloperTeams() {}

    public DeveloperTeams
    (
        int teamID,
        string teamName,
        List<Developer> developers
    ) 
    {
        TeamID = teamID;
        TeamName = teamName;
        List<Developer> Developers = developers;
    }


    public string TeamName { get; set; }
    public int TeamID { get; set; } 
    public List<Developer> Developers { get; set; } = new List<Developer>();

    

}

