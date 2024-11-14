﻿using System.Collections.Generic;
using System.Threading.Tasks;
using AmlApi.DataAccess.Entities;
using AmlApi.Resources;

namespace AmlApi.DataAccess.Queries;

public interface IGetMediaByFilters
{
    Task<List<Inventory>> Get(Filters filters);
}