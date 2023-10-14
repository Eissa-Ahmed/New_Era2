namespace New_Era.Infrastructure.Configration
{
    public class InstractorSubjectsConfig : IEntityTypeConfiguration<InstractorSubject>
    {
        public InstractorSubjectsConfig(EntityTypeBuilder<InstractorSubject> builder)
        {
            Configure(builder);
        }
        public void Configure(EntityTypeBuilder<InstractorSubject> builder)
        {
            //Type
            builder.ToTable(TablesNames.InstractorSubjects);
            builder.HasKey(k => new { k.SubjectId, k.InstractorId });

            //Property
        }
    }
}
