using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace huvr
{
    public partial class SettingsWindow : Form
    {
        public static int runMode = 1;
        public bool allowFormClose = false;
        public static string[] debugText = new string[] { "", "", "", "", "" };

        public SettingsWindow()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDebug0.Text = debugText[0];
            lblDebug1.Text = debugText[1];
            lblDebug2.Text = debugText[2];
            lblDebug3.Text = debugText[3];
            lblDebug4.Text = debugText[4];
        }

        private void hideWindow()
        {
            this.Hide();
            this.ShowInTaskbar = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            allowFormClose = true;
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!allowFormClose)
            {
                e.Cancel = true;
                hideWindow();
                trayIcon.Visible = true;
            }
        }

        private void ShowWindow()
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            runMode = (int)Properties.Settings.Default["runMode"];

            switch (SettingsWindow.runMode)
            {
                case 0:
                    rdoNormal.Checked = true;
                    break;
                case 1:
                    rdoOneFinger.Checked = true;
                    break;
                case 2:
                    rdoTwoFingers.Checked = true;
                    break;
                case 3:
                    rdoToolMode.Checked = true;
                    break;
                case 4:
                    rdoMouseMode.Checked = true;
                    break;
            }

            numTouchThreshold.Value = (decimal)Properties.Settings.Default.TouchThreshold;

            tbrMouseCursorSpeed.Value = (int)(Properties.Settings.Default.MouseCursorSpeed * 100);
            lblMouseCursorSpeed.Text = "Mouse Cursor Speed: " + tbrMouseCursorSpeed.Value / 100f;

            tbrTouchCursorSpeed.Value = Properties.Settings.Default.TouchCursorSpeed;
            lblTouchCursorSpeed.Text = "Touch Cursor Speed: " + Properties.Settings.Default.TouchCursorSpeed;

            numPhysicalCenterX.Value = (decimal)Properties.Settings.Default.PhysicalCenterX;
            numPhysicalCenterY.Value = (decimal)Properties.Settings.Default.PhysicalCenterY;

            this.Close();
        }

        private void trayIcon_DoubleClick(object sender, EventArgs e)
        {
            ShowWindow();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {

        }

        private void rdoNormal_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoNormal.Checked == true)
            {
                runMode = 0;
                Properties.Settings.Default["runMode"] = runMode;
            }
        }

        private void rdoOneFinger_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoOneFinger.Checked == true)
            {
                runMode = 1;
                Properties.Settings.Default["runMode"] = runMode;
            }
        }

        private void rdoTwoFingers_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoTwoFingers.Checked == true)
            {
                runMode = 2;
                Properties.Settings.Default["runMode"] = runMode;
            }
        }

        private void rdoToolMode_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoToolMode.Checked == true)
            {
                runMode = 3;
                Properties.Settings.Default["runMode"] = runMode;
            }
        }

        private void rdoMouseMode_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoMouseMode.Checked == true)
            {
                runMode = 4;
                Properties.Settings.Default["runMode"] = runMode;
            }
        }

        private void tbrMouseCursorSpeed_Scroll(object sender, EventArgs e)
        {
            float value = tbrMouseCursorSpeed.Value / 100f;
            Properties.Settings.Default.MouseCursorSpeed = value;
            lblMouseCursorSpeed.Text = "Mouse Cursor Speed: " + value;

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.TouchThreshold = (float)numTouchThreshold.Value;
        }

        private void tbrTouchCursorSpeed_Scroll(object sender, EventArgs e)
        {
            int value = tbrTouchCursorSpeed.Value;
            Properties.Settings.Default.TouchCursorSpeed = value;
            lblTouchCursorSpeed.Text = "Touch Cursor Speed: " + value;
        }

        private void numPhysicalCenterX_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.PhysicalCenterX = (float)numPhysicalCenterX.Value;
        }

        private void numPhysicalCenterY_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.PhysicalCenterY = (float)numPhysicalCenterY.Value;
        }
    }
}
