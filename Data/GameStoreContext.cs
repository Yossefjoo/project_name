using System;
using game_store.EndPoint;
using game_store.Entities;
using Microsoft.EntityFrameworkCore;

namespace game_store.Data;

public class GameStoreContext : DbContext
{
    public GameStoreContext(DbContextOptions<GameStoreContext> DbContextOptions) : base(DbContextOptions)
    {}
        public DbSet<Game> Games => Set<Game>();

        public DbSet<Genre> Genres => Set<Genre>();
        public DbSet<VideoGame> VideoGame => Set<VideoGame>();

    
    

    

    // DbSet properties here
}
//   public DbSet<Game> Games => Set<Game>();

//         public DbSet<Genre> Genres => Set<Genre>();
