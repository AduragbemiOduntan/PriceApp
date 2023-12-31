﻿using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceApp_Domain.Dtos.Responses;

namespace PriceApp_Application.SeriviceMethods.Implementations
{
    public static class StaticMethods
    {
        public static string GetAppPassword()
        {
            string path = "C:\\Users\\aduragbemi.oduntan\\Desktop\\JustProjects\\PriceApp\\PriceApp-API\\appsettings.json";
            using (StreamReader reader = File.OpenText(path))
            {
                JObject jsonObject = (JObject)JToken.ReadFrom(new JsonTextReader(reader));
                string appPw = jsonObject["AppPW"]?.ToString();
                return appPw;
            }
        }

        public static double SandTonnageInConcrete(double concreteMixtureVolume)
        {
            const double bucketFactorOne = 0.9;
            const double bucketFactorTwo = 1.4;

            double sandPercentInTon = concreteMixtureVolume * bucketFactorOne * bucketFactorTwo;
            return sandPercentInTon;
        }
        public static double CementBagsInConcreteMixture(double concreteMixtureVolume)
        {
            const byte cementBagForOneVolumeOfConcreteMixture = 6;
            double totalBagsOfCement = concreteMixtureVolume * cementBagForOneVolumeOfConcreteMixture;
            return totalBagsOfCement;
        }

        public static double GranitePercentInConcrete(double totalSandTonnageInConcreteMixture)
        {
            double granitePercentInTon = totalSandTonnageInConcreteMixture * 2;
            return granitePercentInTon;
        }

        public static double IronTonnage(double concreteMixtureVolume)
        {
            double totalIronTonnage = concreteMixtureVolume * 2; 
            return totalIronTonnage;
        }



    }
}
