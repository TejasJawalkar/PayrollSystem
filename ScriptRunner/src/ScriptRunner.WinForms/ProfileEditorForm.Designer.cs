namespace ScriptRunner.WinForms;

partial class ProfileEditorForm
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

    private void InitializeComponent()
    {
        this.lblName = new System.Windows.Forms.Label();
        this.txtName = new System.Windows.Forms.TextBox();
        this.lblProvider = new System.Windows.Forms.Label();
        this.cmbProvider = new System.Windows.Forms.ComboBox();
        this.lblConn = new System.Windows.Forms.Label();
        this.txtConn = new System.Windows.Forms.TextBox();
        this.btnTest = new System.Windows.Forms.Button();
        this.btnSave = new System.Windows.Forms.Button();
        this.lstProfiles = new System.Windows.Forms.ListBox();
        this.btnDelete = new System.Windows.Forms.Button();
        this.SuspendLayout();
        // 
        // lblName
        // 
        this.lblName.Location = new System.Drawing.Point(12, 12);
        this.lblName.Name = "lblName";
        this.lblName.Size = new System.Drawing.Size(80, 23);
        this.lblName.Text = "Name:";
        // 
        // txtName
        // 
        this.txtName.Location = new System.Drawing.Point(98, 12);
        this.txtName.Size = new System.Drawing.Size(360, 23);
        // 
        // lblProvider
        // 
        this.lblProvider.Location = new System.Drawing.Point(12, 44);
        this.lblProvider.Name = "lblProvider";
        this.lblProvider.Size = new System.Drawing.Size(80, 23);
        this.lblProvider.Text = "Provider:";
        // 
        // cmbProvider
        // 
        this.cmbProvider.Location = new System.Drawing.Point(98, 44);
        this.cmbProvider.Size = new System.Drawing.Size(200, 23);
        // 
        // lblConn
        // 
        this.lblConn.Location = new System.Drawing.Point(12, 76);
        this.lblConn.Name = "lblConn";
        this.lblConn.Size = new System.Drawing.Size(80, 23);
        this.lblConn.Text = "Connection String:";
        // 
        // txtConn
        // 
        this.txtConn.Location = new System.Drawing.Point(15, 102);
        this.txtConn.Multiline = true;
        this.txtConn.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        this.txtConn.Size = new System.Drawing.Size(760, 120);
        // 
        // btnTest
        // 
        this.btnTest.Location = new System.Drawing.Point(15, 232);
        this.btnTest.Name = "btnTest";
        this.btnTest.Size = new System.Drawing.Size(100, 30);
        this.btnTest.Text = "Test Connection";
        this.btnTest.UseVisualStyleBackColor = true;
        this.btnTest.Click += new System.EventHandler(this.BtnTest_Click);
        // 
        // btnSave
        // 
        this.btnSave.Location = new System.Drawing.Point(121, 232);
        this.btnSave.Name = "btnSave";
        this.btnSave.Size = new System.Drawing.Size(100, 30);
        this.btnSave.Text = "Save Profile";
        this.btnSave.UseVisualStyleBackColor = true;
        this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
        // 
        // lstProfiles
        // 
        this.lstProfiles.Location = new System.Drawing.Point(480, 12);
        this.lstProfiles.Size = new System.Drawing.Size(295, 208);
        this.lstProfiles.SelectedIndexChanged += new System.EventHandler(this.LstProfiles_SelectedIndexChanged);
        // 
        // btnDelete
        // 
        this.btnDelete.Location = new System.Drawing.Point(480, 232);
        this.btnDelete.Name = "btnDelete";
        this.btnDelete.Size = new System.Drawing.Size(100, 30);
        this.btnDelete.Text = "Delete";
        this.btnDelete.UseVisualStyleBackColor = true;
        this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
        // 
        // ProfileEditorForm
        // 
        this.ClientSize = new System.Drawing.Size(794, 276);
        this.Controls.Add(this.btnDelete);
        this.Controls.Add(this.lstProfiles);
        this.Controls.Add(this.btnSave);
        this.Controls.Add(this.btnTest);
        this.Controls.Add(this.txtConn);
        this.Controls.Add(this.lblConn);
        this.Controls.Add(this.cmbProvider);
        this.Controls.Add(this.lblProvider);
        this.Controls.Add(this.txtName);
        this.Controls.Add(this.lblName);
        this.Name = "ProfileEditorForm";
        this.Text = "Profile Editor";
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private System.Windows.Forms.Label lblName;
    private System.Windows.Forms.TextBox txtName;
    private System.Windows.Forms.Label lblProvider;
    private System.Windows.Forms.ComboBox cmbProvider;
    private System.Windows.Forms.Label lblConn;
    private System.Windows.Forms.TextBox txtConn;
    private System.Windows.Forms.Button btnTest;
    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.ListBox lstProfiles;
    private System.Windows.Forms.Button btnDelete;
}
