using AutoMapper;
using JobTastic.Models;
using JobTastic.Models.JobCategoryViewModels;
using JobTastic.Models.JobOfferViewModels;
using JobTastic.Models.JobTypeViewModels;

namespace BulletinBoard.Infrastructure.AutoMapper
{
    /// <summary>
    /// Default model to view-model automapper mapping profile.
    /// </summary>
    public class DefaultProfile : Profile
    {
        public DefaultProfile()
        {
            #region JobCategory

            CreateMap<JobCategory, JobCategoryViewModel>();
            CreateMap<JobCategory, CreateJobCategoryViewModel>();
            CreateMap<JobCategory, DeleteJobCategoryViewModel>();
            CreateMap<JobCategory, DetailsJobCategoryViewModel>();
            CreateMap<JobCategory, EditJobCategoryViewModel>();

            CreateMap<CreateJobCategoryViewModel, JobCategory>();
            CreateMap<DeleteJobCategoryViewModel, JobCategory>();
            CreateMap<DetailsJobCategoryViewModel, JobCategory>();
            CreateMap<EditJobCategoryViewModel, JobCategory>();

            #endregion

            #region JobType
            
            CreateMap<JobType, JobTypeViewModel>();
            CreateMap<JobType, CreateJobTypeViewModel>();
            CreateMap<JobType, DeleteJobTypeViewModel>();
            CreateMap<JobType, DetailsJobTypeViewModel>();
            CreateMap<JobType, EditJobTypeViewModel>();

            CreateMap<JobTypeViewModel, JobType>();
            CreateMap<CreateJobTypeViewModel, JobType>();
            CreateMap<DeleteJobTypeViewModel, JobType>();
            CreateMap<DetailsJobTypeViewModel, JobType>();
            CreateMap<EditJobTypeViewModel, JobType>();
            CreateMap<JobOffer, JobOffer>();
            #endregion

            #region JobOffer

            CreateMap<JobOffer, JobOfferViewModel>()
                .ForMember(dest => dest.Author,
                    opts => opts.MapFrom(src => src.author));
            CreateMap<JobOffer, PopularJobOfferViewModel>();
            CreateMap<JobOffer, CreateJobOfferViewModel>()
                .ForMember(dest => dest.JobCategoryId,
                    opts => opts.MapFrom(src => src.jobcategory.JobCategoryId))
                .ForMember(dest => dest.JobTypeId,
                    opts => opts.MapFrom(src => src.JobType.JobTypeId))
                .ForMember(dest => dest.AuthorId,
                    opts => opts.MapFrom(src => src.author.Id));
            CreateMap<JobOffer, DeleteJobOfferViewModel>();
            CreateMap<JobOffer, DetailsJobOfferViewModel>();
            CreateMap<JobOffer, EditJobOfferViewModel>()
                .ForMember(dest => dest.JobCategoryId,
                    opts => opts.MapFrom(src => src.jobcategory.JobCategoryId))
                .ForMember(dest => dest.JobTypeId,
                    opts => opts.MapFrom(src => src.JobType.JobTypeId));

            CreateMap<CreateJobOfferViewModel, JobOffer>();
            CreateMap<DeleteJobOfferViewModel, JobOffer>();
            CreateMap<DetailsJobOfferViewModel, JobOffer>();
            CreateMap<EditJobOfferViewModel, JobOffer>();

            #endregion
        }
    }
}
