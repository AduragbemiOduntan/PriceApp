using Microsoft.EntityFrameworkCore;
using PriceApp_Domain.Dtos.Responses;
using PriceApp_Domain.Entities;
using PriceApp_Infrastructure.Persistence.ApplicationDbContext;
using PriceApp_Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceApp_Infrastructure.Repositories.Implementations
{
    public class MaterialEstimateRepository : RepositoryBase<MaterialEstimate>, IMaterialEstimateRepository
    {
        private readonly DataBaseContext _context;
       /* private IProductRepository _productRepository;*/

        public MaterialEstimateRepository(DataBaseContext context) : base(context)
        {
            _context = context;
        }

        public async Task<MaterialEstimate> GetMEByUniqueProjectIdAndStage(int uniqueProjectId, string stage)
        {
            return await FindByCondition(x => x.UniqueProjectId == uniqueProjectId && x.Stage == stage, false).FirstOrDefaultAsync();
        }



        //Material Estimate for specific products
/*        public async Task<MaterialEstimateResponseDto> PegME(double buidingSetbackPermeter, string stage)
        {
            var peg = _productRepository.GetPeg();
            //buidingSetbackPermeter and sectionDistance are in meter
            const byte sectionDistance = 3;
            const byte pegPerSectionDistance = 5;
            const byte minPegPerBundle = 15;

            //BSP is buildingSetBackPerimeter

            //Calculation for total peg bundle

            *//*    var pegBundlePrice = peg.UnitPrice;*//*
            var sectionDistanceInBSP = buidingSetbackPermeter / sectionDistance;
            var numOfPegInBSP = sectionDistanceInBSP * pegPerSectionDistance;
            var numOfPegBundle = numOfPegInBSP / minPegPerBundle;
            //Peg total cost
            var pegBundleTotalCost = numOfPegBundle * peg.UnitPrice;

            var materialEstimate = new MaterialEstimate();
            materialEstimate.Name = peg.ProductName;
            materialEstimate.UnitPrice = peg.UnitPrice;
            materialEstimate.UnitOfMeasurement = peg.UnitOfMeasurement;
            materialEstimate.Quantity = numOfPegBundle;
            materialEstimate.TotalPrice = pegBundleTotalCost;
            materialEstimate.Stage = stage;

          

            return materialEstimate;
        }*/


        // General
        /*        public Task<MaterialEstimate> GetEstimateByUniqueProjectIdAndStage(int uniqueProjectId, string stage)
                {
                    throw new NotImplementedException();
                }*/

        /*     public async Task<EstimateItem> EstimateByProductId(string name, double quantity, bool trackChanges)
             {
                 var product = await FindByCondition(x => x.Product.ProductName == name, trackChanges).FirstOrDefaultAsync();
                     *//*_context.Set<EstimateItem>().Where(x => x.Product.ProductName is name).Fi;*//*

             }*/

        /*        public async Task<MaterialEstimate> GetMaterialEstimateById(int id)
                {
                    return await FindByCondition(x => x.Id == id, false).FirstOrDefaultAsync();
                }

                public async Task<MaterialEstimate> GetMaterialEstimateByUniqueProjectId(int uniqueProjectId)
                {
                    return await FindByCondition(x => x.UniqueProjectId == uniqueProjectId, false).FirstOrDefaultAsync();
                }


                public async Task<MaterialEstimate> GetMaterialEstimateByUniqueProjectIdAndStage(int uniqueProjectId, string stage)
                {
                    return await FindByCondition(x => x.UniqueProjectId == uniqueProjectId && x.Stage == stage, false).FirstOrDefaultAsync();
                }*/

    }
}
