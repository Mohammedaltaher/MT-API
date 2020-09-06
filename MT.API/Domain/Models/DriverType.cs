namespace  AggriPortal.API.Domain.Models
{
    /// <summary>
    /// Driver Type Master Table.
    /// </summary>
    public class DriverType
    {
        /// <summary>
        /// Key.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name in english.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Name in arabic.
        /// </summary>
        public string NameAr { get; set; }
    }
}
