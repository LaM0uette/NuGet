using Logger;

namespace __Main__
{
    public static class Program
    {
        public static void Main()
        {
            TestLogger();
            TestDump();
            Console.ReadLine();
        }
        
        private static void TestLogger()
        {
            var log = new Log();

            log.Separator("OK / NOK");
            log.Ok("Salut je suis un ok");
            log.Ok("Salut je suis un ok", Log.TypeLog.Cmd);
            log.Nok("Salut je suis un nok");
            log.Nok("Salut je suis un nok", Log.TypeLog.Log);
            
            log.Separator("CONFIG");
            log.Info("Salut je suis une info");
            log.Param("Salut je suis un paramètre");
            log.Param("Salut je suis le paramètre N°", $"{5}");
            
            log.Separator("ETATS");
            log.Val("Salut je suis une validation");
            log.Val("Salut j'ai validé le check : ", $"{12}");
            log.Err("Salut je suis une erreur");
            log.Crash("Salut je suis un crash");
            
            log.Separator("VOID");
            log.Void("Salut je suis un void");
            log.VoidBlue("Salut je suis un void blue");
            log.VoidGreen("Salut je suis un void vert");
            log.VoidRed("Salut je suis un void rouge");
            log.VoidPink("Salut je suis un void rose");

            log.Separator("PROGRESS");
            for (var i = 0; i < 100; i++)
            {
                log.Progress("Chargement", i+1, 100);
                Thread.Sleep(20);
            }
            
            log.Separator("BILAN");
            log.Category("Titre de la categorie");
            log.SubCategory("Titre de la Subcategorie", "Valeur du bilan");
            log.Description("Titre", "Valeur");
        }

        private static void TestDump()
        {
            var dump = new Dump();

            var lst = new List<string>();
            
            lst.Add("Salut");
            lst.Add("Bopnjour");
            lst.Add("MaBite");
            
            dump.WriteDump(lst);
        }
    }
}
