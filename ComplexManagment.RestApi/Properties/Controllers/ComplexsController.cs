using ComplexManagment.DataLayer;
using ComplexManagment.DataLayer.Dto.Complexs;
using ComplexManagment.DataLayer.Entities;
using ComplexManagment.DataLayer.Repositories.Complexs;
using Microsoft.AspNetCore.Mvc;

namespace ComplexManagment.Controllers
{
    [Route("complexs")]
    [ApiController]
    public class ComplexsController : ControllerBase
    {

        private readonly ComplexRepository _complexRepository;
        private readonly UnitOfWork _unitOfWork;

        public ComplexsController(ComplexRepository complexRepository,
            UnitOfWork unitOfWork)
        {
            _complexRepository = complexRepository;
            _unitOfWork = unitOfWork;
        }
        
        [HttpPost]
        public void Add([FromBody]AddComplexDto dto)
        {
            var complex = new Complex()
            {
                Name = dto.Name,
                UnitCount = dto.UnitCount,
            };
            
            _complexRepository.Add(complex);
            _unitOfWork.Complit();
        }

        [HttpGet]
        public List<GetAllComplexByNameDto> GetAll([FromQuery]string? name)
        {
            return _complexRepository.GetAll(name);
        }
        
      
        [HttpGet("{id}/usage-type")]
        public List<GetUsageTypeComplexDto> GetUsageType([FromRoute]int id)
        {
            return _complexRepository.GetComplexOfUsagetype(id);

            
        }
    }
} 