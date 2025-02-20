﻿using Gorkem_.Contracts.SecimTest;

namespace Gorkem_.Contracts.Kopek
{
    public class KopekPaginationResponse
    {
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public List<KopekListeleResponse> Kopekler { get; set; }

    }
}
