using System.Runtime.Serialization;

namespace Heisenberg.Models
{
    [DataContract]
    public class TeamMember
    {
        [DataMember(Name = "username")]
        public string Username { get; set; }
        
        [DataMember(Name = "name")]
        public string Name { get; set; }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Username != null ? Username.GetHashCode() : 0)*397) ^ (Name != null ? Name.GetHashCode() : 0);
            }
        }
    }
}