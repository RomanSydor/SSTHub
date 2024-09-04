namespace SSTHub.Identity.Infrastructure
{
    public static class API
    {
        public static class Organization
        {
            public static string CreateOrganization(string baseUri) => $"{baseUri}";
        }

        public static class Employee
        {
            public static string CreateEmployee(string baseUri) => $"{baseUri}";
        }
    }
}
