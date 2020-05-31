using Microsoft.EntityFrameworkCore;

namespace CommandLet.API.Data
{
    public class CommandLetContext : DbContext
    {

        public CommandLetContext(DbContextOptions<CommandLetContext> opt) : base (opt)
        {
            
        }

        public DbSet<CommandLet.Models.Command> Commands { get; set; }

    }
}