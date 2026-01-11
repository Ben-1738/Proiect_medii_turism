using Proiect_medii.Models;

namespace Proiect_medii;

public partial class BookingPage : ContentPage
{
    private readonly ApiService _apiService = new();
    private Booking _selectedBooking;

    public BookingPage()
    {
        InitializeComponent();
        LoadData();
    }

    private async void LoadData()
    {
        ClientPicker.ItemsSource = await _apiService.GetClientsAsync();
        PackagePicker.ItemsSource = await _apiService.GetTourPackagesAsync();
        RefreshBookings();
    }

    private async void RefreshBookings()
    {
        BookingsCollection.ItemsSource = null;
        BookingsCollection.ItemsSource = await _apiService.GetBookingsAsync();
    }

 
    private async void OnAddClicked(object sender, EventArgs e)
    {
        if (!Validate()) return;

        var client = (Client)ClientPicker.SelectedItem;
        var package = (TourPackage)PackagePicker.SelectedItem;

        var booking = new Booking
        {
            ClientId = client.ClientId,
            PackageId = package.PackageId,
            NumberOfPeople = int.Parse(PeopleEntry.Text),
            Observations = ObservationsEntry.Text
        };

        await _apiService.AddBookingAsync(booking);
        ClearForm();
        RefreshBookings();
    }


    private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        _selectedBooking = e.CurrentSelection.FirstOrDefault() as Booking;
        if (_selectedBooking == null) return;

        ClientPicker.SelectedItem = _selectedBooking.Client;
        PackagePicker.SelectedItem = _selectedBooking.TourPackage;
        PeopleEntry.Text = _selectedBooking.NumberOfPeople.ToString();
        ObservationsEntry.Text = _selectedBooking.Observations;
    }

    
    private async void OnUpdateClicked(object sender, EventArgs e)
    {
        if (_selectedBooking == null || !Validate()) return;

        var client = (Client)ClientPicker.SelectedItem;
        var package = (TourPackage)PackagePicker.SelectedItem;

        _selectedBooking.ClientId = client.ClientId;
        _selectedBooking.PackageId = package.PackageId;
        _selectedBooking.NumberOfPeople = int.Parse(PeopleEntry.Text);
        _selectedBooking.Observations = ObservationsEntry.Text;

        await _apiService.UpdateBookingAsync(_selectedBooking);
        ClearForm();
        RefreshBookings();
    }

   
    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        if (_selectedBooking == null) return;

        bool confirm = await DisplayAlert(
            "Confirmare",
            "Sigur vrei să ștergi rezervarea?",
            "Da", "Nu");

        if (!confirm) return;

        await _apiService.DeleteBookingAsync(_selectedBooking.BookingId);
        ClearForm();
        RefreshBookings();
    }

    private bool Validate()
    {
        return ClientPicker.SelectedItem != null &&
               PackagePicker.SelectedItem != null &&
               int.TryParse(PeopleEntry.Text, out int p) && p > 0;
    }

    private void ClearForm()
    {
        ClientPicker.SelectedItem = null;
        PackagePicker.SelectedItem = null;
        PeopleEntry.Text = "";
        ObservationsEntry.Text = "";
        _selectedBooking = null;
    }
}
