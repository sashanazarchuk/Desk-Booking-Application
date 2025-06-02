using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServer.Domain.Entities
{
    public class WorkspacePhoto
    {
        public int Id { get; set; }
        public string Url { get; set; }  

        public int WorkspaceId { get; set; }
        public Workspace Workspace { get; set; } 
    }
}
