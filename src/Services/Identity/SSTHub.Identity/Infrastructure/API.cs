namespace SSTHub.Identity.Infrastructure
{
    public static class API
    {
        public static class Hub
        {
            public static string CreateHub(string baseUri) => $"{baseUri}";
        }

        public static class Employee
        {
            public static string CreateEmployee(string baseUri) => $"{baseUri}";
        }
    }
}
