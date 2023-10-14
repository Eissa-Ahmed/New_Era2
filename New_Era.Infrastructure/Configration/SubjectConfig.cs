namespace New_Era.Infrastructure.Configration
{
    internal class SubjectConfig : IEntityTypeConfiguration<Subject>
    {
        public SubjectConfig(EntityTypeBuilder<Subject> builder) => Configure(builder);
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            //Types
            builder.ToTable(TablesNames.Subjects);
            builder.HasKey(k => k.Id);
            builder.HasMany(m => m.studentSubject)
                   .WithOne(o => o.subject)
                   .OnDelete(DeleteBehavior.Cascade)
                   .HasForeignKey(f => f.SubjectId);
            builder.HasMany(m => m.DepartmentSubjects)
                   .WithOne(o => o.Subject)
                   .OnDelete(DeleteBehavior.Cascade)
                   .HasForeignKey(f => f.SubjectId);
            builder.HasMany(m => m.InstractorSubject)
                  .WithOne(o => o.Subject)
                  .OnDelete(DeleteBehavior.Cascade)
                  .HasForeignKey(f => f.SubjectId);

            //Properity
            builder.Property(i => i.Id)
                   .ValueGeneratedOnAdd();
            builder.Property(i => i.NameAr)
                   .IsRequired()
                   .HasMaxLength(50);
            builder.Property(i => i.NameEn)
                   .IsRequired()
                   .HasMaxLength(50);

        }
    }
}
