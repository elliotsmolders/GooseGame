using AutoMapper;
using GooseGame.Business;
using GooseGame.DAL;
using GooseGame.DAL.Entities;
using GooseGame.DAL.Repositories;

GameEngine engine = new GameEngine();
var repo = new PlayerRepository();
IMapper _playerMap;
var cfg = new MapperConfiguration
                (
                    cfg =>
                    {
                        cfg.CreateMap<Player, PlayerEntity>()
                                .ForMember(x => x.NumberOfThrows, y => y.MapFrom(z => z.NumberOfRolls));
                    });
_playerMap = new Mapper(cfg);

PlayerEntity? entity = await repo.GetAsync(1);

Console.WriteLine(entity.Name);