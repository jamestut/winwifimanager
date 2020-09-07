namespace BssidSwitcher
{
    partial class FormEditFilter
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
            if(disposing && (components != null))
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.optBandAny = new System.Windows.Forms.RadioButton();
            this.optBandB = new System.Windows.Forms.RadioButton();
            this.optBandA = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.optSsidAny = new System.Windows.Forms.RadioButton();
            this.optSsidCurrentConnected = new System.Windows.Forms.RadioButton();
            this.optSsidContains = new System.Windows.Forms.RadioButton();
            this.ssidNameFilter = new System.Windows.Forms.TextBox();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.optProfileOnly = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(101, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Band Range";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.optBandAny);
            this.flowLayoutPanel1.Controls.Add(this.optBandB);
            this.flowLayoutPanel1.Controls.Add(this.optBandA);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(95, 81);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // optBandAny
            // 
            this.optBandAny.AutoSize = true;
            this.optBandAny.Location = new System.Drawing.Point(3, 3);
            this.optBandAny.Name = "optBandAny";
            this.optBandAny.Size = new System.Drawing.Size(43, 17);
            this.optBandAny.TabIndex = 0;
            this.optBandAny.TabStop = true;
            this.optBandAny.Text = "Any";
            this.optBandAny.UseVisualStyleBackColor = true;
            this.optBandAny.CheckedChanged += new System.EventHandler(this.optBandAny_CheckedChanged);
            // 
            // optBandB
            // 
            this.optBandB.AutoSize = true;
            this.optBandB.Location = new System.Drawing.Point(3, 26);
            this.optBandB.Name = "optBandB";
            this.optBandB.Size = new System.Drawing.Size(64, 17);
            this.optBandB.TabIndex = 1;
            this.optBandB.TabStop = true;
            this.optBandB.Text = "2.4 GHz";
            this.optBandB.UseVisualStyleBackColor = true;
            this.optBandB.CheckedChanged += new System.EventHandler(this.optBandB_CheckedChanged);
            // 
            // optBandA
            // 
            this.optBandA.AutoSize = true;
            this.optBandA.Location = new System.Drawing.Point(3, 49);
            this.optBandA.Name = "optBandA";
            this.optBandA.Size = new System.Drawing.Size(55, 17);
            this.optBandA.TabIndex = 2;
            this.optBandA.TabStop = true;
            this.optBandA.Text = "5 GHz";
            this.optBandA.UseVisualStyleBackColor = true;
            this.optBandA.CheckedChanged += new System.EventHandler(this.optBandA_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.flowLayoutPanel2);
            this.groupBox2.Location = new System.Drawing.Point(119, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 125);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "SSID";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.optSsidAny);
            this.flowLayoutPanel2.Controls.Add(this.optSsidCurrentConnected);
            this.flowLayoutPanel2.Controls.Add(this.optSsidContains);
            this.flowLayoutPanel2.Controls.Add(this.ssidNameFilter);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(194, 106);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // optSsidAny
            // 
            this.optSsidAny.AutoSize = true;
            this.optSsidAny.Location = new System.Drawing.Point(3, 3);
            this.optSsidAny.Name = "optSsidAny";
            this.optSsidAny.Size = new System.Drawing.Size(43, 17);
            this.optSsidAny.TabIndex = 0;
            this.optSsidAny.TabStop = true;
            this.optSsidAny.Text = "Any";
            this.optSsidAny.UseVisualStyleBackColor = true;
            this.optSsidAny.CheckedChanged += new System.EventHandler(this.optSsidAny_CheckedChanged);
            // 
            // optSsidCurrentConnected
            // 
            this.optSsidCurrentConnected.AutoSize = true;
            this.optSsidCurrentConnected.Location = new System.Drawing.Point(3, 26);
            this.optSsidCurrentConnected.Name = "optSsidCurrentConnected";
            this.optSsidCurrentConnected.Size = new System.Drawing.Size(121, 17);
            this.optSsidCurrentConnected.TabIndex = 1;
            this.optSsidCurrentConnected.TabStop = true;
            this.optSsidCurrentConnected.Text = "Currently Connected";
            this.optSsidCurrentConnected.UseVisualStyleBackColor = true;
            this.optSsidCurrentConnected.CheckedChanged += new System.EventHandler(this.optSsidCurrentConnected_CheckedChanged);
            // 
            // optSsidContains
            // 
            this.optSsidContains.AutoSize = true;
            this.optSsidContains.Location = new System.Drawing.Point(3, 49);
            this.optSsidContains.Name = "optSsidContains";
            this.optSsidContains.Size = new System.Drawing.Size(69, 17);
            this.optSsidContains.TabIndex = 2;
            this.optSsidContains.TabStop = true;
            this.optSsidContains.Text = "Contains:";
            this.optSsidContains.UseVisualStyleBackColor = true;
            this.optSsidContains.CheckedChanged += new System.EventHandler(this.optSsidContains_CheckedChanged);
            // 
            // ssidNameFilter
            // 
            this.ssidNameFilter.Location = new System.Drawing.Point(3, 72);
            this.ssidNameFilter.Name = "ssidNameFilter";
            this.ssidNameFilter.Size = new System.Drawing.Size(188, 20);
            this.ssidNameFilter.TabIndex = 3;
            // 
            // buttonClose
            // 
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Location = new System.Drawing.Point(325, 12);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 2;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(325, 41);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 23);
            this.buttonReset.TabIndex = 3;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // optProfileOnly
            // 
            this.optProfileOnly.AutoSize = true;
            this.optProfileOnly.Location = new System.Drawing.Point(125, 140);
            this.optProfileOnly.Name = "optProfileOnly";
            this.optProfileOnly.Size = new System.Drawing.Size(105, 17);
            this.optProfileOnly.TabIndex = 4;
            this.optProfileOnly.Text = "Valid Profile Only";
            this.optProfileOnly.UseVisualStyleBackColor = true;
            // 
            // FormEditFilter
            // 
            this.AcceptButton = this.buttonClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonClose;
            this.ClientSize = new System.Drawing.Size(412, 178);
            this.Controls.Add(this.optProfileOnly);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEditFilter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Filter";
            this.Load += new System.EventHandler(this.FormEditFilter_Load);
            this.groupBox1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RadioButton optBandAny;
        private System.Windows.Forms.RadioButton optBandB;
        private System.Windows.Forms.RadioButton optBandA;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.RadioButton optSsidAny;
        private System.Windows.Forms.RadioButton optSsidCurrentConnected;
        private System.Windows.Forms.RadioButton optSsidContains;
        private System.Windows.Forms.TextBox ssidNameFilter;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.CheckBox optProfileOnly;
    }
}