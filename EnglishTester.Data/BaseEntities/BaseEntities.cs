using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTester.Data.BaseEntities
{
    public class BaseEntities : DbContext
    {
        public BaseEntities() : base("BaseEntities")
        {
            this.Configuration.LazyLoadingEnabled = true;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        #region DbSet
        public virtual DbSet<Questions> Questions { get; set; }
        public virtual DbSet<Answers> Answers { get; set; }
        #endregion
    }
}
