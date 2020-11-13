using AutoMapper;
using Motors.Domain.Entidades;
using Motors.ViewModel;

namespace Motors.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Entities to ViewModels
            CreateMap<TbAnuncioWebmotors, AnuncioWebmotorsViewModel>();

            //ViewModels To Entities
            CreateMap<AnuncioWebmotorsViewModel, TbAnuncioWebmotors>();
        }
    }
}
