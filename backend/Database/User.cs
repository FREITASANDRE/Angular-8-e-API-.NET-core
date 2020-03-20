using System;

namespace App_Api.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Status { get; set; }
        public string Password { get; set; }
        public DateTime Created
        {
            get; set;
        }
    }
}
