using Dima.Api;
using Dima.Api.Common.Api;
using Dima.Api.Endpoints;
using Dima.Api.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);
builder.AddConfiguration();
builder.AddSecurity();
builder.AddDataContexts();
builder.AddCrossOrigin();
builder.AddDocumentation();
builder.AddServices();

var app = builder.Build();

if(app.Environment.IsDevelopment()) 
    app.ConfigureDevEnvironment();


app.UseCors(ApiConfiguration.CorsPolicyName);

app.UseSecurity();

app.MapEndpoints();

#region Endpoint Implementação antiga

//app.MapGet(
//           "/v1/categories/{id}", async
//           (long id,
//            ICategoryHandler handler)
//               => {
//                   var request = new GetCategoryByIdRequest
//                   {
//                       Id = id,
//                       UserId = "teste@balta.io"
//                   };
//                   return await handler.GetByIdAsync(request);
//               })
//           .WithName("Categories: GetById")
//           .WithSummary("Recupera uma categoria")
//           .Produces<Response<Category?>>();

//app.MapGet(
//           "/v1/categories", async
//           ( ICategoryHandler handler)
//               => {
//                   var request = new GetAllCategoriesRequest
//                   {                       
//                       UserId = "teste@balta.io"
//                   };
//                   return await handler.GetAllAsync(request);
//               })
//           .WithName("Categories: GetAll")
//           .WithSummary("Recupera todas as categorias de um usuário")
//           .Produces<PagedResponse<List<Category>?>>();

//app.MapPost(
//            "/v1/categories", async
//            (CreateCategoryRequest request, 
//             ICategoryHandler handler) 
//                => await handler.CreateAsync(request))
//            .WithName("Categories: Create")
//            .WithSummary("Cria uma nova categoria")
//            .Produces<Response<Category?>>();

//app.MapPut(
//           "/v1/categories/{id}", async 
//           (long id,
//            UpdateCategoryRequest request,
//            ICategoryHandler handler)
//               => { 
//                   request.Id = id;
//                   return await handler.UpdateAsync(request);
//               })
//           .WithName("Categories: Update")
//           .WithSummary("Atualiza uma categoria")
//           .Produces<Response<Category?>>();

//app.MapDelete(
//              "/v1/categories/{id}", async 
//              (long id,               
//               ICategoryHandler handler)
//                  => {
//                      var request = new DeleteCategoryRequest
//                      {
//                          Id = id,
//                          UserId = "teste@balta.io"                          
//                      };                      
//                      return await handler.DeleteAsync(request);
//                  })
//              .WithName("Categories: Delete")
//              .WithSummary("Exclui uma categoria")
//              .Produces<Response<Category?>>();

#endregion

app.Run();
 