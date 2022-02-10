﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tranzact.TopProgrammingLanguage.Contracts.Dto;

namespace Tranzact.TopProgrammingLanguage.Contracts.Services
{
    public interface ISearchFightService
    {
        Task<SearchResponse> process(SearchRequest request);
    }
}
