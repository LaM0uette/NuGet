using Logger;

namespace __Main__
{
    public static class Program
    {
        public static void Main()
        {
            var log = new Log();
            log.Info("Salut je suis un info");
            log.Param("Salut je suis un paramètre");

            Console.ReadLine();
        }
    }
}
