//Fake database!
public class Developer_Repository
{
    private readonly List<Developer> _devsDb = new List<Developer>();

    private readonly List<DeveloperTeam> _devTeamsDb = new List<DeveloperTeam>();

    private int _count; //this will default to 0

    //CREATE
    public bool Add_Developer(Developer developer)
    {
        //check if content is null
        int startingCount = _devsDb.Count;
        _devsDb.Add(developer);

        if (_devsDb.Count > startingCount)
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
        // foreach (var devFN in _devsDb)
        // {
        //     if (devFN.FirstName == firstName)
        //     {
        //         return devFN;
        //     }
        // }
        // return null;
        return _devsDb.FirstOrDefault(devFN => devFN.FirstName == firstName); //If two developers have the same first name, it will just grab the first one instead of showing both of them.
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
    public Developer GetDeveloperByNoLicense(Developer developer)
    {
        foreach (var devPS in _devsDb)
        {
            if (devPS.HasPluralsight == false)
            {
                return devPS;
            }
        }
        return null;
    }

    // VVV did all of ^^^
    public List<Developer> GetDeveloperByNoLicenseLINQ()
    {
        return _devsDb.Where(dev => dev.HasPluralsight == false).ToList();
    }

    public List<Developer> GetAllDevelopersWithoutPluralsight()
    {
        List<Developer> devsWoPs = new List<Developer>();
        //go into the database, 
        //loop through everything; 
        foreach (var dev in _devsDb)
        {
            //if no pluralsight, 
            var devNoPS = GetDeveloperByNoLicense(dev);
            //add to empty list
            if (devNoPS != null)
            {
                devsWoPs.Add(devNoPS);
            }
        }
        return devsWoPs;
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
            oldInfo.HasPluralsight = updatedInfo.HasPluralsight;
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


