using System;
using game_store.Entities;
using game_store.Interface;
using Microsoft.AspNetCore.Mvc;

namespace game_store.EndPoint;

[ApiController]
[Route("api/games")]
public class GameController : ControllerBase
{

    private readonly IGameRepo _GameRepo;

    public GameController(IGameRepo GameRepo)
    {
        _GameRepo = GameRepo;
    }

    [HttpPost("AddGames")]
    public async Task<IActionResult> AddGame(VideoGame vgame)
    {

        await _GameRepo.AddGame(vgame);
        return Ok(vgame);
    }

    [HttpPut
    ("UpdateGames")]
    public async Task<IActionResult> UpdateGame(VideoGame vgame){


        await _GameRepo.UpdateGame(vgame);
        return Ok(vgame);
    }

    [HttpDelete("DeleteGames/{id}")]
public async Task<IActionResult> DeleteGame(int id)
{
    var result = await _GameRepo.DeleteGame(id);

    if (!result)
    {
        return NotFound(new { message = "Game not found with the provided ID." });
    }

    return Ok(new { message = "Game deleted successfully." });
}

}
