namespace  AggriPortal.API.Domain.Models
{
    /// <summary>
    /// Promo Code Master Table.
    /// </summary>
    public class PromoCode
    {
        /// <summary>
        /// Key
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Name in english.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Name in arabic
        /// </summary>
        public string NameAr { get; set; }
    }
}
