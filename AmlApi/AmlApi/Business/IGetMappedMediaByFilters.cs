﻿using System.Collections.Generic;
using System.Threading.Tasks;
using AmlApi.Resources;

namespace AmlApi.Business;

public interface IGetMappedMediaByFilters
{
    Task<GetMediaResponse> Get(Filters filters);
}