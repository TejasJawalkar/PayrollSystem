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
        btnLoad = new Button();
        btnRun = new Button();
        btnProfiles = new Button();
        txtScript = new TextBox();
        txtLog = new TextBox();
        ProfileListBox = new ComboBox();
        label1 = new Label();
        label2 = new Label();
        label3 = new Label();
        txtName = new TextBox();
        textBox1 = new TextBox();
        SuspendLayout();
        // 
        // btnLoad
        // 
        btnLoad.FlatStyle = FlatStyle.Flat;
        btnLoad.Location = new Point(526, 74);
        btnLoad.Margin = new Padding(3, 2, 3, 2);
        btnLoad.Name = "btnLoad";
        btnLoad.Size = new Size(106, 22);
        btnLoad.TabIndex = 0;
        btnLoad.Text = "Load Script";
        btnLoad.UseVisualStyleBackColor = true;
        btnLoad.Click += BtnLoad_Click;
        // 
        // btnRun
        // 
        btnRun.FlatStyle = FlatStyle.Flat;
        btnRun.Location = new Point(721, 74);
        btnRun.Margin = new Padding(3, 2, 3, 2);
        btnRun.Name = "btnRun";
        btnRun.Size = new Size(105, 22);
        btnRun.TabIndex = 1;
        btnRun.Text = "Run Script";
        btnRun.UseVisualStyleBackColor = true;
        btnRun.Click += BtnRun_Click;
        // 
        // btnProfiles
        // 
        btnProfiles.FlatStyle = FlatStyle.Flat;
        btnProfiles.Location = new Point(924, 74);
        btnProfiles.Margin = new Padding(3, 2, 3, 2);
        btnProfiles.Name = "btnProfiles";
        btnProfiles.Size = new Size(105, 22);
        btnProfiles.TabIndex = 2;
        btnProfiles.Text = "Add Connection";
        btnProfiles.UseVisualStyleBackColor = true;
        btnProfiles.Click += BtnProfiles_Click;
        // 
        // txtScript
        // 
        txtScript.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        txtScript.Location = new Point(12, 113);
        txtScript.Margin = new Padding(3, 2, 3, 2);
        txtScript.Multiline = true;
        txtScript.Name = "txtScript";
        txtScript.ScrollBars = ScrollBars.Vertical;
        txtScript.Size = new Size(1020, 353);
        txtScript.TabIndex = 3;
        // 
        // txtLog
        // 
        txtLog.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        txtLog.Location = new Point(10, 491);
        txtLog.Margin = new Padding(3, 2, 3, 2);
        txtLog.Multiline = true;
        txtLog.Name = "txtLog";
        txtLog.ReadOnly = true;
        txtLog.ScrollBars = ScrollBars.Vertical;
        txtLog.Size = new Size(1020, 225);
        txtLog.TabIndex = 4;
        // 
        // ProfileListBox
        // 
        ProfileListBox.FlatStyle = FlatStyle.Popup;
        ProfileListBox.FormattingEnabled = true;
        ProfileListBox.Location = new Point(140, 21);
        ProfileListBox.Name = "ProfileListBox";
        ProfileListBox.Size = new Size(329, 23);
        ProfileListBox.TabIndex = 5;
        ProfileListBox.SelectedIndexChanged += ProfileListBox_SelectedIndexChanged;
        // 
        // label1
        // 
        label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        label1.Location = new Point(21, 24);
        label1.Name = "label1";
        label1.Size = new Size(113, 17);
        label1.TabIndex = 12;
        label1.Text = "Connect Source:";
        // 
        // label2
        // 
        label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        label2.Location = new Point(483, 38);
        label2.Name = "label2";
        label2.Size = new Size(113, 17);
        label2.TabIndex = 13;
        label2.Text = "Source Password:";
        label2.Visible = false;
        // 
        // label3
        // 
        label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        label3.Location = new Point(483, 9);
        label3.Name = "label3";
        label3.Size = new Size(113, 17);
        label3.TabIndex = 14;
        label3.Text = "Source Password:";
        label3.Visible = false;
        // 
        // txtName
        // 
        txtName.Location = new Point(602, 6);
        txtName.Name = "txtName";
        txtName.Size = new Size(243, 23);
        txtName.TabIndex = 15;
        txtName.Visible = false;
        // 
        // textBox1
        // 
        textBox1.Location = new Point(602, 35);
        textBox1.Name = "textBox1";
        textBox1.Size = new Size(243, 23);
        textBox1.TabIndex = 16;
        textBox1.Visible = false;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1041, 727);
        Controls.Add(textBox1);
        Controls.Add(txtName);
        Controls.Add(label3);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(ProfileListBox);
        Controls.Add(txtLog);
        Controls.Add(txtScript);
        Controls.Add(btnProfiles);
        Controls.Add(btnRun);
        Controls.Add(btnLoad);
        Margin = new Padding(3, 2, 3, 2);
        Name = "MainForm";
        Text = "ScriptRunner";
        Load += MainForm_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private System.Windows.Forms.Button btnLoad;
    private System.Windows.Forms.Button btnRun;
    private System.Windows.Forms.Button btnProfiles;
    private System.Windows.Forms.TextBox txtScript;
    private System.Windows.Forms.TextBox txtLog;
    private ComboBox ProfileListBox;
    private Label label1;
    private Label label2;
    private Label label3;
    private TextBox txtName;
    private TextBox textBox1;
}
