public class Orm : IDisposable
{
    private Database database;

    public Orm(Database database)
    {
        this.database = database;
    }

    public void Begin()
    {
        if(database.DbState == Database.State.Closed)
        {
            database.BeginTransaction();
        }
        else
        {
            throw new InvalidOperationException();
        }
    }

    public void Write(string data)
    {
        if(database.DbState == Database.State.TransactionStarted)
        {
            try
            {
                database.Write(data);
            }
            catch(InvalidOperationException)
            {
                Dispose(); 
            }
            
        }
        else
        {
            Dispose();
        }
    }

    public void Commit()
    {
        if(database.DbState == Database.State.DataWritten)
        {
            try
            {
                database.EndTransaction();
            }
            catch(InvalidOperationException)
            {
                Dispose(); 
            }
        }
        else
        {
            Dispose();
        }
    }

    public void Dispose()
    {
        database.Dispose();
    }

}
