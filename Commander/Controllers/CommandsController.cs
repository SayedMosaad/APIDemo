using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Commander.Data;
using Commander.Models;
using AutoMapper;
using Commander.DTOs;
using Microsoft.AspNetCore.JsonPatch;

namespace Commander.Controllers
{
    //api/Commands
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo repo;
        private readonly IMapper mapper;

        public CommandsController(ICommanderRepo repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CommandRead>> GetAllCommands()
        {
            var commands = repo.GetAllCommands();
            //return Ok(commands);
            return Ok(mapper.Map<IEnumerable<CommandRead>>(commands));
        }

        
        [HttpGet("{id}", Name = "GetCommandById")]
        public ActionResult<CommandRead> GetCommand(int id)
        {
            var commandItem = repo.GetCpmmandById(id);
            if (commandItem != null)
            {
                return Ok(mapper.Map<CommandRead>(commandItem));
            }
            else
            {
                return NotFound();
            }

        }

        //Post api/commands
        [HttpPost]
        public ActionResult<CommandRead> CreateCommand(CommandWriteDTO cmd)
        {
            var commandModel = mapper.Map<Command>(cmd);
            repo.CreateCommand(commandModel);
            var CommandReadDTO = mapper.Map<CommandRead>(commandModel);
            return CreatedAtRoute("GetCommandById", new { CommandReadDTO.ID }, CommandReadDTO);
            //return Ok(mapper.Map<CommandRead>(commandModel));
        }

        [HttpPut("id")]
        public ActionResult UpdateCommand(int id, CommandUpdateDTO cmd)
        {
            var commandModel = repo.GetCpmmandById(id);
            if (commandModel == null)
            {
                return NotFound();
            }
            mapper.Map(cmd, commandModel);

            repo.UpdateCommand(commandModel);
            repo.SaveChanges();
            return NoContent();
        }


        // Patch api/commands/{id}
        [HttpPatch("id")]
        public ActionResult PartialUpdateCommand(int id, JsonPatchDocument<CommandUpdateDTO> patchDocument)
        {
            var CommandModel = repo.GetCpmmandById(id);
            if(CommandModel==null)
            {
                return NotFound();
            }
            var commandPatch = mapper.Map<CommandUpdateDTO>(CommandModel);
            patchDocument.ApplyTo(commandPatch, ModelState);
            if(!TryValidateModel(commandPatch))
            {
                return ValidationProblem(ModelState);
            }

            mapper.Map(commandPatch, CommandModel);
            repo.UpdateCommand(CommandModel);
            repo.SaveChanges();
            return NoContent();
        }

        //Delete api/command/{id}
        [HttpDelete("id")]
        public ActionResult DleteCommand(int id)
        {
            var commandModel = repo.GetCpmmandById(id);
            if(commandModel==null)
            {
                return NotFound();
            }
            repo.DeleteCommmand(commandModel);
            repo.SaveChanges();
            return NoContent();

        }

    }
}
