using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFlow.Domain.Entities
{
    public class GamePhoto
    {
        public Guid Id { get; set; }
        public byte[] PhotoData { get; set; }
        public Guid GameId { get; set; }
        public Game Game { get; set; }
    }
}
