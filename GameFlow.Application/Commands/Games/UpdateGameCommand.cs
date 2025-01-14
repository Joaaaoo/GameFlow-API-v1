using MediatR;
using System;
using System.Collections.Generic;

namespace GameFlow.Application.Commands.Games
{
    public class UpdateGameCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Edition { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public bool IsAvailableForRent { get; set; }
        public bool IsAvailableForSale { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string ReleaseDate { get; set; }
        public string MinAge { get; set; }
        public string Language { get; set; }
        public string GameTime { get; set; }
        public string NumberOfPlayers { get; set; }
        public string Category { get; set; }
        public string AditionalInformation { get; set; }
        public List<byte[]> Photos { get; set; } // Adiciona suporte para fotos
    }
}
