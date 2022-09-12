﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        string entity, projectPath, dataAccessPath, businessPath, context, dataAccessAbstract, dataAccessConcrete, businessAbstract, businessConcrete;
        bool needSave;

        #endregion

        public Generator()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 50, 50));

            entity = ConfigurationHelper.GetAppSetting("entity");
            projectPath = ConfigurationHelper.GetAppSetting("projectPath");
            dataAccessPath = ConfigurationHelper.GetAppSetting("dataAccessPath");
            businessPath = ConfigurationHelper.GetAppSetting("businessPath");
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

        private void Run()
        {
            var entity = GetEntity(tbxEntity.Text);
            var lentity = entity.Substring(0, 1).ToLower() + entity.Substring(1, entity.Length - 1);
            var fentity = "_" + lentity;
            var irepo = "I" + entity + "Repository";
            var repo = entity + "Repository";
            var service = "I" + entity + "Service";
            var manager = entity + "Manager";

            var th1 = new Thread(() =>
            {
                WriteOperation("Helper strings created...");
            });
            th1.Start();

            var irusings = CreateUsingStr(tbxDataAccessAbstract.Text.Trim());
            var rusings = CreateUsingStr(tbxDataAccessConcrete.Text.Trim());
            var susings = CreateUsingStr(tbxBusinessAbstract.Text.Trim());
            var musings = CreateUsingStr(tbxBusinessConcrete.Text.Trim());

            var th2 = new Thread(() =>
            {
                WriteOperation("Usings prepared...");
            });
            th2.Start();

            var irns = tbxDataAccessNamespace.Text.Split(',')[0];
            var rns = tbxDataAccessNamespace.Text.Split(',')[1];
            var sns = tbxBusinessNamespace.Text.Split(',')[0];
            var mns = tbxBusinessNamespace.Text.Split(',')[1];

            var th3 = new Thread(() =>
            {
                WriteOperation("Namespaces figured out...");
            });
            th3.Start();

            var dpath = tbxDataAccessPath.Text;

            var irresult = irusings + "\n\nnamespace " + irns + "\n{\n\tpublic interface " + irepo + " : IEntityRepository<" + entity + ">\n\t{\n\t}\n}\n";

            var rresult = rusings + "\n\nnamespace " + rns + "\n{\n\tpublic class " + repo + " : EfEntityRepositoryBase<" + entity + "," + tbxContext.Text 
                        + " Context>, I" + irepo + "\n\t{\n\t}\n}";

            var irpath = dpath + "\\Abstract\\" + irepo + ".cs";
            var rpath = dpath + "\\Concrete\\" + repo + ".cs";

            var th4 = new Thread(() =>
            {
                WriteOperation("Data acces code finished...");
            });
            th4.Start();

            var bpath = tbxBusinessPath.Text;

            var spath = bpath + "\\Abstract\\" + service + ".cs";
            var mpath = bpath + "\\Concrete\\" + manager + ".cs";

            var sresult = susings + "\n\nnamespace " + sns + "\n{\n\tpublic interface " 
                         + service + "\n\t{\n\t\tvoid Add(" + entity + " " + lentity + ");\n"
                         + "\t\tvoid Update(" + entity + " " + lentity + ");\n"
                         + "\t\tvoid Delete(" + entity + " " + lentity + ");\n"
                         + "\t\tvoid DeleteAll();\n"
                         + "\t\t" + entity + " Get(int id);\n"
                         + "\t\tList<" + entity + "> GetAll();\n\t}\n}";

            var mresult = musings +  "\n\nnamespace " + mns + "\n{\n\tpublic class " + manager + " : " + service + "\n\t{\n"
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

            try
            {
                using (StreamWriter writer = File.CreateText(irpath))
                    writer.Write(irresult);
                using (StreamWriter writer2 = File.CreateText(rpath))
                    writer2.Write(rresult);
                using (StreamWriter writer2 = File.CreateText(spath))
                    writer2.Write(sresult);
                using (StreamWriter writer2 = File.CreateText(mpath))
                    writer2.Write(mresult);

                var th6 = new Thread(() =>
                {
                    WriteOperation("Operations finished successfully...");
                });
                th6.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("We ran into a few problem : \n" + ex.Message, "System");
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
                    result = entity.Substring(0,1).ToUpper() + entity.Substring(1, entity.Length - 1);
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

            if(result == DialogResult.OK)
                Application.Exit();
        }

        private void btnProjectPathFind_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                var result = fbd.ShowDialog();

                if(result == DialogResult.OK)
                {
                    ReloadAllPaths(fbd.SelectedPath);
                }
            }
        }

        private void tbx_Enter(object sender, EventArgs e)
        {
            var tbx = (TextBox)sender;
            if(tbx.Text == "__________")
                tbx.Text = "";
        }

        private void btnAdvancedMode_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Changes in advanced mode may cause problem your files. We recommend dont change them.\nAre you sure open advanced mode?",
                "System",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if( result == DialogResult.Yes)
            {
                tbxDataAccessPath.Enabled = true;
                tbxBusinessPath.Enabled = true;
                tbxDataAccessNamespace.Enabled = true;
                tbxBusinessNamespace.Enabled = true;
                groupBox1.Enabled = true;
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
            
            if(tbx.Text == entity | tbx.Text == projectPath | tbx.Text == dataAccessPath | tbx.Text == businessPath | tbx.Text == context 
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
            ConfigurationHelper.SetSetting("businessPath", tbxBusinessPath.Text);
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

            if(result)
                MessageBox.Show(msg, "System", MessageBoxButtons.OK, MessageBoxIcon.Information);

            return result;
        }
        
        private void LoadAppOptions()
        {
            if(entity != "none")
                tbxEntity.Text = entity;
            if (projectPath != "none")
                tbxProjectPath.Text = projectPath;
            if(dataAccessPath != "none")
                tbxDataAccessPath.Text = dataAccessPath;
            if(businessPath != "none")
                tbxBusinessPath.Text = businessPath;
            if(context != "none") 
                tbxContext.Text = context;
            if(dataAccessAbstract != "none")
                tbxDataAccessAbstract.Text = dataAccessAbstract;
            if(dataAccessConcrete != "none")
                tbxDataAccessConcrete.Text = dataAccessConcrete;
            if(businessAbstract != "none")
                tbxBusinessAbstract.Text = businessAbstract;
            if(businessConcrete != "none") 
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
            tbxDataAccessConcrete.Text = "Core.DataAccess.Concrete," + tbxDataAccessNamespace.Text.Split(',')[0];
            tbxBusinessAbstract.Text = "Entities.Concrete,System,System.Collections.Generic";
            tbxBusinessConcrete.Text = tbxBusinessNamespace.Text.Split(',')[0] + "," + tbxDataAccessNamespace.Text.Split()[0] 
                                                                                        + ",Entities.Concrete,System,System.Collections.Generic";
        }
    }
}