using System.Collections.Generic;
using System.Threading.Tasks;
using CommandLet.Models;

namespace CommandLet.API.Services.Interfaces
{
    public interface ICommandRepository
    {
        Task<IEnumerable<Command>> GetCommandsAsync();
        Task<Command> GetCommandAsync(int id);
        Task<bool> CommandLetExists(int id);
        Task UpdateCommadLet(Command cmd);
        Task DeleteCommandLet(Command cmd);
        Task<bool> SaveAsync();


    }
}