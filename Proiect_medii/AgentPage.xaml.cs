using Proiect_medii.Models;

namespace Proiect_medii;

public partial class AgentPage : ContentPage
{
    private ApiService _apiService = new();
    private Agent _selectedAgent;

    public AgentPage()
    {
        InitializeComponent();
        LoadAgents();
    }

    private async void LoadAgents()
    {
        AgentsCollection.ItemsSource = await _apiService.GetAgentsAsync();
    }

    private async void OnAddClicked(object sender, EventArgs e)
    {
        if (!Validate()) return;

        var agent = new Agent
        {
            Nume = NumeEntry.Text,
            Prenume = PrenumeEntry.Text,
            Email = EmailEntry.Text,
            Telefon = TelefonEntry.Text
        };

        await _apiService.AddAgentAsync(agent);
        ClearForm();
        LoadAgents();
    }

    private async void OnUpdateClicked(object sender, EventArgs e)
    {
        if (_selectedAgent == null) return;

        _selectedAgent.Nume = NumeEntry.Text;
        _selectedAgent.Prenume = PrenumeEntry.Text;
        _selectedAgent.Email = EmailEntry.Text;
        _selectedAgent.Telefon = TelefonEntry.Text;

        await _apiService.UpdateAgentAsync(_selectedAgent);
        LoadAgents();
    }

    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        if (_selectedAgent == null) return;

        await _apiService.DeleteAgentAsync(_selectedAgent.AgentId);
        ClearForm();
        LoadAgents();
    }

    private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        _selectedAgent = e.CurrentSelection.FirstOrDefault() as Agent;

        if (_selectedAgent == null) return;

        NumeEntry.Text = _selectedAgent.Nume;
        PrenumeEntry.Text = _selectedAgent.Prenume;
        EmailEntry.Text = _selectedAgent.Email;
        TelefonEntry.Text = _selectedAgent.Telefon;
    }

    private bool Validate()
    {
        if (string.IsNullOrWhiteSpace(NumeEntry.Text) ||
            string.IsNullOrWhiteSpace(PrenumeEntry.Text) ||
            string.IsNullOrWhiteSpace(EmailEntry.Text))
        {
            DisplayAlert("Eroare", "Completeaza campurile obligatorii", "OK");
            return false;
        }
        return true;
    }

    private void ClearForm()
    {
        NumeEntry.Text = "";
        PrenumeEntry.Text = "";
        EmailEntry.Text = "";
        TelefonEntry.Text = "";
        TelefonEntry.Text = "";
        _selectedAgent = null;
    }
}
