using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<TeamEntity, TeamDetail>().ReverseMap();
            CreateMap<TeamCreate, TeamEntity>().ReverseMap();
            CreateMap<TeamEntity, TeamListItem>().ReverseMap();
            CreateMap<TeamUpdate, TeamEntity>().ReverseMap();
            
            CreateMap<PlayersEntity, PlayerDetail>().ReverseMap();
            CreateMap<PlayersEntity, PlayerListItem>().ReverseMap();
            CreateMap<PlayerCreate, PlayersEntity>().ReverseMap();
            CreateMap<PlayerUpdate, PlayersEntity>().ReverseMap();

            CreateMap<Game, GameDetail>().ReverseMap();
           
            
        }
    }
