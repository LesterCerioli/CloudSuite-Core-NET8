﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Services.Contracts
{
    public interface ITokenAppService
    {
        Task<string> GenerateTokenAsync(string username);
    }
}
