using Agio.Flights.Business.Infrastructure.Abstract;

namespace Agio.Flights.Business.Services.Abstract
{
    public abstract class BaseService
    {
        #region Attributes

        /// <summary>
        /// The mapper of the service
        /// </summary>
        protected readonly IMapperDomain _mapper;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the current class with the specified parameters
        /// </summary>
        /// <param name="mapper">The mapper of the service</param>
        public BaseService(IMapperDomain mapper)
        {
            _mapper = mapper;
        }

        #endregion
    }
}
