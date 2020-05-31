using System.Collections;
using CommandLet.API.Services.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CommandLet.Models;

namespace CommandLet.API.Controllers
{
    [ApiController]
    [Route("api/v1/commands")]
    public class CommandController : ControllerBase
    {

        private readonly ICommandRepository _commandRepository;

        public CommandController(ICommandRepository commandRepository)
        {
            _commandRepository = commandRepository;
        }

        //api/vi/command //gets all commands
        [HttpGet]
        public async Task<ActionResult> GetAllCommands()
        {
            var cmds = _commandRepository.GetCommandsAsync();
            return Ok(cmds);
        }

        //api/v1/command/{id} //id can be any number 1, 2 etc
        [HttpGet("{id}")]
        public ActionResult GetCommand(int id)
        {
            var cmd = _commandRepository.GetCommandAsync(id);
            return Ok(cmd);

        }
    }
}