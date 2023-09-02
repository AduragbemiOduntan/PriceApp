/*using PriceApp_Application.SeriviceMethods.Interfaces;
using PriceApp_Domain.Entities;
using PriceApp_Infrastructure.Persistence.ApplicationDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceApp_Application.SeriviceMethods.Implementations
{
    public class SettingOutMethods : ISettingOutMethods
    {
*//*        public MaterialEstimate Profile { get; set; }
        public MaterialEstimate Peg { get; set; }
        public MaterialEstimate Line { get; set; }
        public MaterialEstimate Nail { get; set; }
        public double BuidingSetbackPermeter { get; set; }*//*


        private readonly DataBaseContext _context;
        private MaterialEstimate _materialEstimate;
        private SettingOutStage _settingOutStage;

        public SettingOutMethods(DataBaseContext context, MaterialEstimate materialEstimate, SettingOutStage settingOutStage)
        {

            _context = context;
            _materialEstimate = materialEstimate;
            _settingOutStage = settingOutStage;
        }
*//*
        public Product GetPeg()
        {
            const string materialName = "Peg";
            var material = _context.Products.Where(x => x.ProductName == materialName).FirstOrDefault();
            return material;
        }

        public Product GetProfile()
        {
            const string materialName = "Profile";
            var material = _context.Products.Where(x => x.ProductName == materialName).FirstOrDefault();
            return material;
        }

        public Product GetLine()
        {
            const string materialName = "Line";
            var material = _context.Products.Where(x => x.ProductName == materialName).FirstOrDefault();
            return material;
        }

        public Product GetNail()
        {
            const string materialName = "Nail";
            var material = _context.Products.Where(x => x.ProductName == materialName).FirstOrDefault();
            return material;
        }
*//*


        public MaterialEstimate PegMaterialEstimate(double buidingSetbackPermeter, int uniqueProjectId)
        {
            //buidingSetbackPermeter and sectionDistance are in meter
            const byte sectionDistance = 3;
            const byte pegPerSectionDistance = 5;
            const byte minPegPerBundle = 15;

            //BSP is buildingSetBackPerimeter

            //Calculation for total peg bundle
            var peg = GetPeg();
            var strPegBundlePrice = peg.UnitPrice.ToString();
            var pegBundlePrice = double.Parse(strPegBundlePrice);
            var sectionDistanceInBSP = buidingSetbackPermeter / sectionDistance;
            var numOfPegInBSP = sectionDistanceInBSP * pegPerSectionDistance;
            var numOfPegBundle = numOfPegInBSP / minPegPerBundle;
            //Peg total cost
            var pegBundleTotalCost = numOfPegBundle * pegBundlePrice;

            *//*       Peg.ProductName = peg.ProductName;
                   Peg.UnitPrice = peg.UnitPrice;
                   Peg.Quantity = numOfPegBundle;
                   Peg.TotalPrice = pegBundleTotalCost;
                   Peg.Stage = "Setting-out";
                   Peg.UniqueProjectId = uniqueProjectId;*//*


            _materialEstimate.ProductName = peg.ProductName;
            _materialEstimate.UnitOfMeasurement = peg.UnitOfMeasurement;
            _materialEstimate.UnitPrice = peg.UnitPrice;
            _materialEstimate.Quantity = numOfPegBundle;
            _materialEstimate.TotalPrice = pegBundleTotalCost;
            _materialEstimate.Stage = "Setting-out";
            _materialEstimate.UniqueProjectId = uniqueProjectId;

            return _materialEstimate;
        }

        public MaterialEstimate ProfileMaterialEstimate(double buidingSetbackPermeter, int uniqueProjectId)
        {
            var profile = GetProfile();

            var pegEstimate = PegMaterialEstimate(buidingSetbackPermeter, uniqueProjectId);
            var pegBundleTotalCost = pegEstimate.TotalPrice;
            var profileTotalCost = pegBundleTotalCost / 2;

*//*            Profile.ProductName = profile.ProductName;
            Profile.UnitOfMeasurement = profile.UnitOfMeasurement;
            Profile.UnitPrice = profile.UnitPrice;
            Profile.Quantity = 0;
            Profile.TotalPrice = profileTotalCost;
            Profile.Stage = "Setting-out";
            Profile.UniqueProjectId = uniqueProjectId;*//*

            _materialEstimate.ProductName = profile.ProductName;
            _materialEstimate.UnitOfMeasurement = profile.UnitOfMeasurement;
            _materialEstimate.UnitPrice = profile.UnitPrice;
            _materialEstimate.Quantity = 0;
            _materialEstimate.TotalPrice = profileTotalCost;
            _materialEstimate.Stage = "Setting-out";
            _materialEstimate.UniqueProjectId = uniqueProjectId;

            return _materialEstimate;
        }

        public MaterialEstimate LineMaterialEstimate(double buidingSetbackPermeter, int uniqueProjectId)
        {

*//*            Line.ProductName = null;
            Line.UnitOfMeasurement = null;
            Line.UnitPrice = 0;
            Line.Quantity = 0;
            Line.TotalPrice = 5000;
            Line.Stage = "Setting-out";
            Line.UniqueProjectId = uniqueProjectId;*//*

            _materialEstimate.ProductName = null;
            _materialEstimate.UnitOfMeasurement = null;
            _materialEstimate.UnitPrice = 0;
            _materialEstimate.Quantity = 0;
            _materialEstimate.TotalPrice = 5000;
            _materialEstimate.Stage = "Setting-out";
            _materialEstimate.UniqueProjectId = uniqueProjectId;

            return _materialEstimate;
        }

        public MaterialEstimate NailMaterialEstimate(double buidingSetbackPermeter, int uniqueProjectId)
        {
            *//*            Nail.ProductName = null;
                        Nail.UnitOfMeasurement = null;
                        Nail.UnitPrice = 0;
                        Nail.Quantity = 0;
                        Nail.TotalPrice = 5000;
                        Nail.Stage = "Setting-out";
                        Nail.UniqueProjectId = uniqueProjectId;*//*

            _materialEstimate.ProductName = null;
            _materialEstimate.UnitOfMeasurement = null;
            _materialEstimate.UnitPrice = 0;
            _materialEstimate.Quantity = 0;
            _materialEstimate.TotalPrice = 5000;
            _materialEstimate.Stage = "Setting-out";
            _materialEstimate.UniqueProjectId = uniqueProjectId;

            return _materialEstimate;
        }

        public SettingOutStage SettingOutEstimate(double buidingSetbackPermeter, int uniqueProjectId)
        {
            var pegEstimate = PegMaterialEstimate(buidingSetbackPermeter, uniqueProjectId);
            var profileEstimate = ProfileMaterialEstimate(buidingSetbackPermeter, uniqueProjectId);
            var lineEstimate = LineMaterialEstimate(buidingSetbackPermeter, uniqueProjectId);
            var nailEstimate = NailMaterialEstimate(buidingSetbackPermeter, uniqueProjectId);

            var settingOutTotalCost = pegEstimate.TotalPrice + profileEstimate.TotalPrice + lineEstimate.TotalPrice + nailEstimate.TotalPrice;

            //Profile
            _settingOutStage.Profile.ProductName = profileEstimate.ProductName;
            _settingOutStage.Profile.UnitOfMeasurement = profileEstimate.UnitOfMeasurement;
            _settingOutStage.Profile.UnitPrice = profileEstimate.UnitPrice;
            _settingOutStage.Profile.Quantity = profileEstimate.Quantity;
            _settingOutStage.Profile.TotalPrice = profileEstimate.TotalPrice;
            _settingOutStage.Profile.Stage = profileEstimate.Stage;
            _settingOutStage.Profile.UniqueProjectId = uniqueProjectId;

            //Peg
            _settingOutStage.Peg.ProductName = pegEstimate.ProductName;
            _settingOutStage.Peg.UnitOfMeasurement = pegEstimate.UnitOfMeasurement;
            _settingOutStage.Peg.UnitPrice = pegEstimate.UnitPrice;
            _settingOutStage.Peg.Quantity = pegEstimate.Quantity;
            _settingOutStage.Peg.TotalPrice = pegEstimate.TotalPrice;
            _settingOutStage.Peg.Stage = pegEstimate.Stage;

            //Line
            _settingOutStage.Line.ProductName = lineEstimate.ProductName;
            _settingOutStage.Line.UnitOfMeasurement = lineEstimate.UnitOfMeasurement;
            _settingOutStage.Line.UnitPrice = lineEstimate.UnitPrice;
            _settingOutStage.Line.Quantity = lineEstimate.Quantity;
            _settingOutStage.Line.TotalPrice = lineEstimate.TotalPrice;
            _settingOutStage.Line.Stage = lineEstimate.Stage;
            _settingOutStage.Line.UniqueProjectId = uniqueProjectId;

            //Nail
            _settingOutStage.Nail.ProductName = nailEstimate.ProductName;
            _settingOutStage.Nail.UnitOfMeasurement = nailEstimate.UnitOfMeasurement;
            _settingOutStage.Nail.UnitPrice = nailEstimate.UnitPrice;
            _settingOutStage.Nail.Quantity = nailEstimate.Quantity;
            _settingOutStage.Nail.TotalPrice = nailEstimate.TotalPrice;
            _settingOutStage.Nail.Stage = nailEstimate.Stage;
            _settingOutStage.Nail.UniqueProjectId = uniqueProjectId;

            _settingOutStage.BuidingSetbackPermeter = buidingSetbackPermeter;
            _settingOutStage.TotalCostEstimate = settingOutTotalCost;
            _settingOutStage.UniqueProjectId = uniqueProjectId;

            return _settingOutStage;
        }




    }
}
*/