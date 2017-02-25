using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using SuperfishBackendService.DataObjects;
using SuperfishBackendService.Models;
using System.Web.Http.Tracing;
using System;
using System.Collections.Generic;

namespace SuperfishBackendService.Controllers
{
    public class TodoItemController : TableController<TodoItem>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            SuperfishBackendContext context = new SuperfishBackendContext();
            DomainManager = new EntityDomainManager<TodoItem>(context, Request);
            
            ITraceWriter traceWriter = this.Configuration.Services.GetTraceWriter();
            traceWriter.Info("Hello, World");
        }

        // GET tables/TodoItem
        public IQueryable<TodoItem> GetAllTodoItems()
        {
            //IEnumerable<TodoItem> l = new List<TodoItem>
            //{
            //    new TodoItem {Text="try 1", Complete=false, CreatedAt=DateTime.Now, UpdatedAt=DateTime.Now,Deleted=false },
            //    new TodoItem {Text="try 2", Complete=false, CreatedAt=DateTime.Now, UpdatedAt=DateTime.Now,Deleted=false }

            //};
            //return l.AsQueryable();


            return Query();

        }

        // GET tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<TodoItem> GetTodoItem(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<TodoItem> PatchTodoItem(string id, Delta<TodoItem> patch)
        {
            return UpdateAsync(id, patch);
        }

        // POST tables/TodoItem
        public async Task<IHttpActionResult> PostTodoItem(TodoItem item)
        {

            try
            {
                TodoItem current = await InsertAsync(item);
                return CreatedAtRoute("Tables", new { id = current.Id }, current);

            }
            catch (Exception exc)
            {
                return null;
            }


        }

        // DELETE tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteTodoItem(string id)
        {
            return DeleteAsync(id);
        }
    }
}