﻿using PriceApp_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceApp_Infrastructure.Repositories.Interfaces
{
    public interface ISettingOutStageRepository : IRepositoryBase<SettingOutStage>
    {
        Task<SettingOutStage> GetSettingOutByUniqueProjectId(string appellation);
    }
}
