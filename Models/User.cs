using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using SystemKnowledgeMVC.Models;

namespace SystemKnowledgeMVC.Models
{
    public class User
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        [Display(Name = "Birth date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Birthdate { get; set; }
        public string Mobilephone { get; set; }
       // public bool isAdmin { get; set; }

        public virtual ICollection<AreaOfKnowledge> AreasOfKnowledge { get; set; }

    }

    public class UserDBContext : DbContext
    {
        public UserDBContext() : base("DefaultConnection") { }
        public DbSet<User> Users { get; set; }
    }
}