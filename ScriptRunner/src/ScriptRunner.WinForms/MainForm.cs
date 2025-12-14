using ScriptRunner.Core.Persistence;

namespace ScriptRunner.WinForms;

public partial class MainForm : Form
{
    private readonly ScriptRunner.Core.ScriptRunner _runner;
    private readonly ProfileStore _profileStore;

    public MainForm(ScriptRunner.Core.ScriptRunner runner, ProfileStore profileStore)
    {
        InitializeComponent();
        _runner = runner;
        _profileStore = profileStore;
    }

    private void BtnLoad_Click(object sender, EventArgs e)
    {
        using var dlg = new OpenFileDialog { Filter = "SQL files (*.sql)|*.sql|All files (*.*)|*.*" };
        if (dlg.ShowDialog() == DialogResult.OK)
        {
            txtScript.Text = File.ReadAllText(dlg.FileName);
        }
    }

    private async void BtnRun_Click(object sender, EventArgs e)
    {
        txtLog.Clear();
        var profiles = _profileStore.LoadAll().ToList();
        var profile = profiles.FirstOrDefault();
        if (profile == null)
        {
            txtLog.AppendText("No connection profile found. Click Profiles... to add one.\r\n");
            return;
        }

        txtLog.AppendText($"Using profile: {profile.ConnectionName} ({profile.Provider})\r\n");
        var cts = new CancellationTokenSource(TimeSpan.FromMinutes(10));
        try
        {
            var res = await _runner.RunAsync(txtScript.Text, profile, cts.Token);
            if (res.Success)
            {
                txtLog.AppendText("Success:\r\n" + res.Output);
            }
            else
            {
                txtLog.AppendText("Failed:\r\n" + res.Error?.Message + "\r\n" + res.Output);
            }
        }
        catch (Exception ex)
        {
            txtLog.AppendText("Exception: " + ex.Message + "\r\n");
        }
    }

    private void BtnProfiles_Click(object sender, EventArgs e)
    {
        using var edit = new ProfileEditorForm(_profileStore);
        edit.ShowDialog(this);
    }
}
