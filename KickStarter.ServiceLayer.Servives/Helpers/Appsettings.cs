namespace KickStarter.ServiceLayer.Services.Helpers
{
    public class Appsettings
    {
        public ConnectionStrings ConnectionStrings { get; set; }
    }

    public class ConnectionStrings
    {
        public string DefaultConnection { get; set; }
    }
}