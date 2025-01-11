﻿using Dima.Api.Common.Api;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Categories;
using Dima.Core.Responses;
using Dima.Core;
using Microsoft.AspNetCore.Mvc;
using Dima.Core.Requests.Transactions;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Dima.Api.Models;
using System.Security.Claims;

namespace Dima.Api.Endpoints.Transactions
{
    public class GetTransactionsByPeriodEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/", HandleAsync)
                .WithName("Transactions: GetByPeriod")
                .WithSummary("Transactions: Recupera todas as transações")
                .WithDescription("Transactions: Recupera todas as transações")
                .WithOrder(5)
                .Produces<PagedResponse<List<Transaction>?>>();

        private static async Task<IResult> HandleAsync(ClaimsPrincipal user,
                                                       ITransactionHandler handler,
                                                       [FromQuery] DateTime? startDate = null,
                                                       [FromQuery] DateTime? endDate = null,
                                                       [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
                                                       [FromQuery] int pageSize = Configuration.DefaultPageSize)
        {
            var request = new GetTransactionByPeriodRequest
            {
                UserId = user.Identity?.Name ?? string.Empty,
                PageNumber = pageNumber,
                PageSize = pageSize,
                StartDate = startDate,
                EndDate = endDate
            };

            var result = await handler.GetByPeriodAsync(request);
            return result.IsSuccess
                ? Results.Ok(result)
                : Results.BadRequest(result);
        }
    }
}
