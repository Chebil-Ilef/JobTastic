namespace JobTastic.Helpers
{
    /// <summary>
    /// Contains role names.
    /// </summary>
    public static class RoleHelper
    {
        public const string Admin = "Admin";
        public const string Recruiter = "Recruiter";
        public const string User = "User";

        public static string Normalize(string roleName)
        {
            return roleName.ToUpper();
        }
    }
}
