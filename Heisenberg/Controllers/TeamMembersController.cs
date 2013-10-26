using System.Collections.Generic;
using System.Web.Http;
using Heisenberg.Domain;

namespace Heisenberg.Controllers
{
    public class TeamMembersController : ApiController
    {
        public IEnumerable<TeamMember> GetAll()
        {
            ISet<TeamMember> teamMembers = new HashSet<TeamMember>();
            teamMembers.Add(new TeamMember {Name = "Rick", Username = "MrCochese"});
            teamMembers.Add(new TeamMember {Name = "Andy", Username = "GraanJonlo"});
            teamMembers.Add(new TeamMember {Name = "Si", Username = "sichiu"});
            teamMembers.Add(new TeamMember {Name = "Laurent", Username = "lhbt"});
            return teamMembers;
        }
    }
}
