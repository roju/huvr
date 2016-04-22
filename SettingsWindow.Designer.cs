namespace huvr
{
    partial class SettingsWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsWindow));
            this.lblDebug0 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblDebug1 = new System.Windows.Forms.Label();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.btnExit = new System.Windows.Forms.Button();
            this.lblDebug2 = new System.Windows.Forms.Label();
            this.lblDebug3 = new System.Windows.Forms.Label();
            this.lblDebug4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rdoNormal = new System.Windows.Forms.RadioButton();
            this.rdoOneFinger = new System.Windows.Forms.RadioButton();
            this.rdoToolMode = new System.Windows.Forms.RadioButton();
            this.rdoMouseMode = new System.Windows.Forms.RadioButton();
            this.rdoTwoFingers = new System.Windows.Forms.RadioButton();
            this.lblMouseCursorSpeed = new System.Windows.Forms.Label();
            this.lblTouchCursorSpeed = new System.Windows.Forms.Label();
            this.tbrMouseCursorSpeed = new System.Windows.Forms.TrackBar();
            this.tbrTouchCursorSpeed = new System.Windows.Forms.TrackBar();
            this.lblTouchThreshold = new System.Windows.Forms.Label();
            this.numTouchThreshold = new System.Windows.Forms.NumericUpDown();
            this.lblPhysicalCenter = new System.Windows.Forms.Label();
            this.numPhysicalCenterX = new System.Windows.Forms.NumericUpDown();
            this.lblX = new System.Windows.Forms.Label();
            this.lblY = new System.Windows.Forms.Label();
            this.numPhysicalCenterY = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.tbrMouseCursorSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbrTouchCursorSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTouchThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPhysicalCenterX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPhysicalCenterY)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDebug0
            // 
            this.lblDebug0.AutoSize = true;
            this.lblDebug0.Location = new System.Drawing.Point(13, 13);
            this.lblDebug0.Name = "lblDebug0";
            this.lblDebug0.Size = new System.Drawing.Size(31, 13);
            this.lblDebug0.TabIndex = 0;
            this.lblDebug0.Text = "none";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblDebug1
            // 
            this.lblDebug1.AutoSize = true;
            this.lblDebug1.Location = new System.Drawing.Point(12, 58);
            this.lblDebug1.Name = "lblDebug1";
            this.lblDebug1.Size = new System.Drawing.Size(31, 13);
            this.lblDebug1.TabIndex = 1;
            this.lblDebug1.Text = "none";
            // 
            // trayIcon
            // 
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "huvr";
            this.trayIcon.Visible = true;
            this.trayIcon.DoubleClick += new System.EventHandler(this.trayIcon_DoubleClick);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(417, 248);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblDebug2
            // 
            this.lblDebug2.AutoSize = true;
            this.lblDebug2.Location = new System.Drawing.Point(12, 104);
            this.lblDebug2.Name = "lblDebug2";
            this.lblDebug2.Size = new System.Drawing.Size(31, 13);
            this.lblDebug2.TabIndex = 3;
            this.lblDebug2.Text = "none";
            // 
            // lblDebug3
            // 
            this.lblDebug3.AutoSize = true;
            this.lblDebug3.Location = new System.Drawing.Point(13, 156);
            this.lblDebug3.Name = "lblDebug3";
            this.lblDebug3.Size = new System.Drawing.Size(31, 13);
            this.lblDebug3.TabIndex = 4;
            this.lblDebug3.Text = "none";
            // 
            // lblDebug4
            // 
            this.lblDebug4.AutoSize = true;
            this.lblDebug4.Location = new System.Drawing.Point(12, 257);
            this.lblDebug4.Name = "lblDebug4";
            this.lblDebug4.Size = new System.Drawing.Size(31, 13);
            this.lblDebug4.TabIndex = 5;
            this.lblDebug4.Text = "none";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(140, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Run Mode";
            // 
            // rdoNormal
            // 
            this.rdoNormal.AutoSize = true;
            this.rdoNormal.Location = new System.Drawing.Point(143, 39);
            this.rdoNormal.Name = "rdoNormal";
            this.rdoNormal.Size = new System.Drawing.Size(58, 17);
            this.rdoNormal.TabIndex = 8;
            this.rdoNormal.Text = "Normal";
            this.rdoNormal.UseVisualStyleBackColor = true;
            this.rdoNormal.CheckedChanged += new System.EventHandler(this.rdoNormal_CheckedChanged);
            // 
            // rdoOneFinger
            // 
            this.rdoOneFinger.AutoSize = true;
            this.rdoOneFinger.Location = new System.Drawing.Point(143, 63);
            this.rdoOneFinger.Name = "rdoOneFinger";
            this.rdoOneFinger.Size = new System.Drawing.Size(77, 17);
            this.rdoOneFinger.TabIndex = 9;
            this.rdoOneFinger.Text = "One Finger";
            this.rdoOneFinger.UseVisualStyleBackColor = true;
            this.rdoOneFinger.CheckedChanged += new System.EventHandler(this.rdoOneFinger_CheckedChanged);
            // 
            // rdoToolMode
            // 
            this.rdoToolMode.AutoSize = true;
            this.rdoToolMode.Location = new System.Drawing.Point(142, 109);
            this.rdoToolMode.Name = "rdoToolMode";
            this.rdoToolMode.Size = new System.Drawing.Size(76, 17);
            this.rdoToolMode.TabIndex = 10;
            this.rdoToolMode.Text = "Tool Mode";
            this.rdoToolMode.UseVisualStyleBackColor = true;
            this.rdoToolMode.CheckedChanged += new System.EventHandler(this.rdoToolMode_CheckedChanged);
            // 
            // rdoMouseMode
            // 
            this.rdoMouseMode.AutoSize = true;
            this.rdoMouseMode.Location = new System.Drawing.Point(142, 133);
            this.rdoMouseMode.Name = "rdoMouseMode";
            this.rdoMouseMode.Size = new System.Drawing.Size(87, 17);
            this.rdoMouseMode.TabIndex = 11;
            this.rdoMouseMode.Text = "Mouse Mode";
            this.rdoMouseMode.UseVisualStyleBackColor = true;
            this.rdoMouseMode.CheckedChanged += new System.EventHandler(this.rdoMouseMode_CheckedChanged);
            // 
            // rdoTwoFingers
            // 
            this.rdoTwoFingers.AutoSize = true;
            this.rdoTwoFingers.Location = new System.Drawing.Point(143, 86);
            this.rdoTwoFingers.Name = "rdoTwoFingers";
            this.rdoTwoFingers.Size = new System.Drawing.Size(83, 17);
            this.rdoTwoFingers.TabIndex = 12;
            this.rdoTwoFingers.Text = "Two Fingers";
            this.rdoTwoFingers.UseVisualStyleBackColor = true;
            this.rdoTwoFingers.CheckedChanged += new System.EventHandler(this.rdoTwoFingers_CheckedChanged);
            // 
            // lblMouseCursorSpeed
            // 
            this.lblMouseCursorSpeed.AutoSize = true;
            this.lblMouseCursorSpeed.Location = new System.Drawing.Point(289, 117);
            this.lblMouseCursorSpeed.Name = "lblMouseCursorSpeed";
            this.lblMouseCursorSpeed.Size = new System.Drawing.Size(106, 13);
            this.lblMouseCursorSpeed.TabIndex = 14;
            this.lblMouseCursorSpeed.Text = "Mouse Cursor Speed";
            // 
            // lblTouchCursorSpeed
            // 
            this.lblTouchCursorSpeed.AutoSize = true;
            this.lblTouchCursorSpeed.Location = new System.Drawing.Point(289, 181);
            this.lblTouchCursorSpeed.Name = "lblTouchCursorSpeed";
            this.lblTouchCursorSpeed.Size = new System.Drawing.Size(105, 13);
            this.lblTouchCursorSpeed.TabIndex = 15;
            this.lblTouchCursorSpeed.Text = "Touch Cursor Speed";
            // 
            // tbrMouseCursorSpeed
            // 
            this.tbrMouseCursorSpeed.Location = new System.Drawing.Point(292, 133);
            this.tbrMouseCursorSpeed.Maximum = 50;
            this.tbrMouseCursorSpeed.Name = "tbrMouseCursorSpeed";
            this.tbrMouseCursorSpeed.Size = new System.Drawing.Size(200, 45);
            this.tbrMouseCursorSpeed.TabIndex = 16;
            this.tbrMouseCursorSpeed.Value = 1;
            this.tbrMouseCursorSpeed.Scroll += new System.EventHandler(this.tbrMouseCursorSpeed_Scroll);
            // 
            // tbrTouchCursorSpeed
            // 
            this.tbrTouchCursorSpeed.Location = new System.Drawing.Point(292, 197);
            this.tbrTouchCursorSpeed.Maximum = 40;
            this.tbrTouchCursorSpeed.Name = "tbrTouchCursorSpeed";
            this.tbrTouchCursorSpeed.Size = new System.Drawing.Size(200, 45);
            this.tbrTouchCursorSpeed.TabIndex = 17;
            this.tbrTouchCursorSpeed.Value = 1;
            this.tbrTouchCursorSpeed.Scroll += new System.EventHandler(this.tbrTouchCursorSpeed_Scroll);
            // 
            // lblTouchThreshold
            // 
            this.lblTouchThreshold.AutoSize = true;
            this.lblTouchThreshold.Location = new System.Drawing.Point(139, 181);
            this.lblTouchThreshold.Name = "lblTouchThreshold";
            this.lblTouchThreshold.Size = new System.Drawing.Size(88, 13);
            this.lblTouchThreshold.TabIndex = 18;
            this.lblTouchThreshold.Text = "Touch Threshold";
            // 
            // numTouchThreshold
            // 
            this.numTouchThreshold.DecimalPlaces = 1;
            this.numTouchThreshold.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numTouchThreshold.Location = new System.Drawing.Point(142, 197);
            this.numTouchThreshold.Name = "numTouchThreshold";
            this.numTouchThreshold.Size = new System.Drawing.Size(85, 20);
            this.numTouchThreshold.TabIndex = 19;
            this.numTouchThreshold.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // lblPhysicalCenter
            // 
            this.lblPhysicalCenter.AutoSize = true;
            this.lblPhysicalCenter.Location = new System.Drawing.Point(289, 9);
            this.lblPhysicalCenter.Name = "lblPhysicalCenter";
            this.lblPhysicalCenter.Size = new System.Drawing.Size(80, 13);
            this.lblPhysicalCenter.TabIndex = 20;
            this.lblPhysicalCenter.Text = "Physical Center";
            // 
            // numPhysicalCenterX
            // 
            this.numPhysicalCenterX.DecimalPlaces = 1;
            this.numPhysicalCenterX.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numPhysicalCenterX.Location = new System.Drawing.Point(312, 37);
            this.numPhysicalCenterX.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numPhysicalCenterX.Name = "numPhysicalCenterX";
            this.numPhysicalCenterX.Size = new System.Drawing.Size(51, 20);
            this.numPhysicalCenterX.TabIndex = 21;
            this.numPhysicalCenterX.ValueChanged += new System.EventHandler(this.numPhysicalCenterX_ValueChanged);
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Location = new System.Drawing.Point(292, 41);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(17, 13);
            this.lblX.TabIndex = 22;
            this.lblX.Text = "X:";
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Location = new System.Drawing.Point(292, 65);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(17, 13);
            this.lblY.TabIndex = 24;
            this.lblY.Text = "Y:";
            // 
            // numPhysicalCenterY
            // 
            this.numPhysicalCenterY.DecimalPlaces = 1;
            this.numPhysicalCenterY.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numPhysicalCenterY.Location = new System.Drawing.Point(312, 63);
            this.numPhysicalCenterY.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numPhysicalCenterY.Name = "numPhysicalCenterY";
            this.numPhysicalCenterY.Size = new System.Drawing.Size(51, 20);
            this.numPhysicalCenterY.TabIndex = 23;
            this.numPhysicalCenterY.ValueChanged += new System.EventHandler(this.numPhysicalCenterY_ValueChanged);
            // 
            // SettingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 279);
            this.Controls.Add(this.lblY);
            this.Controls.Add(this.numPhysicalCenterY);
            this.Controls.Add(this.lblX);
            this.Controls.Add(this.numPhysicalCenterX);
            this.Controls.Add(this.lblPhysicalCenter);
            this.Controls.Add(this.numTouchThreshold);
            this.Controls.Add(this.lblTouchThreshold);
            this.Controls.Add(this.tbrTouchCursorSpeed);
            this.Controls.Add(this.tbrMouseCursorSpeed);
            this.Controls.Add(this.lblTouchCursorSpeed);
            this.Controls.Add(this.lblMouseCursorSpeed);
            this.Controls.Add(this.rdoTwoFingers);
            this.Controls.Add(this.rdoMouseMode);
            this.Controls.Add(this.rdoToolMode);
            this.Controls.Add(this.rdoOneFinger);
            this.Controls.Add(this.rdoNormal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblDebug4);
            this.Controls.Add(this.lblDebug3);
            this.Controls.Add(this.lblDebug2);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblDebug1);
            this.Controls.Add(this.lblDebug0);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SettingsWindow";
            this.Text = "huvr Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbrMouseCursorSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbrTouchCursorSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTouchThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPhysicalCenterX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPhysicalCenterY)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDebug0;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblDebug1;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblDebug2;
        private System.Windows.Forms.Label lblDebug3;
        private System.Windows.Forms.Label lblDebug4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdoNormal;
        private System.Windows.Forms.RadioButton rdoOneFinger;
        private System.Windows.Forms.RadioButton rdoToolMode;
        private System.Windows.Forms.RadioButton rdoMouseMode;
        private System.Windows.Forms.RadioButton rdoTwoFingers;
        private System.Windows.Forms.Label lblMouseCursorSpeed;
        private System.Windows.Forms.Label lblTouchCursorSpeed;
        private System.Windows.Forms.TrackBar tbrMouseCursorSpeed;
        private System.Windows.Forms.TrackBar tbrTouchCursorSpeed;
        private System.Windows.Forms.Label lblTouchThreshold;
        private System.Windows.Forms.NumericUpDown numTouchThreshold;
        private System.Windows.Forms.Label lblPhysicalCenter;
        private System.Windows.Forms.NumericUpDown numPhysicalCenterX;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.NumericUpDown numPhysicalCenterY;
    }
}

