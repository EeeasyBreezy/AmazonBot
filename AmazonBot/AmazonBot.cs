namespace AmazonBot
{
    public sealed class AmazonBot : BaseBot
    {
        #region CONSTRUCTORS
        public AmazonBot()
        {
        }
        #endregion

        #region PUBLIC METHODS
        public void Login()
        {
            InitRequest("https://www.amazon.com/", "GET");
            GetResponse();

        }
        #endregion
    }
}
