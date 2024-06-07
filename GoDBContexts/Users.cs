using System.ComponentModel.DataAnnotations;

namespace GoLive.GoDBContexts
{
    public class Users
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Firstname { get; set; } = string.Empty;

        [Required] 
        public string Lastname { get;set; } = string.Empty;

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; } = string.Empty;

        [Required]
        public string Details { get; set; } = string.Empty;

        public string Hostname { get; set;} = string.Empty;

    }
}
