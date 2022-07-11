using Logger;

namespace __Main__
{
    public static class Program
    {
        public static void Main()
        {
            var log = new Log();
            
            log.Ok("Salut je suis un ok");
            log.Nok("Salut je suis un nok");
            log.Info("Salut je suis un info");
            log.Param("Salut je suis un paramètre");
            log.Val("Salut je suis une validation");
            log.Err("Salut je suis une erreur");
            log.Crash("Salut je suis un crash");
            
            Console.ReadLine();
        }
    }
}

/*
 static async Task Main()
{    const string pgHost = "BORDEAUX04";
    const string pgUser = "postgres";
    const string pgPassword = "INEO_Infracom_33";
    const string pgDatabase = "sig";
    await using var conn = new NpgsqlConnection(@$"HOST={pgHost};Username={pgUser};Password={pgPassword};Database={pgDatabase}");
    await conn.OpenAsync();
    conn.Notification += (_, e) =>
    {
        Console.WriteLine("Received notification: " + e.Payload);
    };
    await using var cmd = new NpgsqlCommand("LISTEN datachange;", conn);
    cmd.ExecuteNonQuery();
    while (true) 
        await conn.WaitAsync();
}
*/