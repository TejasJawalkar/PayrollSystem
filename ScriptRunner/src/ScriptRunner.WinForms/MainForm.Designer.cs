namespace ScriptRunner.WinForms;

partial class MainForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        this.btnLoad = new System.Windows.Forms.Button();
        this.btnRun = new System.Windows.Forms.Button();
        this.btnProfiles = new System.Windows.Forms.Button();
        this.txtScript = new System.Windows.Forms.TextBox();
        this.txtLog = new System.Windows.Forms.TextBox();
        this.SuspendLayout();
        // 
        // btnLoad
        // 
        this.btnLoad.Location = new System.Drawing.Point(12, 12);
        this.btnLoad.Name = "btnLoad";
        this.btnLoad.Size = new System.Drawing.Size(100, 30);
        this.btnLoad.TabIndex = 0;
        this.btnLoad.Text = "Load Script";
        this.btnLoad.UseVisualStyleBackColor = true;
        this.btnLoad.Click += new System.EventHandler(this.BtnLoad_Click);
        // 
        // btnRun
        // 
        this.btnRun.Location = new System.Drawing.Point(118, 12);
        this.btnRun.Name = "btnRun";
        this.btnRun.Size = new System.Drawing.Size(100, 30);
        this.btnRun.TabIndex = 1;
        this.btnRun.Text = "Run";
        this.btnRun.UseVisualStyleBackColor = true;
        this.btnRun.Click += new System.EventHandler(this.BtnRun_Click);
        // 
        // btnProfiles
        // 
        this.btnProfiles.Location = new System.Drawing.Point(224, 12);
        this.btnProfiles.Name = "btnProfiles";
        this.btnProfiles.Size = new System.Drawing.Size(120, 30);
        this.btnProfiles.TabIndex = 2;
        this.btnProfiles.Text = "Profiles...";
        this.btnProfiles.UseVisualStyleBackColor = true;
        this.btnProfiles.Click += new System.EventHandler(this.BtnProfiles_Click);
        // 
        // txtScript
        // 
        this.txtScript.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
        this.txtScript.Location = new System.Drawing.Point(12, 48);
        this.txtScript.Multiline = true;
        this.txtScript.Name = "txtScript";
        this.txtScript.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        this.txtScript.Size = new System.Drawing.Size(960, 420);
        this.txtScript.TabIndex = 3;
        // 
        // txtLog
        // 
        this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
        this.txtLog.Location = new System.Drawing.Point(12, 474);
        this.txtLog.Multiline = true;
        this.txtLog.Name = "txtLog";
        this.txtLog.ReadOnly = true;
        this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        this.txtLog.Size = new System.Drawing.Size(960, 180);
        this.txtLog.TabIndex = 4;
        // 
        // MainForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(984, 666);
        this.Controls.Add(this.txtLog);
        this.Controls.Add(this.txtScript);
        this.Controls.Add(this.btnProfiles);
        this.Controls.Add(this.btnRun);
        this.Controls.Add(this.btnLoad);
        this.Name = "MainForm";
        this.Text = "ScriptRunner";
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btnLoad;
    private System.Windows.Forms.Button btnRun;
    private System.Windows.Forms.Button btnProfiles;
    private System.Windows.Forms.TextBox txtScript;
    private System.Windows.Forms.TextBox txtLog;
}
