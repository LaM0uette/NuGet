using CommonTasks;
using Flaggers;
using Logger;
using Parser;

namespace __Main__
{
    public static class Program
    {
        public static void Main()
        {
            // TestLogger();
            // TestDump();
            // TestDraw();
            // TestArgCli();
            TestParser();

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

        #region Flaggers

        private static void TestArgCli()
        {
            var flgBool = Flags.Bool("e", false);
            var flgStr = Flags.String("a", "Valide");
            var flgByte = Flags.Byte("b", 0);
            var flgInt = Flags.Int("b", 0);
            var flgFloat = Flags.Float("k", 1.1f);
            var flgLstStr = Flags.ListString("i", new List<string>{"test1", "test2", "test3"});
            var flgLstByte = Flags.ListByte("j", new List<byte>{5, 10, 15});
            var flgLstInt = Flags.ListInt("j", new List<int>{5, 10, 15});
            var flgLstFloat = Flags.ListFloat("l", new List<float>{5.5f, 10.5f, 15.5f});
            
            Console.WriteLine($"Bool: {flgBool}");
            Console.WriteLine($"String: {flgStr}");
            Console.WriteLine($"Byte: {flgByte}");
            Console.WriteLine($"Int: {flgInt}");
            Console.WriteLine($"Float: {flgFloat}");

            foreach (var str in flgLstStr)
                Console.WriteLine($"ListString: {str}");
            
            foreach (var i in flgLstByte)
                Console.WriteLine($"ListByte: {i}");
            
            foreach (var i in flgLstInt)
                Console.WriteLine($"ListInt: {i}");
            
            foreach (var i in flgLstFloat)
                Console.WriteLine($"ListFloat: {i}");
        }

        #endregion
        
        //

        #region Parser

        private static void TestParser()
        {
            // bool
            ulong b = 1;
            
            var vBool = "true".ParseToBool();
            var vBool2 = b.ParseToBool();
            var vBool3 = 0.ParseToBool();
            var vBool4 = (-10).ParseToBool();
            
            Console.WriteLine("***** BOOL *****");
            Console.WriteLine($"Type: {vBool.GetType()}  |  Valeur: {vBool}");
            Console.WriteLine($"Type: {vBool2.GetType()}  |  Valeur: {vBool2}");
            Console.WriteLine($"Type: {vBool3.GetType()}  |  Valeur: {vBool3}");
            Console.WriteLine($"Type: {vBool4.GetType()}  |  Valeur: {vBool4}");

            //
            // byte
            var vByte = false.ParseToByte();
            var vByte2 = "50".ParseToByte();
            var vByte3 = 50.6f.ParseToByte();
            var vByte4 = 50.4.ParseToByte();
            var vByte5 = 50.6m.ParseToByte();
            
            Console.WriteLine("\n***** BYTE *****");
            Console.WriteLine($"Type: {vByte.GetType()}  |  Valeur: {vByte}");
            Console.WriteLine($"Type: {vByte2.GetType()}  |  Valeur: {vByte2}");
            Console.WriteLine($"Type: {vByte3.GetType()}  |  Valeur: {vByte3}");
            Console.WriteLine($"Type: {vByte4.GetType()}  |  Valeur: {vByte4}");
            Console.WriteLine($"Type: {vByte5.GetType()}  |  Valeur: {vByte5}");
            
            //
            // int
            var vInt = false.ParseToInt();
            var vInt2 = "50".ParseToInt();
            var vInt3 = 50.4f.ParseToInt();
            var vInt4 = 50.6.ParseToInt();
            var vInt5 = 50.5m.ParseToInt();
            
            Console.WriteLine("\n***** INT *****");
            Console.WriteLine($"Type: {vInt.GetType()}  |  Valeur: {vInt}");
            Console.WriteLine($"Type: {vInt2.GetType()}  |  Valeur: {vInt2}");
            Console.WriteLine($"Type: {vInt3.GetType()}  |  Valeur: {vInt3}");
            Console.WriteLine($"Type: {vInt4.GetType()}  |  Valeur: {vInt4}");
            Console.WriteLine($"Type: {vInt5.GetType()}  |  Valeur: {vInt5}");
            
            //
            // float
            var vFloat = "50.5".ParseToFloat();
            
            Console.WriteLine("\n***** FLOAT *****");
            Console.WriteLine($"Type: {vFloat.GetType()}  |  Valeur: {vFloat}");
            
            //
            // str
            char f = 'É';
            sbyte n = 1;
            var vStr = true.ParseToString(toLower: true);
            var vStr2 = f.ParseToString();
            var vStr3 = n.ParseToString();
            var vStr4 = 21.ParseToString();
            var vStr5 = 10.55.ParseToString();
            
            Console.WriteLine("\n***** STRING *****");
            Console.WriteLine($"Type: {vStr.GetType()}  |  Valeur: {vStr}");
            Console.WriteLine($"Type: {vStr2.GetType()}  |  Valeur: {vStr2}");
            Console.WriteLine($"Type: {vStr3.GetType()}  |  Valeur: {vStr3}");
            Console.WriteLine($"Type: {vStr4.GetType()}  |  Valeur: {vStr4}");
            Console.WriteLine($"Type: {vStr5.GetType()}  |  Valeur: {vStr5}");
        }

        #endregion
    }
}