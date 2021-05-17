using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commander.Models;
using Commander.DTOs;

namespace Commander.Profiles
{
    public class CommandProfile :Profile
    {
        public CommandProfile()
        {
            CreateMap<Command, CommandRead>();
            CreateMap<CommandWriteDTO, Command>();
            CreateMap<CommandUpdateDTO, Command>();
            CreateMap<Command, CommandUpdateDTO>();
        }

    }
}
