using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using Fifa.Core.Models;
using Fifa.Core.Repositories.Filters;

namespace Fifa.Core.Repositories.Impl
{
    public class GameRepository : RepositoryBase, IGameRepository
    {
        public void DeleteGame(int id)
        {
            var game = GetGame(id);
            using (var context = new MainContext())
            {
                context.Entry(game).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void SaveGame(Game game)
        {
            using (var context = new MainContext())
            {
                UpdateEntity(context, game);
                context.SaveChanges();
            }
        }

        public Game GetGame(int id)
        {
            using (var context = new MainContext())
            {
                return context.Games.Find(id);
            }
        }

        public IEnumerable<Game> GetAllGames(GameFilter filter)
        {
            using (var context = new MainContext())
            {
                return context.Games.
                    Include(x=>x.PlayerA).
                    Include(x=>x.PlayerB).
                    Include(x=>x.TeamA).
                    Include(x=>x.TeamB).
                    WhereIf(filter.UserId > 0, x => x.PlayerAId == filter.UserId || x.PlayerBId == filter.UserId).
                    OrderByDescending(x=>x.Date).
                    ToList();
            }
        }
    }
}