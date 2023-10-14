namespace New_Era.Infrastructure.Configration
{
    public class DepartmentSubjectsConfig : IEntityTypeConfiguration<DepartmentSubject>
    {
        public DepartmentSubjectsConfig(EntityTypeBuilder<DepartmentSubject> builder)
        {
            Configure(builder);
        }
        public void Configure(EntityTypeBuilder<DepartmentSubject> builder)
        {
            //Types
            builder.ToTable(TablesNames.DepartmentSubjects);
            builder.HasKey(k => new { k.SubjectId, k.DepartmentId });

            //Properity
        }
    }
}
