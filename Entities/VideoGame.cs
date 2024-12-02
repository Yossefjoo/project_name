using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace game_store.Entities;

public class VideoGame
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Ensures auto-increment behavior
    public int Id { get; set; }
    public required string Name { get; set; }
    public decimal Price { get; set; }
}