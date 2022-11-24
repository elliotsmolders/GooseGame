using AutoMapper;
using GooseGame.Business;
using GooseGame.DAL;
using GooseGame.DAL.Entities;
using GooseGame.DAL.Repositories;

GameEngine engine = new GameEngine();

await engine.AddPlayerAsync("Koala", 3);
var player = await engine.GetPlayerAsync(13);

Console.WriteLine(player.Name + " " + player.PlayerIcon);