//Fake database!
public class Developer_Repository
{
    private readonly List<Developer> _devsDb = new List<Developer>();

    private readonly List<DeveloperTeams>_devTeamsDb = new List<DeveloperTeams>();

    private int _count; //this will default to 0

//CREATE
    public bool Add_Developer(Developer developer)
    {
        //check if content is null
        int startingCount = _devsDb.Count;
        _devsDb.Add(developer);

        if(_devsDb.Count > startingCount)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    

//READ (Get one by full name)
    public Developer GetDeveloperByFullName(string fullName)
    {
        foreach (var dev in _devsDb)
        {
            if (dev.FullName == fullName)
            {
                return dev;
            }
        }
        return null;
    }

    //(Get by last name)
    public Developer GetDeveloperByLastName(string lastName)
    {
        foreach (var devLN in _devsDb)
        {
            if (devLN.LastName == lastName)
            {
                return devLN;
            }
        }
        return null;
    }

        //(Get by first name)
    public Developer GetDeveloperByFirstName(string firstName)
    {
        foreach (var devLN in _devsDb)
        {
            if (devLN.FirstName == firstName)
            {
                return devLN;
            }
        }
        return null;
    }

    //(Get by ID#)
    public Developer GetDeveloperByID(int ID)
    {
        foreach (var devID in _devsDb)
        {
            if (devID.ID == ID)
            {
                return devID;
            }
        }
        return null;
    }

    //(Get by doesn't have PluralSight)
    public Developer GetDeveloperByNoLicense(Developer hasPluralsight)
    {
        Developer HasPluralsight = hasPluralsight;
        foreach (var devPS in _devsDb)
        {
            if (devPS.HasPluralsight == false)
            {
                return devPS;
            }
        }
        return null;
    }
    
    //(Get all developers)
    public List<Developer> GetAllDevelopers()
    {
        return _devsDb;
    }

//UPDATE
    public bool UpdateDeveloper(int originalInfo, Developer updatedInfo)
    {
        Developer oldInfo = GetDeveloperByID(originalInfo);

        if (oldInfo != null)
        {
            oldInfo.FirstName = updatedInfo.FirstName;
            oldInfo.LastName = updatedInfo.LastName;
            return true;
        }
        else
        {
            return false;
        }

    }

//DELETE
    public bool DeveloperGotFired(Developer developer)
    {
        bool firedDeveloper = _devsDb.Remove(developer);
        return firedDeveloper;
    }
}


