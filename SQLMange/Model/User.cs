using System.ComponentModel.DataAnnotations;

namespace SQLMange.Model
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Adderss { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
