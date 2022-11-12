
public class DevTeams_Repository
{
    private readonly List<DeveloperTeams> _devTeamsDb = new List<DeveloperTeams>();


//CREATE
public bool Add_Team(DeveloperTeams team)
    {
        int startingCount = _devTeamsDb.Count;
        _devTeamsDb.Add(team);

        if(_devTeamsDb.Count > startingCount)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


//READ
    public List<DeveloperTeams> SeeAllTeams()
    {
        return _devTeamsDb;
    }


UPDATE
    public Developer_Repository AddDevToTeam(Developer developer)
    {
        if()
        {devTeam1.Add(developer)}
    }

//DELETE
}



