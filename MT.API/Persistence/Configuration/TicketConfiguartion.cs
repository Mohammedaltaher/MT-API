using AggriPortal.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace  AggriPortal.API.Persistence.Configuration
{
    public class TicketConfiguartion : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.ToTable("Tickets");
            builder.HasKey(p => p.Id);



            builder.Property(p => p.Id).HasColumnName("Id");
            builder.Property(p => p.TicketReferenceId).HasMaxLength(50).HasDefaultValueSql("dbo.GenerateTicketReferenceId()");
            builder.Property(p => p.CreatedDate).HasColumnType("datetime");
            builder.Property(p => p.ClosedDate).HasColumnType("datetime");



            builder.Property(p => p.CreatedBy).HasMaxLength(450).IsRequired(true);
            builder.Property(p => p.ClosedBy).HasMaxLength(450);
            builder.HasOne(p => p.TicketType).WithMany(p => p.Tickets).HasForeignKey(p => p.TicketTypeId).IsRequired(true);
            builder.HasOne(p => p.TicketStatus).WithMany(p => p.Tickets).HasForeignKey(p => p.TicketStatusId).IsRequired(true);
            builder.HasOne(u => u.ApplicationUser).WithMany(t => t.Tickets).HasForeignKey(f => f.CreatedBy).IsRequired(true);
            builder.HasOne(u => u.Client).WithMany(t => t.Tickets).HasForeignKey(f => f.ClientId).IsRequired(false);
        }
    }



    public class TicketTypeConfiguartion : IEntityTypeConfiguration<TicketType>
    {
        public void Configure(EntityTypeBuilder<TicketType> builder)
        {
            builder.ToTable("TicketTypes");
            builder.HasKey(p => p.Id);



            builder.Property(p => p.Id).HasColumnName("Id");
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.NameAr).IsRequired();
            builder.Property(p => p.IsActive).HasDefaultValue(true);
            builder.Property(p => p.CreatedDate).HasColumnType("datetime");
            builder.Property(p => p.CreatedBy).HasMaxLength(450).IsRequired(false);



            #region Default Data
            builder.HasData(
                new TicketType { Id = 1, Name = "Inquiry", NameAr = "إستفسار / مقترح", IsActive = true, CreatedDate = DateTime.Now },
                new TicketType { Id = 2, Name = "Can't send insurance quotes request", NameAr = "لا أستطيع إرسال طلب تسعيرة", IsActive = true, CreatedDate = DateTime.Now },
                new TicketType { Id = 3, Name = "No insurance quotes", NameAr = "عروض أسعار شركات التأمين لا تظهر", IsActive = true, CreatedDate = DateTime.Now },
                new TicketType { Id = 4, Name = "Online Payment Issues", NameAr = "لا استطيع إكمال عملية الدفع", IsActive = true, CreatedDate = DateTime.Now },
                new TicketType { Id = 5, Name = "The amount was deducted from my balance and i didn't get the insurance policy", NameAr = "تم خصم المبلغ من رصيدي أكثر من مرة عند شراء وثيقة التأمين", IsActive = true, CreatedDate = DateTime.Now },
                new TicketType { Id = 6, Name = "Policy did not reach from the National Traffic Information Center (Absher)", NameAr = "تحديث وثيقة التأمين في حسابي علي أبشر", IsActive = true, CreatedDate = DateTime.Now },
                new TicketType { Id = 7, Name = "Login and registration problems ", NameAr = "لا استطيع التسجيل او الدخول للموقع", IsActive = true, CreatedDate = DateTime.Now },
                new TicketType { Id = 8, Name = "Other", NameAr = "أخرى", IsActive = true, CreatedDate = DateTime.Now }
                );
            #endregion
        }
    }



    public class TicketStatusConfiguartion : IEntityTypeConfiguration<TicketStatus>
    {
        public void Configure(EntityTypeBuilder<TicketStatus> builder)
        {
            builder.ToTable("TicketStatus");
            builder.HasKey(p => p.Id);



            builder.Property(p => p.Id).HasColumnName("Id");
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.NameAr).IsRequired();
            builder.Property(p => p.IsActive).HasDefaultValue(true);
            builder.Property(p => p.CreatedDate).HasColumnType("datetime");
            builder.Property(p => p.CreatedBy).HasMaxLength(450).IsRequired(false);



            #region Default Data
            builder.HasData(
                new TicketStatus { Id = 1, Name = "Pending", NameAr = "قيد الإنتظار", IsActive = true, CreatedDate = DateTime.Now },
                new TicketStatus { Id = 2, Name = "Work In Progress", NameAr = "قبد العمل", IsActive = true, CreatedDate = DateTime.Now },
                new TicketStatus { Id = 3, Name = "Resolved", NameAr = "مغلقة", IsActive = true, CreatedDate = DateTime.Now },
                new TicketStatus { Id = 4, Name = "Cancelled", NameAr = "ملغية", IsActive = true, CreatedDate = DateTime.Now });
            #endregion
        }
    }



    public class TicketFollowUpConfiguartion : IEntityTypeConfiguration<TicketFollowUp>
    {
        public void Configure(EntityTypeBuilder<TicketFollowUp> builder)
        {
            builder.ToTable("TicketsFollowUp");
            builder.HasKey(p => p.Id);



            builder.Property(p => p.Id).HasColumnName("Id");
            builder.Property(p => p.Message).IsRequired();
            builder.Property(p => p.CreatedDate).HasColumnType("datetime");
            builder.Property(p => p.CreatedBy).HasMaxLength(450).IsRequired(true);
            builder.HasOne(u => u.Ticket).WithMany(t => t.TicketFollowUps).HasForeignKey(f => f.TicketId).IsRequired(true);
        }
    }
}
