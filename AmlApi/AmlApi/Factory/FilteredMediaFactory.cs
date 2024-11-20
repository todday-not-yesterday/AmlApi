﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmlApi.DataAccess.Enums;
using AmlApi.DataAccess.Queries.Interfaces;
using AmlApi.Factory.Interfaces;

namespace AmlApi.Factory;

public class FilteredMediaFactory : IFilteredMediaFactory
{
    private readonly IList<IGetFilteredMedia> getFilteredMedia;

    public FilteredMediaFactory(IList<IGetFilteredMedia> getFilteredMedia)
    {
        this.getFilteredMedia = getFilteredMedia;
    }

    public async Task<IGetFilteredMedia> GetFilter(MediaEnquiryTypeEnum mediaEnquiryTypeEnum)
    {
        return this.getFilteredMedia.FirstOrDefault(x => x.MediaEnquiryType == mediaEnquiryTypeEnum);
    }
}