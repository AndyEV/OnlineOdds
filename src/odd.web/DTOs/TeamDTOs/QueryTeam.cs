

using System;

namespace odd.web.DTOs.TeamDTOs
{
    public class QueryTeam
    {
        public Guid Id { get; set; }

        public string HomeTeam { get; set; }

        public string AwayTeam { get; set; }
    }
}
