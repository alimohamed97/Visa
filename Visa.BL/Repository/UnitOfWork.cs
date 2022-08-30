
using Visa.BL.Interface;
using Visa.DAL.Database;
using Visa.DAL.Entity;

namespace Visa.BL.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ApplicationContext Context;

        public UnitOfWork(ApplicationContext Context)
        {
            this.Context = Context;
        }


        // Header
        private GenericRep<Header> headerRepository;
        public GenericRep<Header> HaderRepository
        {
            get
            {
                if (this.headerRepository == null)
                {
                    this.headerRepository = new GenericRep<Header>(Context);
                }
                return headerRepository;
            }
        }


        // Services
        private GenericRep<Services> servicesRepository;
        public GenericRep<Services> ServicesRepository
        {
            get
            {
                if (this.servicesRepository == null)
                {
                    this.servicesRepository = new GenericRep<Services>(Context);
                }
                return servicesRepository;
            }
        }


        // Header
        private GenericRep<About> aboutRepository;
        public GenericRep<About> AboutRepository
        {
            get
            {
                if (this.aboutRepository == null)
                {
                    this.aboutRepository = new GenericRep<About>(Context);
                }
                return aboutRepository;
            }
        }
        private GenericRep<HomeTestimonials> homeTestimonialsRepository;
        public GenericRep<HomeTestimonials> HomeTestimonialsRepository
        {
            get
            {
                if (this.homeTestimonialsRepository == null)
                {
                    this.homeTestimonialsRepository = new GenericRep<HomeTestimonials>(Context);
                }
                return homeTestimonialsRepository;
            }
        }
        private GenericRep<Testimonials> testimonialsRepository;
        public GenericRep<Testimonials> TestimonialsRepository
        {
            get
            {
                if (this.testimonialsRepository == null)
                {
                    this.testimonialsRepository = new GenericRep<Testimonials>(Context);
                }
                return testimonialsRepository;
            }
        }


        // Header
        private GenericRep<Contact> contactRepository;
        public GenericRep<Contact> ContactRepository
        {
            get
            {
                if (this.contactRepository == null)
                {
                    this.contactRepository = new GenericRep<Contact>(Context);
                }
                return contactRepository;
            }
        }
        private GenericRep<Steps> stepsRepository;
        public GenericRep<Steps> StepsRepository
        {
            get
            {
                if (this.stepsRepository == null)
                {
                    this.stepsRepository = new GenericRep<Steps>(Context);
                }
                return stepsRepository;
            }
        }
        private GenericRep<ContactBanner> contactBannerRepository;
        public GenericRep<ContactBanner> ContactBannerRepository
        {
            get
            {
                if (this.stepsRepository == null)
                {
                    this.contactBannerRepository = new GenericRep<ContactBanner>(Context);
                }
                return contactBannerRepository;
            }
        }


        // Header
        private GenericRep<Landing> landingRepository;
        public GenericRep<Landing> LandingRepository
        {
            get
            {
                if (this.landingRepository == null)
                {
                    this.landingRepository = new GenericRep<Landing>(Context);
                }
                return landingRepository;
            }
        }
        private GenericRep<FaQuestion> faQuestionRepository;
        public GenericRep<FaQuestion> FaQuestionRepository
        {
            get
            {
                if (this.faQuestionRepository == null)
                {
                    this.faQuestionRepository = new GenericRep<FaQuestion>(Context);
                }
                return faQuestionRepository;
            }
        }




        private GenericRep<StampedVisa> stampedVisaRepository;
        public GenericRep<StampedVisa> StampedVisaRepository
        {
            get
            {
                if (this.stampedVisaRepository == null)
                {
                    this.stampedVisaRepository = new GenericRep<StampedVisa>(Context);
                }
                return stampedVisaRepository;
            }
        }


        private GenericRep<LookUpValue> lookupValueRepository;
        public GenericRep<LookUpValue> LookupValueRepository
        {
            get
            {
                if (this.lookupValueRepository == null)
                {
                    this.lookupValueRepository = new GenericRep<LookUpValue>(Context);
                }
                return lookupValueRepository;
            }
        }
        private GenericRep<Category> categoryRepository;
        public GenericRep<Category> CategoryRepository
        {
            get
            {
                if (this.categoryRepository == null)
                {
                    this.categoryRepository = new GenericRep<Category>(Context);
                }
                return categoryRepository;
            }
        }
        private GenericRep<Author> authorRepository;
        public GenericRep<Author> AuthorRepository
        {
            get
            {
                if (this.authorRepository == null)
                {
                    this.authorRepository = new GenericRep<Author>(Context);
                }
                return authorRepository;
            }
        }
        private GenericRep<Blogs> blogsRepository;
        public GenericRep<Blogs> BlogsRepository
        {
            get
            {
                if (this.blogsRepository == null)
                {
                    this.blogsRepository = new GenericRep<Blogs>(Context);
                }
                return blogsRepository;
            }
        }

        public virtual bool Save()
        {
            bool returnValue = true;
            using (var dbContextTransaction = Context.Database.BeginTransaction())
            {
                try
                {
                    Context.SaveChanges();
                    dbContextTransaction.Commit();
                }
                catch (Exception ex)
                {
                    //Log Exception Handling message                      
                    returnValue = false;
                    dbContextTransaction.Rollback();
                }
            }

            return returnValue;
        }

        public virtual async Task<bool> SaveAsync()
        {
            bool returnValue = true;
            using (var dbContextTransaction = Context.Database.BeginTransaction())
            {
                try
                {
                    await Context.SaveChangesAsync();
                    dbContextTransaction.Commit();
                }
                catch (Exception)
                {
                    //Log Exception Handling message                      
                    returnValue = false;
                    dbContextTransaction.Rollback();
                }
            }

            return returnValue;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
