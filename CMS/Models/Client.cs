using CMS.Interfaces;

namespace CMS.Models
{
    internal class Client : IClient
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get ; set ; } = null!;
        public string Email { get ; set ; } = null!;
        public string Phone { get ; set ; } = null!;
    }
}
