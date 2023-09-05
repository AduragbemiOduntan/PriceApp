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
    public class EscavationService : IEscavationService
    {
        private readonly ILogger<EscavationService> _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public EscavationService(ILogger<EscavationService> logger, IMapper mapper, IUnitOfWork unitOfWorkkd) 
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWorkkd;
        }

        public async Task<StandardResponse<EscavationResponseDto>> CreateEscavationAsync(double girth, int uniqueProjectId)
        {
            const double pricePerMeter = 1000;

            if(uniqueProjectId == null || girth == null)
            {
                _logger.LogError("Field cannot be empty");
                StandardResponse<EscavationResponseDto>.Failed("Escavation creation failed");
            }
            _logger.LogInformation("Attempting to create escavation");

            var escavationTotal = girth * pricePerMeter;
            var escavationRequest = new EscavationRequestDto();

            escavationRequest.Girth = girth;
            escavationRequest.PricePerMeter = pricePerMeter;
            escavationRequest.uniqueProjectId = uniqueProjectId;
            escavationRequest.TotalPrice = escavationTotal;

            var escavation = _mapper.Map<Escavation>(escavationRequest);
            _unitOfWork.Escavation.Create(escavation);
            _unitOfWork.SaveAsync();
            var escavationToReturn = _mapper.Map<EscavationResponseDto>(escavation);

            return StandardResponse<EscavationResponseDto>.Success($"Escavation successfully created", escavationToReturn);
        }
    }
}
