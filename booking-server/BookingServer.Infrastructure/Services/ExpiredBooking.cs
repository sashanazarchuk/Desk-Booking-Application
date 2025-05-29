using BookingServer.Application.Interfaces;
using BookingServer.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace BookingServer.Infrastructure.Services
{
    public class ExpiredBooking : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly TimeSpan _checkInterval = TimeSpan.FromMinutes(1);

        public ExpiredBooking(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }



        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                using var scope = _scopeFactory.CreateScope();
                var bookingRepo = scope.ServiceProvider.GetRequiredService<IBookingRepository>();
                var dbContext = scope.ServiceProvider.GetRequiredService<BookingDbContext>();

                var now = DateTime.Now;
                var expiredBookings = await bookingRepo.GetExpiredBookingsAsync(now, cancellationToken);

                 dbContext.Bookings.RemoveRange(expiredBookings);

                await dbContext.SaveChangesAsync(cancellationToken);

                await Task.Delay(_checkInterval, cancellationToken);
            }
        }
    }
}