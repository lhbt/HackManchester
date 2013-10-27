using System.Collections.Generic;
using System.Web.Http;
using Heisenberg.Domain;
using Heisenberg.Domain.Interfaces;

namespace Heisenberg.Controllers
{
    public class TeamMembersController : ApiController
    {
        private readonly ISourceControlParser _parser;

        public TeamMembersController(ISourceControlParser parser)
        {
            _parser = parser;
        }

        public IEnumerable<TeamMember> GetAll()
        {
            var members = _parser.GetContributingMembers();

            ISet<TeamMember> teamMembers = new HashSet<TeamMember>();
            teamMembers.Add(new TeamMember {Name = "Rick", Username = "MrCochese"});
            teamMembers.Add(new TeamMember {Name = "Andy", Username = "GraanJonlo"});
            teamMembers.Add(new TeamMember {Name = "Si", Username = "sichiu"});
            teamMembers.Add(new TeamMember {Name = "Laurent", Username = "lhbt"});
            return teamMembers;
        }
    }
}
