using System.Linq;
using Domain;
using Domain.ValueTypes.Ids;
using Microsoft.AspNetCore.Mvc;
using RestAdapter.DomainHtos;
using SqliteAdapter.Model;

namespace RestAdapter.Controllers
{
    [Route("mr-x")]
    public class MrXController : Controller
    {
        private readonly IMrXRepository _mrXRepository;

        public MrXController(IMrXRepository mrXRepository)
        {
            _mrXRepository = mrXRepository;
        }

        [HttpGet("game-session/{gameSessionId}/mr-x")]
        public MrXHto GetMrX(string gameSessionId)
        {
            var mrX = _mrXRepository.GetMrX(new GameSessionId(gameSessionId));
            return new MrXHto(mrX);
        }

        [HttpPost("game-session/{gameSessionId}/mr-x")]
        public MrXHto PostMrX(string gameSessionId, [FromBody] MrXHtoPost mrXPost)
        {
            var mrxPost = new MrXHto(mrXPost.Name);
            var mrX = _mrXRepository.AddMrX(mrXPost);
            return new MrXHto(mrX);
        }
    }

    public interface IMrXRepository
    {
        MrX GetMrX(GameSessionId gameSessionId);
        MrX AddMrX(MrXHtoPost mrXPost);
    }

    internal class MrXRepository : IMrXRepository
    {
        private IMrxMapper _mrxMapper;

        public MrX GetMrX(GameSessionId gameSessionId)
        {
            using (var db = new RnvScotlandYardContext())
            {
                var mrxDbs = db.MrXs.FirstOrDefault(mrX => mrX.GameSessionDbId == gameSessionId.Id);
                var mrXFound = _mrxMapper.MapToMrx(mrxDbs);
                return mrXFound;
            }
        }

        public MrX AddMrX(MrXHtoPost mrXPost)
        {
            throw new System.NotImplementedException();
        }
    }

    internal interface IMrxMapper
    {
        MrX MapToMrx(MrxDb mrxDbs);
    }

    class MrxMapper : IMrxMapper
    {
        public MrX MapToMrx(MrxDb mrxDbs)
        {
            var mrX = new MrX("");
            return mrX;
        }
    }

    public class MrXHtoPost
    {
        public string Name { get; set; }
    }
}