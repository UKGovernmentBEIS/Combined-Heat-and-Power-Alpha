using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Org.OpenAPITools.Models;

namespace DESNZ.CHPQA.Alpha.Prototype.Functions
{ 
    public partial class DefaultApi
    { 
        [FunctionName("DefaultApi_SchemeRefGet")]
        public async Task<ActionResult<Scheme>> _SchemeRefGet([HttpTrigger(AuthorizationLevel.Anonymous, "Get", Route = "scheme/{ref}")]HttpRequest req, ExecutionContext context, string _ref)
        {
            var method = this.GetType().GetMethod("SchemeRefGet");
            if(method == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.NotImplemented);
            }
            return (await ((Task<Scheme>)method.Invoke(this, new object[] { req, context, id })).ConfigureAwait(false));
        }

        [FunctionName("DefaultApi_SchemesUserIdGet")]
        public async Task<ActionResult<Scheme>> _SchemesUserIdGet([HttpTrigger(AuthorizationLevel.Anonymous, "Get", Route = "schemes/{userId}")]HttpRequest req, ExecutionContext context, string userId)
        {
            var method = this.GetType().GetMethod("SchemesUserIdGet");
            if(method == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.NotImplemented);
            }
            return (await ((Task<Scheme>)method.Invoke(this, new object[] { req, context, id })).ConfigureAwait(false));
        }

        [FunctionName("DefaultApi_SubmissionRefPost")]
        public async Task<ActionResult<Scheme>> _SubmissionRefPost([HttpTrigger(AuthorizationLevel.Anonymous, "Post", Route = "submission/{ref}")]HttpRequest req, ExecutionContext context, string _ref)
        {
            var method = this.GetType().GetMethod("SubmissionRefPost");
            if(method == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.NotImplemented);
            }
            return (await ((Task<Scheme>)method.Invoke(this, new object[] { req, context, id })).ConfigureAwait(false));
        }
    }
}
