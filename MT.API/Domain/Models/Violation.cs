namespace  AggriPortal.API.Domain.Models
{
    /// <summary>
    /// Violation Master Table.
    /// </summary>
    public class Violation
    {
        /// <summary>
        /// Primary Key.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Violation in English
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Violation in Arabic
        /// </summary>
        public string NameAr { get; set; }
    }
}
