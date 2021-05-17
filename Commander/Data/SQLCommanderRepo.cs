using Commander.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commander.Data;

namespace Commander.Data
{
    public class SQLCommanderRepo : ICommanderRepo
    {
        private readonly CommanderContext context;

        public SQLCommanderRepo(CommanderContext context)
        {
            this.context = context;
        }

        public void CreateCommand(Command cmd)
        {
            if(cmd==null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            context.Commands.Add(cmd);
            SaveChanges();

        }

        public void DeleteCommmand(Command cmd)
        {
            if(cmd==null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            context.Commands.Remove(cmd);
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return context.Commands.ToList();
        }

        public Command GetCpmmandById(int id)
        {
            return context.Commands.FirstOrDefault(x => x.ID == id);
        }

        public bool SaveChanges()
        {
            return (context.SaveChanges() >= 0);
        }

        public void UpdateCommand(Command cmd)
        {
            context.Commands.Update(cmd);

        }
    }
}
