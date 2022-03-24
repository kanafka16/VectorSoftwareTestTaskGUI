namespace VectorSoftwareTestTaskGUI.Data
{
    public class User
    {
        public string FullName { get; set; }
        public string Email { get; set; }

        public static UserBuilder CreateBuilder()
        {
            return new UserBuilder();
        }
    }
}
