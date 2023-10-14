namespace New_Era.Infrastructure.Configration
{

    internal class StudentSubjectConfig : IEntityTypeConfiguration<StudentSubject>
    {
        public StudentSubjectConfig(EntityTypeBuilder<StudentSubject> builder) => Configure(builder);
        public void Configure(EntityTypeBuilder<StudentSubject> builder)
        {
            //Types
            builder.ToTable(TablesNames.StudentSubjects);
            builder.HasKey(k => new { k.StudentId, k.SubjectId });

            //Properity

        }

    }
}
