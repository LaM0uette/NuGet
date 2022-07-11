using Logger;

namespace __Main__
{
    public static class Program
    {
        public static void Main()
        {
            var log = new Log();
            log.Info("test");
            log.Info("test bis");
            
            Thread.Sleep(5000000);
        }
    }
}
