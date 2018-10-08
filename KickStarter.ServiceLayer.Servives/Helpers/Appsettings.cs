namespace KickStarter.ServiceLayer.Helpers
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