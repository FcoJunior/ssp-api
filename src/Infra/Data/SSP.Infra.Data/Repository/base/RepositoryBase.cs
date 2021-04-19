using AutoMapper;

namespace SSP.Infra.Data.Repository
{
    public abstract class RepositoryBase
    {
        protected IContext _context;
        protected IMapper _mapper;

        public RepositoryBase(IContext context, IMapper mapper) {
            this._context = context;
            this._mapper = mapper;
        }
    }
}