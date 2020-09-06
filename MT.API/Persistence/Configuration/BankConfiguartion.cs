using AggriPortal.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace  AggriPortal.API.Persistence.Configuration
{
    public class BankConfiguartion : IEntityTypeConfiguration<Bank>
    {
        public void Configure(EntityTypeBuilder<Bank> builder)
        {
            builder.ToTable("SettingsBanks");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("Id");

            builder.Property(p => p.Name)
                   .HasMaxLength(250);

            builder.Property(p => p.NameAr)
                   .HasMaxLength(250);
            builder.Property(p => p.Code)
                   .HasMaxLength(50);


            #region Default Data
            builder.HasData(
                new Bank { Id = 1, Name = "Alinma Bank", NameAr = "مصرف الإنماء", Code = "5" },
                new Bank { Id = 2, Name = "The National Commercial Bank", NameAr = "البنك الأهلي التجاري ", Code = "10" },
                new Bank { Id = 3, Name = "Bank AlBilad", NameAr = "بنك البلاد",Code="15" },
                new Bank { Id = 4, Name = "Riyad Bank", NameAr = "بنك الرياض", Code = "20" },
                new Bank { Id = 5, Name = "Arab National Bank", NameAr = "البنك العربي الوطني ", Code = "30" },
                new Bank { Id = 6, Name = "Samba Financial Group (Samba)", NameAr = "مجموعة سامبا المالية (سامبا) ", Code = "40" },
                new Bank { Id = 7, Name = "The Saudi British Bank (SABB)", NameAr = "البنك السعودي البريطاني ", Code = "45" },
                new Bank { Id = 8, Name = "Alawwal Bank", NameAr = "البنك الأول ", Code = "50" },
                new Bank { Id = 9, Name = "Banque Saudi Fransi", NameAr = "البنك السعودي الفرنسي", Code = "55" },
                new Bank { Id = 10, Name = "Bank AlJazira", NameAr = "بنك الجزيرة", Code = "60" },
                new Bank { Id = 11, Name = "Saudi Investment Bank", NameAr = "البنك السعودي للاستثمار", Code = "65" },
                new Bank { Id = 12, Name = "Al Rajhi Bank", NameAr = "مصرف الراجحي", Code = "80" },
                new Bank { Id = 13, Name = "National Bank of Bahrain (NBB)", NameAr = "بنك البحرين الوطني", Code = "71" },
                new Bank { Id = 14, Name = "National Bank of Kuwait (NBK)", NameAr = "بنك الكويت الوطني", Code = "75" },
                new Bank { Id = 15, Name = "Muscat Bank", NameAr = "بنك مسقط", Code = "76" },
                new Bank { Id = 16, Name = "Deutsche Bank", NameAr = "دويتشه بنك", Code = "81" },
                new Bank { Id = 17, Name = "National Bank Of Pakistan (NBP)", NameAr = "بنك باكستان الوطني", Code = "82" },
                new Bank { Id = 18, Name = "State Bank of India(SBI)", NameAr = "ستيت بنك أوف إنديا", Code = "83" },
                new Bank { Id = 19, Name = "T.C.ZIRAAT BANKASI A.S.", NameAr = "بنك تي سي زراعات بانكاسي", Code = "84" },
                new Bank { Id = 20, Name = "BNP Paribas", NameAr = "بي إن بي باريباس", Code = "85" },
                new Bank { Id = 21, Name = "J.P. Morgan Chase N.A", NameAr = "جي بي مورقان تشيز إن أيه", Code = "86" },
                new Bank { Id = 22, Name = "Gulf International Bank(GIB)", NameAr = "بنك الخليج الدولي", Code = "90" },
                new Bank { Id = 23, Name = "Emirates (NBD)", NameAr = "بنك الإمارات دبي الوطني", Code = "95" }
                );
            #endregion
        }
    }
}
