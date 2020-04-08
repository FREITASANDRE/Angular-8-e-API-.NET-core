namespace App_Api.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public int UserId { get; set; }
    }
}
