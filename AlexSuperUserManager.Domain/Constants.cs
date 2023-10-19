namespace AlexSuperUserManager.Domain;

public static class Constants
{
    public static class User
    {
        public const string FullNamePattern = @"^[A-Z]([a-z]{1,9})\s[A-Z]([a-z]{1,13})$";
        public const string NickPattern = @"^[a-zA-Z0-9]{5,20}$";
    }

    public static class ErrorMessages
    {
        public const string UserExist = "User with this nick already exists!";
        public const string InvalidUser = "The information about the user is not filled correctly!";
        public const string InvalidNickName = "Entered nick is not correct (only letters and numbers)!";
        public const string InvalidFullName = "You entered incorrect firstname or lastname!";
        public const string UserNotFound = "User is not found";
    }
}