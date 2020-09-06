namespace  AggriPortal.API.Domain.Models
{
    /// <summary>
    /// Medical Condition Master Table.
    /// </summary>
    public class MedicalCondition
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
