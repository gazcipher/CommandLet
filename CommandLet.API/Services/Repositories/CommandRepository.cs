using System.Collections.Generic;
using System.Threading.Tasks;
using CommandLet.API.Services.Interfaces;
using CommandLet.Models;

namespace CommandLet.API.Services.Repositories
{
    public class CommandRepository : ICommandRepository
    {
        public CommandRepository()
        {


        }

        public async Task<Command> GetCommandAsync(int id)
        {
            return new Command{Id=0, HowTo="Hello", CmdLet="dotnet run", Platform="Windows/Linux"};
        }

        public async Task<IEnumerable<Command>> GetCommandsAsync()
        {
            var cmds = new List<Command>
            {
                new Command{Id=0, HowTo="Bash", CmdLet="bash -c", Platform="Linux"},
                new Command{Id=1, HowTo="Brew", CmdLet="brew install", Platform="Mac OS"},
                new Command{Id=2, HowTo="Choco", CmdLet="choco install", Platform="Windows"}
            };

            return cmds;
        }

        public Task<bool> SaveAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}