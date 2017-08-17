namespace AmazonBot
{
    public sealed class Account
    {
        #region PROPERTIES
        public string Login
        { get; set; }
        public string Password
        { get; set; }
        #endregion

        #region CONSTRUCTORS
        public Account()
        { }
        public Account(string login, string password)
        {
            Login = login;
            Password = password;
        }
        #endregion
    }
}
