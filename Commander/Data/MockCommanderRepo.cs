using Commander.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commander.Data;

namespace Commander.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        public void CreateCommand(Command cmd)
        {
            throw new NotImplementedException();
        }

        public void DeleteCommmand(Command cmd)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
        {
            var commands = new List<Command>
            {
                new Command{ ID=1,HowTo="Boill the Egg", Line="Boill Water",Platform="Kattle and Pan" },
                new Command{ ID=2,HowTo="Cut bread", Line="Get a knife",Platform="knife and chopping board" },
                new Command{ ID=3,HowTo="Make Tea", Line="place a teabag in a cup",Platform="Kattle" },
             };
            return commands;

            
        }

        public Command GetCpmmandById(int id)
        {
            return new Command { ID = 1, HowTo = "Boill the Egg", Line = "Boill Water", Platform = "Kattle and Pan" };
            
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateCommand(Command cmd)
        {
            throw new NotImplementedException();
        }
    }
}
