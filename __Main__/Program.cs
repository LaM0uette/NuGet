using System.Diagnostics;
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

            for (var i = 0; i < 100; i++)
            {
                log.Progress("Chargement", i+1, 100);
                Thread.Sleep(20);
            }
            
            Console.ReadLine();
        }
    }
}
