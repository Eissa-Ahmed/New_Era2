namespace New_Era.Infrastructure.Configration
{
    public class DepartmentConfig : IEntityTypeConfiguration<Department>
    {
        public DepartmentConfig(EntityTypeBuilder<Department> builder)
        {
            Configure(builder);
        }
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            //Type
            builder.ToTable(TablesNames.Department);
            builder.HasKey(k => k.Id);
            builder.HasMany(m => m.Student)
                   .WithOne(o => o.Department)
                   .HasForeignKey(f => f.DepartmentId)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(m => m.DepartmentSubjects)
                   .WithOne(o => o.Department)
                   .HasForeignKey(f => f.DepartmentId)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(o => o.InstructorManage)
                   .WithOne(m => m.DepartmentManage)
                   .HasForeignKey<Department>(f => f.InstManage)
                   .OnDelete(DeleteBehavior.Restrict);

            //Properity
            builder.Property(k => k.Id)
                   .ValueGeneratedOnAdd();
            builder.Property(p => p.NameAr)
                   .IsRequired()
                   .HasMaxLength(50);
            builder.Property(p => p.NameEn)
                   .IsRequired()
                   .HasMaxLength(50);

        }
    }
}
