using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFlow.Application.Commands.Games
{
    public class DeleteGameCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
