namespace KickStartrer.Service.Helpers
{
    /// <summary>
    /// Application setiings storage
    /// </summary>
    public class Appsettings
    {
        /// <summary>
        /// Stores the connection string.
        /// </summary>
        public ConnectionStrings ConnectionStrings { get; set; }
    }

    /// <summary>
    /// Connection string storage.
    /// </summary>
    public class ConnectionStrings
    {
        /// <summary>
        /// Stores the default connection.
        /// </summary>
        public string DefaultConnection { get; set; }
    }
}