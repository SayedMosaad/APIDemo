using Commander.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commander.Data
{
    public interface ICommanderRepo
    {
        IEnumerable<Command> GetAllCommands();
        Command GetCpmmandById(int id);
        void CreateCommand(Command cmd);

        void UpdateCommand(Command cmd);
        void DeleteCommmand(Command cmd);
        bool SaveChanges();

    }
}
