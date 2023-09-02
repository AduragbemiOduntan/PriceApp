using PriceApp_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceApp_Application.SeriviceMethods.Interfaces
{
    public interface ISettingOutMethods
    {
/*        Product GetPeg();
        Product GetProfile();
        Product GetLine();
        Product GetNail();*/
        MaterialEstimate PegMaterialEstimate(double buidingSetbackPermeter, int uniqueProjectId);
        MaterialEstimate ProfileMaterialEstimate(double buidingSetbackPermeter, int uniqueProjectId);
        MaterialEstimate LineMaterialEstimate(double buidingSetbackPermeter, int uniqueProjectId);
        MaterialEstimate NailMaterialEstimate(double buidingSetbackPermeter, int uniqueProjectId);
        SettingOutStage SettingOutEstimate(double buidingSetbackPermeter, int uniqueProjectId);
    }
}
