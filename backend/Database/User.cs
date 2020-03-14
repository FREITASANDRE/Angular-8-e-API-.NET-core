using System;

namespace App_Api.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public decimal Password { get; set; }
        public DateTime Created
        {
            get
            {
                return this.Created;
            }
            set
            {
                value = DateTime.Now;
            }
        }
    }
}
