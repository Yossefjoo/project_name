using System.ComponentModel.DataAnnotations;

namespace game_store.Dtos;

public record class createGameDto(
    [Required][StringLength(50)]string Name,
    [Required][StringLength(20)]string Genre,
    [Range(1,100)]decimal Price,
    DateOnly ReleaseDate
);



