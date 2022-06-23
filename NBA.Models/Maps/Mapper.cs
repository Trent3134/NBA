using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

public class Mapper : Profile
    {
        public Mapper()
        {
        CreateMap<PlayersEntity, PlayerDetail>().ReverseMap();
        CreateMap<PlayersEntity, PlayerListItem>().ReverseMap();
        CreateMap<PlayerCreate, PlayersEntity>().ReverseMap();
        CreateMap<PlayerUpdate, PlayersEntity>().ReverseMap();
            
        }
    }
