public class Orm
{
    private Database database;

    public Orm(Database database)
    {
        this.database = database;
    }

    public void Write(string data)
    {
        database.BeginTransaction();

        try
        {
            database.Write(data);
            database.EndTransaction();
            database.Dispose();
        }
        catch (InvalidOperationException)
        {

            database.Dispose();
            throw;
        }
       
    }

    public bool WriteSafely(string data)
    {
        try
        {
            database.BeginTransaction();
            database.Write(data);
            database.EndTransaction();
            return true;
        }
        catch (InvalidOperationException)
        {
            database.Dispose();
            return false;
            
        }
    }
}
