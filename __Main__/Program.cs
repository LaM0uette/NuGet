using CommonTasks;
using Logger;

namespace __Main__
{
    public static class Program
    {
        public static void Main()
        {
            // TestLogger();
            // TestDump();
            // TestDraw();
            TestArgCli();

            Console.ReadLine();
        }

        //

        #region Logger

        private readonly struct DumpStruct
        {
            private string Col1 { get; }
            private string Col2 { get; }
            private string Col3 { get; }

            public DumpStruct(string col1, string col2, string col3)
            {
                Col1 = col1;
                Col2 = col2;
                Col3 = col3;
            }

            public override string ToString()
            {
                return $"{Col1};{Col2};{Col3}";
            }
        }

        private static void TestLogger()
        {
            var log = new Log();

            log.Separator("OK / NOK");
            log.Ok("Salut je suis un ok");
            log.Ok("Salut je suis un ok cmd", Log.TypeLog.Cmd);
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
                log.Progress("Chargement", i + 1, 100);
                Thread.Sleep(5);
            }
            log.Void(typeLog: Log.TypeLog.Cmd);
            log.Ok("Terminé !", Log.TypeLog.All);

            log.Separator("BILAN");
            log.Category("Titre de la categorie");
            log.SubCategory("Titre de la Subcategorie", "Valeur du bilan");
            log.Description("Titre", "Valeur");
        }

        private static void TestDump()
        {
            var dump1 = new Dump(name: "Dump1");
            var dump2 = new Dump(name: "Dump2");
            var dump3 = new Dump(name: "Dump3");

            var stc = new DumpStruct("Salut", "Bonjour", "MaBite");
            dump1.String(stc.ToString());
            dump1.String(stc.ToString());
            dump1.String(stc.ToString());

            var arr = new[] {"Salut", "Bonjour", "MaBite"};
            dump2.StringArray(arr);
            dump2.StringArray(arr);
            dump2.StringArray(arr);

            var lst = new List<string> {"Salut", "Bonjour", "MaBite"};
            dump3.StringList(lst);
            dump3.StringList(lst);
            dump3.StringList(lst);
        }

        private static void TestDraw()
        {
            var log = new Log();
            
            const string author = "LaM0uette";
            const string version = "1.0.2";
            const string logo = @"
        ███████╗██╗██╗     ███████╗██████╗ ██╗██████╗ 
        ██╔════╝██║██║     ██╔════╝██╔══██╗██║██╔══██╗
        █████╗  ██║██║     █████╗  ██║  ██║██║██████╔╝
        ██╔══╝  ██║██║     ██╔══╝  ██║  ██║██║██╔══██╗
        ██║     ██║███████╗███████╗██████╔╝██║██║  ██║
        ╚═╝     ╚═╝╚══════╝╚══════╝╚═════╝ ╚═╝╚═╝  ╚═╝";
            
            log.DrawStart(logo, author, version);
            
            log.Separator("INIT");
            log.Ok("test");
            log.DrawParam("Poolsize mis sur", "5");
            log.DrawParam("Poolsize mis sur", "5", "Test", "Autres test");
            
            
            log.DrawEnd(author, version);
            
        }

        #endregion
        
        //

        private static void TestArgCli()
        {
            Console.WriteLine(string.Join(" ", Environment.GetCommandLineArgs()));
        }
    }
}