using System;
using System.IO;
using System.Windows.Forms;

namespace Generator.Classes
{
    public class CodeWriter
    {
        private string DPath { get; set; }
        private string BPath { get; set; }
        private CodeBuilder Builder { get; set; }

        private string DAPath => DPath + "Abstract\\";
        private string DCPath => DPath + "Concrete\\";
        private string BAPath => BPath + "Abstract\\";
        private string BCPath => BPath + "Concrete\\";
        private string IRPath => DAPath + Builder.HelperStrings.IRepo + ".cs";
        private string RPath => DCPath + Builder.HelperStrings.Repo + ".cs";
        private string SPath => BAPath + Builder.HelperStrings.Service + ".cs";
        private string MPath => BCPath + Builder.HelperStrings.Manager + ".cs";
        private string CPath => DCPath + Builder.Context + ".cs";
        private string DMPath => DCPath + "Mappings\\" + Builder.HelperStrings.Entity + "Map.cs";

        public CodeWriter(string dPath, string bPath, CodeBuilder builder)
        {
            DPath = dPath;
            BPath = bPath;
            Builder = builder;
        }

        private void WriteToFile(string file, string content)
        {
            try
            {
                using (var writer = new StreamWriter(file))
                    writer.Write(content);
            }
            catch (Exception exception)
            {
                MessageBox.Show("We ran into a few problem : \n" + exception.Message, "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool Generate()
        {
            var result = true;
            var codes = Builder.BuildCode();

            if (codes == null)
                return false;

            WriteToFile(IRPath, codes["irepo"]);
            WriteToFile(RPath, codes["repo"]);
            WriteToFile(CPath, codes["context"]);
            WriteToFile(DMPath, codes["map"]);
            WriteToFile(SPath, codes["service"]);
            WriteToFile(MPath, codes["manager"]);


            return result;
        }

    }
}
