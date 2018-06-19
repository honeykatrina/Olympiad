using AutoMapper;
using DataLayer.Interfaces;
using DataLayer.Models;
using LogicLayer.Interfaces;
using LogicLayer.Models;
using System.Collections.Generic;

namespace LogicLayer.Services
{
    public class TeamService : IService<TeamDTO>
    {
         private IUnitOfWork _database { get; set; }

         public TeamService(IUnitOfWork uow)
        {
            _database = uow;
        }

        public void AddNewItem(TeamDTO item)
        {
            Team team = new Team
            {
                TeamID = item.TeamID,
                TeamName = item.TeamName
            };

            _database.Teams.Create(team);
            _database.Save();
        }

        public void UpdateItem(TeamDTO item)
        {
            Team team = new Team
            {
                TeamID = item.TeamID,
                TeamName = item.TeamName
            };

            _database.Teams.Update(team);
            _database.Save();
        }

        public void DeleteItem(int id)
        {
            Team teamToDelete = new Team() { TeamID = id };
            _database.Teams.Delete(teamToDelete.TeamID);
            _database.Save();
        }

        public TeamDTO GetItem(int? id)
        {
            Team team = _database.Teams.Get(id);
            return new TeamDTO
            {
                TeamID = team.TeamID,
                TeamName = team.TeamName
            };
        }

        public IEnumerable<TeamDTO> GetItems()
        {
            return Mapper.Map<IEnumerable<Team>, List<TeamDTO>>(_database.Teams.GetAll());
        }

        public void Dispose()
        {
            _database.Dispose();
        }
    }
}