namespace CRUD_App.models
{
    public class EmployeeData
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public long NationalId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int age { get; set; }
        public string Account { get; set; }
        public string LineOfBuisness { get; set; }
        public string Language { get; set; }
        public string LanguageLevel { get; set; }
    }
}
