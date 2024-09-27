using System;
using System.Linq.Expressions;
using System.Reflection;
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

    public record KopekFilterResponse(List<KopekGetirResponse> Kopek, Dictionary<string,List<object>> ColumnValues, int TotalCount);
    public record GetKopekByFilterQuery(KopekFilterRequest Request) : IRequest<Result<KopekFilterResponse>>;

    public class GetKopekByFilterQueryHandler : IRequestHandler<GetKopekByFilterQuery, Result<KopekFilterResponse>>
    {
        private readonly GorkemDbContext context;

        public GetKopekByFilterQueryHandler(GorkemDbContext context)
        {
            this.context = context;
        }

        public async Task<Result<KopekFilterResponse>> Handle(GetKopekByFilterQuery request, CancellationToken cancellationToken)
        {
            TypeAdapterConfig<UT_Kopek, KopekGetirResponse>.NewConfig();
            var query = context.UT_Kopek_Kopeks.AsQueryable();

            if(request.Request.Filters.Count > 0){
                query = FilterData.Filter(query, request.Request.Filters);
            }

            if(request.Request.SortedColumn != ""){
                var direction = request.Request.SortDirection == "asc" ? "OrderBy" : "OrderByDescending";
                var param = Expression.Parameter(typeof(UT_Kopek), "x");
                var property = Expression.Property(param, request.Request.SortedColumn);
                var lambda = Expression.Lambda(property, param);
                var exp = Expression.Call(typeof(Queryable), direction, new Type [] {typeof(UT_Kopek), property.Type}, query.Expression, Expression.Quote(lambda));
                query = query.Provider.CreateQuery<UT_Kopek>(exp);
            }

            var paged = PagedResult<UT_Kopek>.ToPagedResponse(query,request.Request.PageNumber,2);

            var mappedItems = paged.Items.Adapt<List<KopekGetirResponse>>();

            var columnValues = GorkemReturning.GetUniqueValues(query,"NihaiKanaat");

            var response = new KopekFilterResponse(mappedItems, columnValues, query.Count());

            return await Result<KopekFilterResponse>.SuccessAsync(response);
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

