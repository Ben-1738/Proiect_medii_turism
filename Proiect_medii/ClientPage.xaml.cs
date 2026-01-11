using Proiect_medii.Models;

namespace Proiect_medii;

public partial class ClientPage : ContentPage
{
    private ApiService _apiService = new();
    private Client _selectedClient;

    public ClientPage()
    {
        InitializeComponent();
        LoadClients();
    }

    private async void LoadClients()
    {
        ClientsCollection.ItemsSource = await _apiService.GetClientsAsync();
    }

    private async void OnAddClicked(object sender, EventArgs e)
    {
        if (!Validate()) return;

        var client = new Client
        {
            LastName = LastNameEntry.Text,
            FirstName = FirstNameEntry.Text,
            Email = EmailEntry.Text
        };

        await _apiService.AddClientAsync(client);
        ClearForm();
        LoadClients();
    }

    private async void OnUpdateClicked(object sender, EventArgs e)
    {
        if (_selectedClient == null) return;

        _selectedClient.LastName = LastNameEntry.Text;
        _selectedClient.FirstName = FirstNameEntry.Text;
        _selectedClient.Email = EmailEntry.Text;

        await _apiService.UpdateClientAsync(_selectedClient);
        LoadClients();
    }

    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        if (_selectedClient == null) return;

        await _apiService.DeleteClientAsync(_selectedClient.ClientId);
        ClearForm();
        LoadClients();
    }

    private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        _selectedClient = e.CurrentSelection.FirstOrDefault() as Client;
        if (_selectedClient == null) return;

        LastNameEntry.Text = _selectedClient.LastName;
        FirstNameEntry.Text = _selectedClient.FirstName;
        EmailEntry.Text = _selectedClient.Email;
    }

    private bool Validate()
    {
        if (string.IsNullOrWhiteSpace(LastNameEntry.Text) ||
            string.IsNullOrWhiteSpace(FirstNameEntry.Text) ||
            string.IsNullOrWhiteSpace(EmailEntry.Text))
        {
            DisplayAlert("Eroare", "Completeaza toate campurile", "OK");
            return false;
        }
        return true;
    }

    private void ClearForm()
    {
        LastNameEntry.Text = "";
        FirstNameEntry.Text = "";
        EmailEntry.Text = "";
        _selectedClient = null;
    }
}
