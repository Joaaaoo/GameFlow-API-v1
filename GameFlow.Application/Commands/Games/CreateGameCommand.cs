using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GameFlow.Application.Commands
{
    public class CreateGameCommand : IRequest<bool>
    {
        [Required]
        public string Name { get; set; }
        public string Edition { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public bool IsAvailableForRent { get; set; }
        [Required]
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
        [Required]
        public List<string> Photos { get; set; } // Fotos como strings base64

        public List<byte[]> GetPhotosAsByteArray()
        {
            return Photos?.ConvertAll(photo => Convert.FromBase64String(photo));
        }
    }
}
