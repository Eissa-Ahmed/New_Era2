namespace New_Era.Infrastructure.Configration
{
    internal class StudentConfig : IEntityTypeConfiguration<Student>
    {
        public StudentConfig(EntityTypeBuilder<Student> builder) => Configure(builder);
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            //Types
            builder.ToTable(TablesNames.Students);
            builder.HasKey(k => k.Id);
            builder.HasMany(m => m.studentSubject)
                   .WithOne(o => o.Student)
                   .OnDelete(DeleteBehavior.Cascade)
                   .HasForeignKey(f => f.StudentId);

            //Properity
            builder.Property(i => i.Id)
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
            builder.Property(i => i.DepartmentId)
                   .IsRequired();

        }
    }
}
