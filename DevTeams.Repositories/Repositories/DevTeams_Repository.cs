
public class DevTeams_Repository
{
    private readonly List<DeveloperTeam> _devTeamsDb = new List<DeveloperTeam>();


//CREATE
    public bool Add_Team(DeveloperTeam team)
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
    public List<DeveloperTeam> SeeAllTeams()
    {
        return _devTeamsDb;

    }

    public DeveloperTeam GetTeamByName(string name)
    {
        foreach (var devTeam in _devTeamsDb)
        {
            if (devTeam.TeamName == name)
            {
                return devTeam;
            }
        }
        return null;
    }

    public DeveloperTeam GetTeamByID(int ID) 
    {
        foreach (var devTeam in _devTeamsDb)
        {
            if (devTeam.TeamID == ID)
            {
                return devTeam;
            }
        }
        return null;
    }


//UPDATE - just want to update the dev team                 VV data retrieved from a form
    public bool UpdateDeveloperTeam(int id, DeveloperTeam updatedDevTeamData) //make it a bool to tell the UI  if it worked or not - "up-serting" data
    {
        //we want to grab the ID since that is the unique identifier
        var oldDevTeamData = GetTeamByID(id);
        if (oldDevTeamData != null)
        {
            oldDevTeamData.TeamName = updatedDevTeamData.TeamName;
            oldDevTeamData.Developers = updatedDevTeamData.Developers;
            return true;
        }
        return false;
    }

//DELETE
    public bool DeleteDeveloperTeam(int id)
    {
        var oldDevTeamData = GetTeamByID(id);
        return _devTeamsDb.Remove(oldDevTeamData); //bool included in Remove method
    }

}



