﻿// Copyright 2024 XLN Telecom, Inc.  All rights reserved.
// This computer source code and related instructions and comments are the unpublished
// confidential and proprietary information of XLN Telecom Ltd. and are protected under UK
// and foreign intellectual property laws. They may not be disclosed to, copied or used by
// any third party without the prior written consent of XLN Telecom Ltd.
// ----------------------------------------------------------------------------------------------------

namespace AmlApi.Business.Getters
{
    using System.Threading.Tasks;

    public class GetUser : IGetUser
    {
        public async Task<string> Get()
        {
            return "bob";
        }
    }
}