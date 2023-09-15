using AutoMapper;
using Microsoft.Extensions.Logging;
using PriceApp_Application.Services.Interfaces;
using PriceApp_Domain.Dtos.Requests;
using PriceApp_Domain.Dtos.Responses;
using PriceApp_Domain.Entities;
using PriceApp_Infrastructure.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceApp_Application.Services.Implementation
{
    public class ExcavationService : IExcavationService
    {
        private readonly ILogger<ExcavationService> _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ExcavationService(ILogger<ExcavationService> logger, IMapper mapper, IUnitOfWork unitOfWorkkd) 
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWorkkd;
        }

        public async Task<StandardResponse<ExcavationResponseDto>> CreateExcavationAsync(double girth, int uniqueProjectId)
        {
            const double pricePerMeter = 1000;

            if(uniqueProjectId == null || girth == null)
            {
                _logger.LogError("Field cannot be empty");
                StandardResponse<ExcavationResponseDto>.Failed("Escavation creation failed");
            }
            _logger.LogInformation("Attempting to create escavation");

            var excavationTotal = girth * pricePerMeter;
            var excavationRequest = new ExcavationRequestDto();

            excavationRequest.Girth = girth;
            excavationRequest.PricePerMeter = pricePerMeter;
            excavationRequest.uniqueProjectId = uniqueProjectId;
            excavationRequest.TotalPrice = excavationTotal;

            var excavation = _mapper.Map<Excavation>(excavationRequest);
            _unitOfWork.Excavation.Create(excavation);
            await _unitOfWork.SaveAsync();
            var excavationToReturn = _mapper.Map<ExcavationResponseDto>(excavation);

            return StandardResponse<ExcavationResponseDto>.Success($"Escavation successfully created", excavationToReturn);
        }
    }
}
