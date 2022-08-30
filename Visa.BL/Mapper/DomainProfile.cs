using AutoMapper;

using Visa.BL.Models;
using Visa.DAL.Entity;

namespace Visa.BL.Mapper
{
    public class DomainProfile : Profile
    {

        public DomainProfile()
        {
            CreateMap<HeaderVM, Header>().ReverseMap();

            CreateMap<ServicesVM, Services>().ReverseMap();

            CreateMap<AboutVM, About>().ReverseMap();

            CreateMap<ContactVM, Contact>().ReverseMap();

            CreateMap<StepsVM, Steps>().ReverseMap();

            CreateMap<HomeTestimonialsVM, HomeTestimonials>().ReverseMap();

            CreateMap<ContactBannerVM, ContactBanner>().ReverseMap();

            CreateMap<LandingVm, Landing>().ReverseMap();

            CreateMap<FaQuestionVm, FaQuestion>().ReverseMap();

            CreateMap<StampedVisaVM, StampedVisa>().ReverseMap();

            CreateMap<LookUpValueVM, LookUpValue>().ReverseMap();
            CreateMap<TestimonialsVM, Testimonials>().ReverseMap();
            CreateMap<AuthorVM, Author>().ReverseMap();
            CreateMap<CategoryVM, Category>().ReverseMap();
            CreateMap<BlogsVM, Blogs>().ReverseMap();
        }

    }
}
