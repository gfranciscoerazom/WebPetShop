namespace WebPetShop.Models.ViewModel
{
    public class LoginSignUpViewModel
    {
        public int ClienteId
        {
            get;
            set;
        }

        public string Username
        {
            get;
            set;
        }

        public string Email
        {
            get;
            set;
        }

        public string Mobile
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }

        public bool IsAdmin
        {
            get;
            set;
        }
    }
}