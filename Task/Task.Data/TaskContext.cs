using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Task.Core;
using Task.Core.Domain;

namespace Task.Data
{
    public partial class TaskContext : DbContext, IDesignTimeDbContextFactory<TaskContext>
    {
        #region ctor
        public TaskContext(DbContextOptions<TaskContext> options) : base(options)
        {
        }
        public TaskContext()
        {

        }
        #endregion

        public DbSet<Product> Products { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<ProductPicture> Product_Picture_Mapping { get; set; }
        public DbSet<PictureBinary> PictureBinary { get; set; }

        public TaskContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(@"appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<TaskContext>();

           //var connectionString = configuration.GetSection("DefaultConnection").Value; //configuration.GetConnectionString("DataConnectionString");

            builder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            return new TaskContext(builder.Options);
        }


        //public virtual new DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        //{
        //    return base.Set<TEntity>();
        //}

    }
}
