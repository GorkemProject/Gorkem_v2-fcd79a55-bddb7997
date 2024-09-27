using System;
using Application.Common.FilterExtensions;
using Application.Common.Results;
using AspNetCoreHero.Results;
using Carter;
using Gorkem_.Context;
using Gorkem_.Context.Entities;
using Gorkem_.Contracts.Kopek;
using Gorkem_.EndpointTags;
using GorkemPagingAndFiltering.Extension;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Gorkem_.Features.Kopek;

    public record KopekFilterResponse(List<KopekGetirResponse> Kopek, Dictionary<string,List<object>> ColumnValues);
    public record GetKopekByFilterQuery(KopekFilterRequest Request) : IRequest<Result<PagedResult<KopekFilterResponse>>>;

    public class GetKopekByFilterQueryHandler : IRequestHandler<GetKopekByFilterQuery, Result<PagedResult<KopekFilterResponse>>>
    {
        private readonly GorkemDbContext context;

        public GetKopekByFilterQueryHandler(GorkemDbContext context)
        {
            this.context = context;
        }

        public async Task<Result<PagedResult<KopekFilterResponse>>> Handle(GetKopekByFilterQuery request, CancellationToken cancellationToken)
        {
            TypeAdapterConfig<UT_Kopek, KopekGetirResponse>.NewConfig();
            var query = context.UT_Kopek_Kopeks.AsQueryable();

            if(request.Request.Filters.Count > 0){
                query = FilterData.Filter(query, request.Request.Filters);
            }

            var paged = PagedResult<UT_Kopek>.ToPagedResponse(query,request.Request.PageNumber,2);

            var mappedItems = paged.Items.Adapt<List<KopekGetirResponse>>();

            var columnValues = GorkemReturning.GetUniqueValues(query,"NihaiKanaat");

            var kopekFilterResponse = new List<KopekFilterResponse>(){
                new KopekFilterResponse(mappedItems, columnValues)
            };

            var response = new PagedResult<KopekFilterResponse>(kopekFilterResponse, query.Count(), paged.CurrentPage, paged.PageSize);

            return await Result<PagedResult<KopekFilterResponse>>.SuccessAsync(response);
        }
    }

    public class KopekFilterEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("kopek/kopekFilter", async ([FromBody] KopekFilterRequest request, ISender sender) =>
            {
                var response = await sender.Send(new GetKopekByFilterQuery(request));

                if (response.Succeeded)
                    return Results.Ok(response);

                return Results.BadRequest(response.Message);

            }).WithTags(EndpointConstants.KOPEK);
        }
    }

