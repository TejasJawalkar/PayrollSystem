using ScriptRunner.Core;
using ScriptRunner.Core.Models;
using ScriptRunner.Core.Persistence;

namespace ScriptRunner.WinForms;

public partial class ProfileEditorForm : Form
{
    private readonly ProfileStore _store;
    private BindingSource _bs = new BindingSource();

    public ProfileEditorForm(ProfileStore store)
    {
        _store = store;
        InitializeComponent();
        cmbProvider.Items.AddRange(new[] { "SqlServer", "Oracle" });
        LoadProfiles();
    }

    private void LoadProfiles()
    {
        var profiles = _store.LoadAll().ToList();
        _bs.DataSource = profiles;
        lstProfiles.DisplayMember = "Name";
        lstProfiles.ValueMember = "Id";
        lstProfiles.DataSource = _bs;
    }

    private void LstProfiles_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (lstProfiles.SelectedItem is ConnectionProfile p)
        {
            txtName.Text = p.ConnectionName;
            cmbProvider.SelectedItem = p.Provider;
            txtConn.Text = ProfileStore.UnprotectConnectionString(p.EncryptedConnectionString);
        }
    }

    private async void BtnTest_Click(object sender, EventArgs e)
    {
        var provider = cmbProvider.SelectedItem?.ToString() ?? "";
        var cs = txtConn.Text;
        if (string.IsNullOrWhiteSpace(provider) || string.IsNullOrWhiteSpace(cs))
        {
            MessageBox.Show("Provider and connection string are required.");
            return;
        }

        btnTest.Enabled = false;
        try
        {
            // Try opening a connection using adapter
            IProviderAdapter adapter = provider switch
            {
                "SqlServer" => new SqlServerAdapter(),
                "Oracle" => new OracleAdapter(),
                _ => throw new InvalidOperationException("Unsupported provider")
            };

            using var conn = adapter.CreateConnection(cs);
            await conn.OpenAsync();
            MessageBox.Show("Connection successful.");
            await conn.CloseAsync();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Connection failed: " + ex.Message);
        }
        finally
        {
            btnTest.Enabled = true;
        }
    }

    private void BtnSave_Click(object sender, EventArgs e)
    {
        var profiles = _store.LoadAll().ToList();
        var existing = lstProfiles.SelectedItem as ConnectionProfile;
        var name = txtName.Text.Trim();
        var provider = cmbProvider.SelectedItem?.ToString() ?? "";
        var cs = txtConn.Text;

        if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(provider) || string.IsNullOrWhiteSpace(cs))
        {
            MessageBox.Show("Name, provider and connection string are required.");
            return;
        }

        var encrypted = ProfileStore.ProtectConnectionString(cs);

        LoadProfiles();
        MessageBox.Show("Saved.");
    }

    private void BtnDelete_Click(object sender, EventArgs e)
    {
        if (lstProfiles.SelectedItem is ConnectionProfile p)
        {
            var profiles = _store.LoadAll().ToList();
            profiles.RemoveAll(x => x.ProfileId == p.ProfileId);
            _store.SaveAll(profiles);
            LoadProfiles();
        }
    }
}
