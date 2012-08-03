using SignalR.Hubs;

namespace TaxiApp
{
    public class TaxiHub : Hub
    {
        public string Ping()
        {
            var hub = SignalR.GlobalHost.ConnectionManager.GetHubContext<TaxiHub>();
            //hub.Clients.requestTaxi(new { lat=100,lon=100,name="oijo",mobileNumer="iojoij"});
            hub.Clients.sayHello();
            return "ok";
        }
    }
}