using comperhensive_todo_list_api.Models;
using comperhensive_todo_list_api.Repository.DatabaseContext.Interface;
using Microsoft.EntityFrameworkCore;

namespace comperhensive_todo_list_api.Repository.DatabaseContext.Obejct
{
    public class MainDatabaseContext : DbContext, IMainDatabaseContext
    {
        private readonly IConfiguration _configuration;

        public MainDatabaseContext(IConfiguration configuration)
        {
            this._configuration = configuration;
        }


        public DbSet<Todo> todos { get; set; }
        public DbSet<TodoStep> steps { get; set; }
        public DbSet<User> users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(t => t.UserName).IsUnique();
            modelBuilder.Entity<User>().HasIndex(t => t.Password).IsUnique();
            modelBuilder.Entity<User>().HasIndex(t => t.Email).IsUnique();

            modelBuilder.Entity<User>().HasMany(i => i.Todos)
                .WithOne(i => i.User).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Todo>().HasMany(i => i.Steps)
                .WithOne(i => i.Todo).OnDelete(DeleteBehavior.Cascade);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string ConnectionString = _configuration["ConnectionStrings:DefaultConnection"];
            if (ConnectionString == null) {
                throw new ArgumentNullException("Connection String Should Not Be Null");
            }
            optionsBuilder.UseMySql(ConnectionString , ServerVersion.AutoDetect(ConnectionString));
        }

        public async  Task ApplyChangesAsync()
        {
           await this.SaveChangesAsync();
        }
    }
}
