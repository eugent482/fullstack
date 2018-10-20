namespace BackEnd.Entity
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Model : DbContext
    {       
        public Model()
            : base("name=Model")
        {
        }
        public virtual DbSet<Product> Products { get; set; }
    }

  
}