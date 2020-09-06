namespace  AggriPortal.API.Domain.Models
{
    /// <summary>
    /// Mileage Master Table.
    /// </summary>
    public class Mileage
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
