namespace Escyug.Nosology.ViewModels
{
    public sealed class User
    {
        private string _userName;
        public string Name
        {
            get { return _userName; }
        }

        private string _userLevel;
        public string Level
        {
            get { return _userLevel; }
        }

        private string _userAvatarPath;
        public string AvatarPath
        {
            get { return _userAvatarPath; }
        }

        public User(string userName, string userLevel, string userAvatarPath)
        {
            _userName = userName;
            _userLevel = userLevel;
            _userAvatarPath = userAvatarPath;
        }
    }
}
