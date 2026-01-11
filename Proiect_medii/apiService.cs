using System.Net.Http.Json;
using Proiect_medii.Models;

namespace Proiect_medii
{
    public class ApiService
    {
        private readonly HttpClient _http;

        public ApiService()
        {
            _http = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7014/api/")
            };
        }


        public async Task<List<Agent>> GetAgentsAsync()
        {
            return await _http.GetFromJsonAsync<List<Agent>>("agents");
        }

        public async Task AddAgentAsync(Agent agent)
        {
            await _http.PostAsJsonAsync("agents", agent);
        }

        public async Task UpdateAgentAsync(Agent agent)
        {
            await _http.PutAsJsonAsync($"agents/{agent.AgentId}", agent);
        }

        public async Task DeleteAgentAsync(int agentId)
        {
            await _http.DeleteAsync($"agents/{agentId}");
        }

        public Task<List<Client>> GetClientsAsync()
    => _http.GetFromJsonAsync<List<Client>>("clients");

        public Task AddClientAsync(Client client)
            => _http.PostAsJsonAsync("clients", client);

        public Task UpdateClientAsync(Client client)
            => _http.PutAsJsonAsync($"clients/{client.ClientId}", client);

        public Task DeleteClientAsync(int id)
            => _http.DeleteAsync($"clients/{id}");

        public Task<List<TourPackage>> GetTourPackagesAsync()
    => _http.GetFromJsonAsync<List<TourPackage>>("tourpackages");

        public Task AddTourPackageAsync(TourPackage package)
            => _http.PostAsJsonAsync("tourpackages", package);

        public Task UpdateTourPackageAsync(TourPackage package)
            => _http.PutAsJsonAsync($"tourpackages/{package.PackageId}", package);

        public Task DeleteTourPackageAsync(int id)
            => _http.DeleteAsync($"tourpackages/{id}");

        public Task<List<Booking>> GetBookingsAsync()
        => _http.GetFromJsonAsync<List<Booking>>("bookings");

        public Task AddBookingAsync(Booking booking)
            => _http.PostAsJsonAsync("bookings", booking);

        public Task UpdateBookingAsync(Booking booking)
            => _http.PutAsJsonAsync($"bookings/{booking.BookingId}", booking);

        public Task DeleteBookingAsync(int id)
            => _http.DeleteAsync($"bookings/{id}");

    }
}
