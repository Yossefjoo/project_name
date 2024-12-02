using game_store.Entities;
using game_store.Data;
using game_store.EndPoint;
using Microsoft.AspNetCore.Mvc;
namespace game_store.Interface;


public interface IGameRepo{

    public Task<VideoGame> AddGame(VideoGame vgame);
    public Task<VideoGame> UpdateGame(VideoGame vgame);

    Task<bool> DeleteGame(int id);

}