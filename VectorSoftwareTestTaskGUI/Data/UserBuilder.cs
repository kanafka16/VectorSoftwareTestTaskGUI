namespace VectorSoftwareTestTaskGUI.Data
{
    public class UserBuilder
    {
        private User user;

        public UserBuilder()
        {
            user = new User();
        }

        public UserBuilder SetFullName(string fullName)
        {
            user.FullName = fullName;
            return this;
        }

        public UserBuilder SetEmail(string email)
        {
            user.Email = email;
            return this;
        }

        public User Build()
        {
            return user;
        }
    }
}
