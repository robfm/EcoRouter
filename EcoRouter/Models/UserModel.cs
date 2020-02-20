using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoRouter.Models
{
	public class UserModel
    {
		[Key]
		public int UserId { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime ModifiedAt { get; set; }
	}
}
