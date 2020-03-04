namespace InfinitusApp.Core.Data.DataModels
{
    public class Person : Naylah.Core.Entities.EntityBase
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string ImageUri { get; set; } = "";
    }
}