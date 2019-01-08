using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SystemKnowledgeMVC.Models
{
    public class AreaOfKnowledge
    {
        public int AreaOfKnowledgeID { get; set; }
        public string AreaOfKnowledgeName { get; set; }
        public string Description { get; set; }

        public int? UserId { get; set; }

        public virtual User User { get; set; }
    }

    public class AreaOfKnowledgeDBContext : DbContext
    {
        public AreaOfKnowledgeDBContext() : base("DefaultConnection") { }
        public DbSet<AreaOfKnowledge> AreasOfKnowledge { get; set; }

        public DbSet<User> Users { get; set; }
    }

}