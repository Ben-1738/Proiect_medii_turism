using Proiect_medii.Models;

namespace Proiect_medii;

public partial class TourPackagePage : ContentPage
{
    private ApiService _apiService = new();
    private TourPackage _selectedPackage;

    public TourPackagePage()
    {
        InitializeComponent();
        LoadPackages();
    }

    private async void LoadPackages()
    {
        PackagesCollection.ItemsSource = await _apiService.GetTourPackagesAsync();
    }

    private async void OnAddClicked(object sender, EventArgs e)
    {
        if (!ValidateInput()) return;

        var package = new TourPackage
        {
            Name = NameEntry.Text,
            Destination = DestinationEntry.Text,
            Price = decimal.Parse(PriceEntry.Text),
            LeavingDate = LeavingDatePicker.Date,
            ReturnDate = ReturnDatePicker.Date
        };

        await _apiService.AddTourPackageAsync(package);
        ClearForm();
        LoadPackages();
    }

    private async void OnUpdateClicked(object sender, EventArgs e)
    {
        if (_selectedPackage == null) return;

        _selectedPackage.Name = NameEntry.Text;
        _selectedPackage.Destination = DestinationEntry.Text;
        _selectedPackage.Price = decimal.Parse(PriceEntry.Text);
        _selectedPackage.LeavingDate = LeavingDatePicker.Date;
        _selectedPackage.ReturnDate = ReturnDatePicker.Date;

        await _apiService.UpdateTourPackageAsync(_selectedPackage);
        LoadPackages();
    }

    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        if (_selectedPackage == null) return;

        await _apiService.DeleteTourPackageAsync(_selectedPackage.PackageId);
        ClearForm();
        LoadPackages();
    }

    private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        _selectedPackage = e.CurrentSelection.FirstOrDefault() as TourPackage;
        if (_selectedPackage == null) return;

        NameEntry.Text = _selectedPackage.Name;
        DestinationEntry.Text = _selectedPackage.Destination;
        PriceEntry.Text = _selectedPackage.Price.ToString();
        LeavingDatePicker.Date = _selectedPackage.LeavingDate;
        ReturnDatePicker.Date = _selectedPackage.ReturnDate;
    }

    private bool ValidateInput()
    {
        if (string.IsNullOrWhiteSpace(NameEntry.Text) ||
            string.IsNullOrWhiteSpace(DestinationEntry.Text) ||
            string.IsNullOrWhiteSpace(PriceEntry.Text))
        {
            DisplayAlert("Eroare", "Completeaza toate campurile", "OK");
            return false;
        }

        if (!decimal.TryParse(PriceEntry.Text, out _))
        {
            DisplayAlert("Eroare", "Pret invalid", "OK");
            return false;
        }

        return true;
    }

    private void ClearForm()
    {
        NameEntry.Text = "";
        DestinationEntry.Text = "";
        PriceEntry.Text = "";
        LeavingDatePicker.Date = DateTime.Today;
        ReturnDatePicker.Date = DateTime.Today;
        _selectedPackage = null;
    }
}
