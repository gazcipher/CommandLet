using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommandLet.API.Data;
using CommandLet.API.Services.Interfaces;
using CommandLet.Models;
using Microsoft.EntityFrameworkCore;

namespace CommandLet.API.Services.Repositories
{
    public class CommandRepository : ICommandRepository, IDisposable
    {
        private CommandLetContext _context;


        public CommandRepository(CommandLetContext context)
        {

            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddComand(Command cmd)
        {
            if(cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            await _context.AddAsync(cmd);
        }

        public async Task<bool> CommandLetExists(int id)
        {
            return await _context.Commands.AnyAsync(c => c.Id == id);
        }

        public async Task DeleteCommandLet(Command cmd)
        {
            if(cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            _context.Commands.Remove(cmd);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        //Dispose object - Garbagge collection
        protected virtual void Dispose(bool disposing)
        {
            if(disposing)
            {
                if(_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }

        public async Task<Command> GetCommandAsync(int id)
        {
            return await _context.Commands.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Command>> GetCommandsAsync()
        {
            return await _context.Commands.OrderBy(c => c.Id).ToListAsync();
        }

        public async Task UpdateCommadLet(Command cmd)
        {
            _context.Entry(cmd).State = EntityState.Modified;
            await SaveCommandAsync();
        }

        public async Task<bool> SaveCommandAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }
    }
}