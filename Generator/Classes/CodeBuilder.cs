using System.Collections.Generic;
using System.Data.Entity.Design.PluralizationServices;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace Generator.Classes
{
    public class CodeBuilder
    {
        private string _context;
        public string Context
        {
            get
            {
                return _context + "Context";
            }
            set
            {
                _context = value;
            }
        }

        public HelperStrings HelperStrings { get; set; }
        private string DPath { get; set; }
        private string PPath { get; set; }

        public CodeBuilder(string ppath, string dpath, string context, HelperStrings helperStrings)
        {
            Context = context;
            HelperStrings = helperStrings;
            DPath = dpath;
            PPath = ppath;
        }

        public string GetIRResult()
        {
            return HelperStrings.IRUsings + "\n\nnamespace " + HelperStrings.IRNS + "\n{\n\tpublic interface " + HelperStrings.IRepo + " : IEntityRepository<" + HelperStrings.Entity + ">\n\t{\n\t}\n}\n";
        }

        public string GetRResult()
        {
            return HelperStrings.RUsings + "\n\nnamespace " + HelperStrings.RNS + "\n{\n\tpublic class " + HelperStrings.Repo + " : EfEntityRepositoryBase<"
                        + HelperStrings.Entity + ", " + Context + ">, " + HelperStrings.IRepo + "\n\t{\n\t}\n}";
        }

        public string GetSResult()
        {
            return HelperStrings.SUsings + "\n\nnamespace " + HelperStrings.SNS + "\n{\n\tpublic interface "
                         + HelperStrings.Service + "\n\t{\n\t\tvoid Add(" + HelperStrings.Entity + " " + HelperStrings.LEntity + ");\n"
                         + "\t\tvoid Update(" + HelperStrings.Entity + " " + HelperStrings.LEntity + ");\n"
                         + "\t\tvoid Delete(" + HelperStrings.Entity + " " + HelperStrings.LEntity + ");\n"
                         + "\t\tvoid DeleteAll();\n"
                         + "\t\t" + HelperStrings.Entity + " Get(int id);\n"
                         + "\t\tList<" + HelperStrings.Entity + "> GetAll();\n\t}\n}";
        }

        public string GetMResult()
        {
            return HelperStrings.MUsings + "\n\nnamespace " + HelperStrings.MNS + "\n{\n\tpublic class " + HelperStrings.Manager + " : " + HelperStrings.Service + "\n\t{\n"
                     + "\t\tprivate readonly " + HelperStrings.IRepo + " " + HelperStrings.FEntity + "Repository;\n\n"
                     + "\t\tpublic " + HelperStrings.Manager + "(" + HelperStrings.IRepo + " " + HelperStrings.LEntity + "Repository)\n\t\t{\n"
                     + "\t\t\t" + HelperStrings.FEntity + "Repository = " + HelperStrings.LEntity + "Repository;\n\t\t}\n\n"
                     + "\t\tpublic void Add(" + HelperStrings.Entity + " " + HelperStrings.LEntity + ")\n\t\t{\n"
                     + "\t\t\t" + HelperStrings.FEntity + "Repository.Add(" + HelperStrings.LEntity + ");\n\t\t}\n\n"
                     + "\t\tpublic void Update(" + HelperStrings.Entity + " " + HelperStrings.LEntity + ")\n\t\t{\n"
                     + "\t\t\t" + HelperStrings.FEntity + "Repository.Update(" + HelperStrings.LEntity + ");\n\t\t}\n\n"
                     + "\t\tpublic void Delete(" + HelperStrings.Entity + " " + HelperStrings.LEntity + ")\n\t\t{\n"
                     + "\t\t\t" + HelperStrings.FEntity + "Repository.Add(" + HelperStrings.LEntity + ");\n\t\t}\n\n"
                     + "\t\tpublic void DeleteAll()\n\t\t{\n"
                     + "\t\t\t" + HelperStrings.FEntity + "Repository.DeleteAll();\n\t\t}\n\n"
                     + "\t\tpublic " + HelperStrings.Entity + " Get(int id)\n\t\t{\n"
                     + "\t\t\treturn " + HelperStrings.FEntity + "Repository.Get(x => x.Id == id);\n\t\t}\n\n"
                     + "\t\tpublic List<" + HelperStrings.Entity + "> GetAll()\n\t\t{\n"
                     + "\t\t\treturn " + HelperStrings.FEntity + "Repository.GetAll();\n\t\t}\n\t}\n}";
        }

        public string GetCResult()
        {
            var result = "";
            var path = DPath + "Concrete\\" + Context + ".cs";

            if (File.Exists(path))
            {
                var file = File.ReadAllText(path);

                if (!file.Contains("<" + HelperStrings.Entity + ">"))
                {
                    var index = file.IndexOf("DbSets") + 7;

                    file = file.Insert(index, "\n\t\tpublic DbSet<" + HelperStrings.Entity + "> " + PluralizationService.CreateService(CultureInfo.CurrentCulture).Pluralize(HelperStrings.Entity) + " { get; set; }");
                }

                if (!file.Contains(HelperStrings.Entity + "Map"))
                {
                    var mindex = file.IndexOf("modelBuilder") + 22;

                    if (mindex == 21)
                    {
                        file = file.Insert(file.IndexOf("#endregion") + 11, "\n\t\tprotected override void OnModelCreating(DbModelBuilder modelBuilder)\n\t\t{\n\n\t\t}\n");
                    }

                    mindex = file.IndexOf("modelBuilder") + 18;

                    result = file.Insert(mindex, "\t\t\tmodelBuilder.Configurations.Add(new " + HelperStrings.Entity + "Map());\n");
                }

            }
            else
            {
                result = "using System.Data.Entity;\nusing Entities.Concrete;\n\nnamespace " + HelperStrings.RNS + "\n{\n\tpublic class " + Context
                            + "\n\t{\n\t\t#region DbSets\n\n\t\tpublic DbSet<" + HelperStrings.Entity + "> "
                            + PluralizationService.CreateService(CultureInfo.CurrentCulture).Pluralize(HelperStrings.Entity)
                            + " { get; set; }\n\n\t\t#endregion\n\n\t\tprotected override void OnModelCreating(DbModelBuilder modelBuilder)\n"
                            + "\t\t{\n\t\t\tmodelBuilder.Configurations.Add(new " + HelperStrings.Entity + "Map());\n\t\t}\n\t}\n}";
            }

            return result;
        }

        public string GetDMResult()
        {
            return "using Entities.Concrete;\nusing System.Data.Entity.ModelConfiguration;\n\nnamespace " + HelperStrings.RNS + ".Mappings\n{\n\tpublic class "
                         + HelperStrings.Entity + "Map : EntityTypeConfiguration<" + HelperStrings.Entity + ">\n\t{\n"
                         + "\t\tpublic " + HelperStrings.Entity + "Map()\n\t\t{\n\t\t\tToTable(\"" + PluralizationService.CreateService(CultureInfo.CurrentCulture).Pluralize(HelperStrings.Entity) + "\");\n\t\t\tHasKey(e => e.Id);\n"
                         + "\t\t\tProperty(e => e.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);\n\n" + CreateMapStr(GetEntityProperties(HelperStrings.Entity)) + "\t\t}\n\t}\n}";
        }

        private List<string> GetEntityProperties(string entity)
        {
            var result = new List<string>();

            var fileName = PPath + "\\Entities\\Concrete\\" + entity + ".cs";
            if (!File.Exists(fileName))
            {
                MessageBox.Show("Entity not found, but map class was created with default codes.", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return result;
            }

            var file = File.ReadAllLines(fileName);

            foreach (var line in file)
            {
                if (line.Contains("get;"))
                    result.Add(line.Trim().Split()[1] + " " + line.Trim().Split()[2]);
            }

            return result;
        }

        private string CreateMapStr(List<string> properties)
        {
            var result = "";

            foreach (var property in properties)
            {
                result += "\t\t\tProperty(e => e." + property.Split()[1] + ").HasColumnName(\"" + property.Split()[1] + "\");\n";
            }

            return result;
        }

        public Dictionary<string, string> BuildCode()
        {
            var path = PPath + "\\Entities\\Concrete";
            var epath = PPath + "\\Entities\\Concrete\\" + HelperStrings.Entity + ".cs";
            if (!Directory.Exists(path))
            {
                MessageBox.Show("Entities folder was not found. Please, create this folder under your project path and try again", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            else if (!File.Exists(epath))
            {
                MessageBox.Show("Entity was not found. Please, create entity and try again", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            return new Dictionary<string, string>
            {
                { "irepo", GetIRResult() },
                { "repo", GetRResult() },
                { "service", GetSResult() },
                { "manager", GetMResult() },
                { "context", GetCResult() },
                { "map", GetDMResult() }
            };
        }
    }
}
