using System;
using System.Collections.Generic;
using System.Data.Entity.Design.PluralizationServices;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Generator
{
    public partial class Generator : Form
    {
        #region Dll import

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );

        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private static extern void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private static extern void SendMessage(IntPtr hWnd, int wMessage, int wParam, int lParam);

        #endregion

        #region Fields / Default Options

        string entity, projectPath, dataAccessPath, dataAccessNamespace, businessPath, businessNamespace, context, dataAccessAbstract, dataAccessConcrete, businessAbstract, businessConcrete;
        bool needSave;

        #endregion

        public Generator()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 50, 50));

            entity = ConfigurationHelper.GetAppSetting("entity");
            projectPath = ConfigurationHelper.GetAppSetting("projectPath");
            dataAccessPath = ConfigurationHelper.GetAppSetting("dataAccessPath");
            dataAccessNamespace = ConfigurationHelper.GetAppSetting("dataAccessNamespace");
            businessPath = ConfigurationHelper.GetAppSetting("businessPath");
            businessNamespace = ConfigurationHelper.GetAppSetting("businessNamespace");
            context = ConfigurationHelper.GetAppSetting("context");
            dataAccessAbstract = ConfigurationHelper.GetAppSetting("dataAccessAbstract");
            dataAccessConcrete = ConfigurationHelper.GetAppSetting("dataAccessConcrete");
            businessAbstract = ConfigurationHelper.GetAppSetting("businessAbstract");
            businessConcrete = ConfigurationHelper.GetAppSetting("businessConcrete");
            needSave = false;

            LoadAppOptions();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (CheckInputs())
                return;

            if (needSave)
                OpenMessageWindowAndDoAction();

            var thMain = new Thread(Run);
            thMain.Start();
        }

        private void Run() // Refactor this
        {
            lblOperations.Invoke(new MethodInvoker(delegate ()
            {
                lblOperations.Text = "";
            }));

            var thread = 200;
            var entity = GetEntity(tbxEntity.Text);
            var lentity = entity.Substring(0, 1).ToLower() + entity.Substring(1, entity.Length - 1);
            var fentity = "_" + lentity;
            var irepo = "I" + entity + "Repository";
            var repo = entity + "Repository";
            var service = "I" + entity + "Service";
            var manager = entity + "Manager";

            var th1 = new Thread(() =>
            {
                WriteOperation(entity + " :\nHelper strings created...");
            });
            th1.Start();
            Thread.Sleep(thread);

            var irusings = CreateUsingStr(tbxDataAccessAbstract.Text.Trim());
            var rusings = CreateUsingStr(tbxDataAccessConcrete.Text.Trim());
            var susings = CreateUsingStr(tbxBusinessAbstract.Text.Trim());
            var musings = CreateUsingStr(tbxBusinessConcrete.Text.Trim());

            var th2 = new Thread(() =>
            {
                WriteOperation("Usings prepared...");
            });
            th2.Start();
            Thread.Sleep(thread);

            var irns = tbxDataAccessNamespace.Text.Split(',')[0];
            var rns = tbxDataAccessNamespace.Text.Split(',')[1];
            var sns = tbxBusinessNamespace.Text.Split(',')[0];
            var mns = tbxBusinessNamespace.Text.Split(',')[1];

            var th3 = new Thread(() =>
            {
                WriteOperation("Namespaces figured out...");
            });
            th3.Start();
            Thread.Sleep(thread);

            var dpath = tbxDataAccessPath.Text;

            var irresult = irusings + "\n\nnamespace " + irns + "\n{\n\tpublic interface " + irepo + " : IEntityRepository<" + entity + ">\n\t{\n\t}\n}\n";

            var rresult = rusings + "\n\nnamespace " + rns + "\n{\n\tpublic class " + repo + " : EfEntityRepositoryBase<" + entity + ", " + tbxContext.Text
                        + "Context>, " + irepo + "\n\t{\n\t}\n}";

            var irpath = dpath + "\\Abstract\\" + irepo + ".cs";
            var rpath = dpath + "\\Concrete\\" + repo + ".cs";

            var th4 = new Thread(() =>
            {
                WriteOperation("Data acces code finished...");
            });
            th4.Start();
            Thread.Sleep(thread);

            var bpath = tbxBusinessPath.Text;

            var spath = bpath + "\\Abstract\\" + service + ".cs";
            var mpath = bpath + "\\Concrete\\" + manager + ".cs";

            var sresult = "";
            var mresult = "";
             
            sresult = susings + "\n\nnamespace " + sns + "\n{\n\tpublic interface "
                         + service + "\n\t{\n\t\tvoid Add(" + entity + " " + lentity + ");\n"
                         + "\t\tvoid Update(" + entity + " " + lentity + ");\n"
                         + "\t\tvoid Delete(" + entity + " " + lentity + ");\n"
                         + "\t\tvoid DeleteAll();\n"
                         + "\t\t" + entity + " Get(int id);\n"
                         + "\t\tList<" + entity + "> GetAll();\n\t}\n}";

            mresult = musings + "\n\nnamespace " + mns + "\n{\n\tpublic class " + manager + " : " + service + "\n\t{\n"
                     + "\t\tprivate readonly " + irepo + " " + fentity + "Repository;\n\n"
                     + "\t\tpublic " + manager + "(" + irepo + " " + lentity + "Repository)\n\t\t{\n"
                     + "\t\t\t" + fentity + "Repository = " + lentity + "Repository;\n\t\t}\n\n"
                     + "\t\tpublic void Add(" + entity + " " + lentity + ")\n\t\t{\n"
                     + "\t\t\t" + fentity + "Repository.Add(" + lentity + ");\n\t\t}\n\n"
                     + "\t\tpublic void Update(" + entity + " " + lentity + ")\n\t\t{\n"
                     + "\t\t\t" + fentity + "Repository.Update(" + lentity + ");\n\t\t}\n\n"
                     + "\t\tpublic void Delete(" + entity + " " + lentity + ")\n\t\t{\n"
                     + "\t\t\t" + fentity + "Repository.Add(" + lentity + ");\n\t\t}\n\n"
                     + "\t\tpublic void DeleteAll()\n\t\t{\n"
                     + "\t\t\t" + fentity + "Repository.DeleteAll();\n\t\t}\n\n"
                     + "\t\tpublic " + entity + " Get(int id)\n\t\t{\n"
                     + "\t\t\treturn " + fentity + "Repository.Get(x => x.Id == id);\n\t\t}\n\n"
                     + "\t\tpublic List<" + entity + "> GetAll()\n\t\t{\n"
                     + "\t\t\treturn " + fentity + "Repository.GetAll();\n\t\t}\n\t}\n}";

            var th5 = new Thread(() =>
            {
                WriteOperation("Business code finished...");
            });
            th5.Start();
            Thread.Sleep(thread);

            var context = dpath + "\\Concrete\\" + tbxContext.Text.Trim() + "Context.cs";
            var cresult = "";
            if (File.Exists(context))
            {
                var file = File.ReadAllText(context);

                if(!file.Contains("<" + entity + ">"))
                {
                    var index = file.IndexOf("DbSets") + 7;

                    file = file.Insert(index, "\n\t\tpublic DbSet<" + entity + "> " + PluralizationService.CreateService(CultureInfo.CurrentCulture).Pluralize(entity) + " { get; set; }");
                }

                if(!file.Contains(entity + "Map"))
                {
                    var mindex = file.IndexOf("modelBuilder") + 22;

                    if (mindex == 21)
                    {
                        var t = file[file.IndexOf("#endregion") + 11];
                        file = file.Insert(file.IndexOf("#endregion") + 11, "\n\t\tprotected override void OnModelCreating(DbModelBuilder modelBuilder)\n\t\t{\n\n\t\t}\n");
                    }

                    mindex = file.IndexOf("modelBuilder") + 18;

                    cresult = file.Insert(mindex, "\t\t\tmodelBuilder.Configurations.Add(new " + entity + "Map());\n");
                }
            }
            else
            {
                cresult = "using System.Data.Entity;\nusing Entities.Concrete;\n\nnamespace " + rns + "\n{\n\tpublic class " + tbxContext.Text + "Context\n\t{\n\t\t#region DbSets\n\n\t\tpublic DbSet<" + entity + "> "
                            + PluralizationService.CreateService(CultureInfo.CurrentCulture).Pluralize(entity) + " { get; set; }\n\n\t\t#endregion\n\n\t\tprotected override void OnModelCreating(DbModelBuilder modelBuilder)\n"
                            + "\t\t{\n\t\t\tmodelBuilder.Configurations.Add(new " + entity + "Map());\n\t\t}\n\t}\n}";
            }

            var dmpath = dpath + "\\Mappings\\" + entity + "Map.cs";

            var dmresult = "using Entities.Concrete;\nusing System.Data.Entity.ModelConfiguration;\n\nnamespace " + rns + ".Mappings\n{\n\tpublic class " + entity + "Map : EntityTypeConfiguration<" + entity + ">\n\t{\n"
                         + "\t\tpublic " + entity + "Map()\n\t\t{\n\t\t\tToTable(\"" + PluralizationService.CreateService(CultureInfo.CurrentCulture).Pluralize(entity) + "\");\n\t\t\tHasKey(e => e.Id);\n"
                         + "\t\t\tProperty(e => e.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);\n\n" + CreateMapStr(GetEntityProperties(entity)) + "\t\t}\n\t}\n}";

            try
            {
                lblOperations.Invoke(new MethodInvoker(delegate ()
                {
                    if (lblEntities.Text.Contains(entity))
                        throw new Exception("Entity already generated.");
                    lblEntities.Text += entity + "\n";
                }));

                //using (StreamWriter writer = File.CreateText(irpath))
                //    writer.Write(irresult);
                //using (StreamWriter writer = File.CreateText(rpath))
                //    writer.Write(rresult);
                //using (StreamWriter writer = File.CreateText(context))
                //    writer.Write(cresult);
                //using (StreamWriter writer = File.CreateText(dmpath))
                //    writer.Write(dmresult);
                //using (StreamWriter writer = File.CreateText(spath))
                //    writer.Write(sresult);
                //using (StreamWriter writer = File.CreateText(mpath))
                //    writer.Write(mresult);

                var th6 = new Thread(() =>
                {
                    WriteOperation("Operations finished successfully...");
                });
                th6.Start();
                Thread.Sleep(thread);
            }
            catch (Exception ex)
            {
                MessageBox.Show("We ran into a few problem : \n" + ex.Message, "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Copy(string text)
        {
            Clipboard.SetText(text);
        }

        private string GetEntity(string entity)
        {
            var result = "";

            switch (entity.Split().Length)
            {
                case 1:
                    result = entity.Substring(0, 1).ToUpper() + entity.Substring(1, entity.Length - 1);
                    break;
                case 2:
                    result = entity.Split()[0].Substring(0, 1).ToUpper() + entity.Split()[0].Substring(1, entity.Split()[0].Length - 1) +
                        entity.Split()[1].Substring(0, 1).ToUpper() + entity.Split()[1].Substring(1, entity.Split()[1].Length - 1);
                    break;
                default:
                    break;
            }

            return result;
        }

        private void panelHeader_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure want to quit?", "System", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
                Application.Exit();
        }

        private void btnProjectPathFind_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                var result = fbd.ShowDialog();

                if (result == DialogResult.OK)
                {
                    ReloadAllPaths(fbd.SelectedPath);
                }
            }
        }

        private void tbx_Enter(object sender, EventArgs e)
        {
            var tbx = (TextBox)sender;
            if (tbx.Text == "__________")
                tbx.Text = "";
        }

        private void btnAdvancedMode_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Changes in advanced mode may cause problem your files. We recommend dont change them.\nAre you sure open advanced mode?",
                "System",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                tbxDataAccessPath.Enabled = true;
                tbxBusinessPath.Enabled = true;
                tbxDataAccessNamespace.Enabled = true;
                tbxBusinessNamespace.Enabled = true;
                groupBox1.Visible = true;
            }
        }

        private void tbx_Leave(object sender, EventArgs e)
        {
            var tbx = (TextBox)sender;
            if (tbx.Text == "")
                tbx.Text = "__________";
        }

        private void tbx_TextChanged(object sender, EventArgs e)
        {
            needSave = true;
            var tbx = (TextBox)sender;

            if (tbx.Text == entity | tbx.Text == projectPath | tbx.Text == dataAccessPath | tbx.Text == businessPath | tbx.Text == context
                | tbx.Text == dataAccessAbstract | tbx.Text == dataAccessConcrete | tbx.Text == businessAbstract | tbx.Text == businessConcrete)
                needSave = false;
        }

        private void OpenMessageWindowAndDoAction()
        {
            var result = MessageBox.Show("You changed some options. Do you want to save them to do not again the same configurations?", "System", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
                return;

            ConfigurationHelper.SetSetting("context", tbxContext.Text);
            ConfigurationHelper.SetSetting("entity", tbxEntity.Text);
            ConfigurationHelper.SetSetting("projectPath", tbxProjectPath.Text);
            ConfigurationHelper.SetSetting("dataAccessPath", tbxDataAccessPath.Text);
            ConfigurationHelper.SetSetting("dataAccessNamespace", tbxDataAccessNamespace.Text);
            ConfigurationHelper.SetSetting("businessPath", tbxBusinessPath.Text);
            ConfigurationHelper.SetSetting("businessNamespace", tbxBusinessNamespace.Text);
            ConfigurationHelper.SetSetting("dataAccessAbstract", tbxDataAccessAbstract.Text);
            ConfigurationHelper.SetSetting("dataAccessConcrete", tbxDataAccessConcrete.Text);
            ConfigurationHelper.SetSetting("businessAbstract", tbxBusinessAbstract.Text);
            ConfigurationHelper.SetSetting("businessConcrete", tbxBusinessConcrete.Text);
        }

        private bool CheckInputs()
        {
            var result = false;
            var msg = "Please, fill ";
            if (tbxEntity.Text.Trim() == "__________" | tbxEntity.Text.Trim() == "")
            {
                msg += "Entity";
                result = true;
            }
            if (tbxProjectPath.Text.Trim() == "__________" | tbxProjectPath.Text.Trim() == "")
            {
                msg += ", Project path";
                result = true;
            }
            if (tbxContext.Text.Trim() == "__________" | tbxContext.Text.Trim() == "")
            {
                msg += ", Context";
                result = true;
            }

            if (result)
                MessageBox.Show(msg, "System", MessageBoxButtons.OK, MessageBoxIcon.Information);

            return result;
        }

        private void LoadAppOptions()
        {
            if (entity != "none")
                tbxEntity.Text = entity;
            if (projectPath != "none")
                tbxProjectPath.Text = projectPath;
            if (dataAccessPath != "none")
                tbxDataAccessPath.Text = dataAccessPath;
            if (dataAccessNamespace != "none")
                tbxDataAccessNamespace.Text = dataAccessNamespace;
            if (businessPath != "none")
                tbxBusinessPath.Text = businessPath;
            if (businessNamespace != "none")
                tbxBusinessNamespace.Text = businessNamespace;
            if (context != "none")
                tbxContext.Text = context;
            if (dataAccessAbstract != "none")
                tbxDataAccessAbstract.Text = dataAccessAbstract;
            if (dataAccessConcrete != "none")
                tbxDataAccessConcrete.Text = dataAccessConcrete;
            if (businessAbstract != "none")
                tbxBusinessAbstract.Text = businessAbstract;
            if (businessConcrete != "none")
                tbxBusinessConcrete.Text = businessConcrete;
        }

        private void WriteOperation(string txt)
        {
            lblOperations.Invoke(new MethodInvoker(delegate ()
            {
                lblOperations.Text += "\n" + txt;
            }));
        }

        private string CreateUsingStr(string str)
        {
            var result = new List<string>();
            var arr = str.Split(',');

            foreach (var item in arr)
            {
                result.Add("using " + item + ";");
            }

            return string.Join("\n", result);
        }

        private void ReloadAllPaths(string newPath)
        {
            tbxProjectPath.Text = newPath;
            tbxDataAccessPath.Text = newPath + "\\DataAccess";
            tbxBusinessPath.Text = newPath + "\\Business";
            tbxDataAccessNamespace.Text = "DataAccess.Abstract,DataAccess.Concrete";
            tbxBusinessNamespace.Text = "Business.Abstract,Busines.Concrete";
            tbxDataAccessAbstract.Text = "Core.DataAccess.Abstract,Entities.Concrete";
            tbxDataAccessConcrete.Text = "Core.DataAccess.Concrete," + tbxDataAccessNamespace.Text.Split(',')[0] + ",Entities.Concrete";
            tbxBusinessAbstract.Text = "Entities.Concrete,System,System.Collections.Generic";
            tbxBusinessConcrete.Text = tbxBusinessNamespace.Text.Split(',')[0] + "," + tbxDataAccessNamespace.Text.Split()[0]
                                                                                        + ",Entities.Concrete,System,System.Collections.Generic";
        }

        private List<string> GetEntityProperties(string entity)
        {
            var result = new List<string>();

            var fileName = tbxProjectPath.Text + "\\Entities\\" + entity + ".cs";
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
    }
}
