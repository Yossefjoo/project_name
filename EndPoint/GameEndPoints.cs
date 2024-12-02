using System;
using System.Runtime.InteropServices;
using game_store.Dtos;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic;

namespace game_store.EndPoint;

public static class GameEndPoint
{


const string GetGameEndpointName ="GetGame";
private static readonly List<GameDto> games =[
    new(
        1,
        "EA2024",
        "sports",
        69,
        new DateOnly(2024,9,15)
    ),
    new(
        2,
        "takken6",
        "fighting",
        45,
        new DateOnly(2022,5,20)
    )


];

    public static RouteGroupBuilder MapGamesEndPoints(this WebApplication app)
    {
        var group = app.MapGroup("games").WithParameterValidation();
        group.MapGet("/",()=> games);

group.MapGet("/{id}",(int id)=> 
{
    GameDto? game= games.Find(game=>game.Id == id);

    return game is null ? Results.NotFound() : Results.Ok(game) ;
})
.WithName(GetGameEndpointName);

group.MapPost("/",(createGameDto newGame)=>{

    GameDto game = new(
        games.Count +1,
        newGame.Name,
        newGame.Genre,
        newGame.Price,
        newGame.ReleaseDate);
    games.Add(game);
    return Results.CreatedAtRoute(GetGameEndpointName,new {id = game.Id },game);    
});

group.MapPut("/{id}",(int id,UpdateGameDto updatedGame) => {
    var index = games.FindIndex(game => game.Id == id);
    if(index == -1)
    {
        return Results.NotFound();
    }

    games[index] = new GameDto(
        id,
        updatedGame.Name,
        updatedGame.Genre,
        updatedGame.Price,
        updatedGame.ReleaseDate
    );
    return Results.NoContent();
});
group.MapDelete("/{id}",(int id)=>{
    games.RemoveAll(game=> game.Id ==id);
    return Results.NoContent();
});
    return group;
    }
}
