using Generator.Classes;
using System;
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

        public AppSettings AppSettings { get; set; }
        bool needSave;

        #endregion

        public Generator()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 50, 50));
            AppSettings = new AppSettings();
            ConfigurationHelper.BuildAppSettings(AppSettings);
            needSave = false;

            LoadAppOptions();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            lblOperations.Text = "";

            if (CheckInputs())
                return;

            if (needSave)
                OpenMessageWindowAndDoAction();

            var thMain = new Thread(Run);
            thMain.Start();
        }

        private void Run() // Refactored
        {
            var thread = 200;

            var hstr = new HelperStrings(tbxEntity.Text, tbxDataAccessAbstract.Text.Trim(), tbxDataAccessConcrete.Text.Trim(), tbxBusinessAbstract.Text.Trim(),
                                            tbxBusinessConcrete.Text.Trim(), tbxDataAccessNamespace.Text, tbxBusinessNamespace.Text);

            if (lblEntities.Text.Contains(hstr.Entity))
            {
                MessageBox.Show("Entity already generated.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var th1 = new Thread(() =>
            {
                WriteOperation(hstr.Entity + " :\nHelper strings created...");
                Thread.Sleep(thread);
                WriteOperation("Usings prepared...");
                Thread.Sleep(thread);
                WriteOperation("Namespaces figured out...");
                Thread.Sleep(thread);
                WriteOperation("Data acces code finished...");
                Thread.Sleep(thread);
                WriteOperation("Business code finished...");
            });
            th1.Start();
            Thread.Sleep(5 * thread);

            var result = new CodeWriter(tbxProjectPath.Text + "\\DataAccess\\", tbxProjectPath.Text + "\\Business\\",
                            new CodeBuilder(tbxProjectPath.Text, tbxProjectPath.Text + "\\DataAccess\\", tbxContext.Text, hstr)).Generate();

            if (result)
            {
                var th2 = new Thread(() =>
                {
                    WriteOperation("Operations finished successfully...");
                });
                th2.Start();
                Thread.Sleep(thread);

                lblOperations.Invoke(new MethodInvoker(delegate ()
                {
                   
                    lblEntities.Text += hstr.Entity + "\n";
                }));
            }

        }

        #region Events

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

            if (tbx.Text == AppSettings.Entity | tbx.Text == AppSettings.ProjectPath | tbx.Text == AppSettings.DataAccessPath | tbx.Text == AppSettings.BusinessPath
                | tbx.Text == AppSettings.Context | tbx.Text == AppSettings.DataAccessAbstract | tbx.Text == AppSettings.DataAccessConcrete
                | tbx.Text == AppSettings.BusinessAbstract | tbx.Text == AppSettings.BusinessConcrete)
                needSave = false;
        }

        private void btnReloadPaths_Click(object sender, EventArgs e)
        {
            ReloadAllPaths(tbxProjectPath.Text);
        }

        #endregion

        private void OpenMessageWindowAndDoAction()
        {
            var result = MessageBox.Show("You changed some options. Do you want to save them to do not again the same configurations?", "System", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
                return;

            ConfigurationHelper.ReBuildAppSettings(new AppSettings
            {
                Context = tbxContext.Text,
                Entity = tbxEntity.Text,
                ProjectPath = tbxProjectPath.Text,
                DataAccessPath = tbxDataAccessPath.Text,
                BusinessPath = tbxBusinessPath.Text,
                BusinessAbstract = tbxBusinessAbstract.Text,
                DataAccessAbstract = tbxDataAccessAbstract.Text,
                DataAccessConcrete = tbxDataAccessConcrete.Text,
                DataAccessNamespace = tbxDataAccessNamespace.Text,
                BusinessConcrete = tbxBusinessConcrete.Text,
                BusinessNamespace = tbxBusinessNamespace.Text
            });
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
            if (AppSettings.Entity != "none")
                tbxEntity.Text = AppSettings.Entity;
            if (AppSettings.ProjectPath != "none")
                tbxProjectPath.Text = AppSettings.ProjectPath;
            if (AppSettings.DataAccessPath != "none")
                tbxDataAccessPath.Text = AppSettings.DataAccessPath;
            if (AppSettings.DataAccessNamespace != "none")
                tbxDataAccessNamespace.Text = AppSettings.DataAccessNamespace;
            if (AppSettings.BusinessPath != "none")
                tbxBusinessPath.Text = AppSettings.BusinessPath;
            if (AppSettings.BusinessNamespace != "none")
                tbxBusinessNamespace.Text = AppSettings.BusinessNamespace;
            if (AppSettings.Context != "none")
                tbxContext.Text = AppSettings.Context;
            if (AppSettings.DataAccessAbstract != "none")
                tbxDataAccessAbstract.Text = AppSettings.DataAccessAbstract;
            if (AppSettings.DataAccessConcrete != "none")
                tbxDataAccessConcrete.Text = AppSettings.DataAccessConcrete;
            if (AppSettings.BusinessAbstract != "none")
                tbxBusinessAbstract.Text = AppSettings.BusinessAbstract;
            if (AppSettings.BusinessConcrete != "none")
                tbxBusinessConcrete.Text = AppSettings.BusinessConcrete;
        }

        private void WriteOperation(string txt)
        {
            lblOperations.Invoke(new MethodInvoker(delegate ()
            {
                lblOperations.Text += "\n" + txt;
            }));
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

    }
}
