namespace New_Era.Infrastructure.Configration
{
    public class InstractorConfig : IEntityTypeConfiguration<Instructor>
    {
        public InstractorConfig(EntityTypeBuilder<Instructor> builder)
        {
            Configure(builder);
        }
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            //Type
            builder.ToTable(TablesNames.Instractors);
            builder.HasKey(k => k.Id);
            builder.HasMany(m => m.Instructors)
                   .WithOne(o => o.InstructorSupervisor)
                   .OnDelete(DeleteBehavior.Restrict)
                   .HasForeignKey(f => f.SupervisorId);
            builder.HasMany(m => m.InstractorSubjects)
                   .WithOne(o => o.Instructor)
                   .OnDelete(DeleteBehavior.Cascade)
                   .HasForeignKey(f => f.InstractorId);
            builder.HasOne(o => o.DepartmentTech)
                   .WithMany(m => m.InstructorTech)
                   .OnDelete(DeleteBehavior.Cascade)
                   .HasForeignKey(f => f.DepartmentId);



            //Properity
            builder.Property(p => p.Id)
                   .ValueGeneratedOnAdd();
            builder.Property(i => i.NameAr)
                   .IsRequired()
                   .HasMaxLength(50);
            builder.Property(i => i.NameEn)
                   .IsRequired()
                   .HasMaxLength(50);
            builder.Property(i => i.AddressAr)
                   .IsRequired()
                   .HasMaxLength(150);
            builder.Property(i => i.AddressEn)
                   .IsRequired()
                   .HasMaxLength(150);
            builder.Property(i => i.Salary)
                   .IsRequired()
                   .HasColumnType("decimal(7,2)");//85000.00


        }
    }
}
