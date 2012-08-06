using SignalR.Hubs;

namespace TaxiApp
{
    public class TaxiHub : Hub
    {
        public string Ping()
        {
            var hub = SignalR.GlobalHost.ConnectionManager.GetHubContext<TaxiHub>();
            hub.Clients.sayHello();

            return "ok";
        }
    }
}