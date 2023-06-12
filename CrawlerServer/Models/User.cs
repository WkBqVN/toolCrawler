namespace CrawlerServer.Models
{
    public class User
    {
        private string userName
        {
            get { return userName; }
            set { userName = value; }
        }
        private string password
        {
            get
            { return password; }
            set { password = value; }
        }
        private string userEmail
        {
            get
            {
                return userEmail;
            }
            set { userEmail = value; }
        }

        private User(string name, string pw, string email)
        {
            userName = name;
            password = pw;
            userEmail = email;
        }
        public User getUserByUserEmail(string userEmail) 
        {
            User user = new User("vovankhoa", "1234566", "xxx@gmail.com");

            return user;
        }
    }
}
