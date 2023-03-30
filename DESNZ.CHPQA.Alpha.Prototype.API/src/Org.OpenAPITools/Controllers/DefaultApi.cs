/*
 * CHPQA Alpha Prototype API
 *
 * CHPQA Schemes and Submissions Proxy/Facade API
 *
 * The version of the OpenAPI document: 1.0.0
 * 
 * Generated by: https://openapi-generator.tech
 */

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;
using Newtonsoft.Json;
using Org.OpenAPITools.Attributes;
using Org.OpenAPITools.Models;

namespace Org.OpenAPITools.Controllers
{ 
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class DefaultApiController : ControllerBase
    { 
        /// <summary>
        /// Read a Scheme
        /// </summary>
        /// <param name="_ref">The identifier of the scheme</param>
        /// <response code="200">The Scheme corresponding to the provided &#x60;SchemeId&#x60;</response>
        /// <response code="404">No Scheme found for the provided &#x60;SchemeId&#x60;</response>
        /// <response code="500">Unexpected error</response>
        [HttpGet]
        [Route("/scheme/{ref}")]
        [Authorize(Policy = "ApiKey")]
        [ValidateModelState]
        [SwaggerOperation("SchemeRefGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(Scheme), description: "The Scheme corresponding to the provided &#x60;SchemeId&#x60;")]
        [SwaggerResponse(statusCode: 404, type: typeof(Error), description: "No Scheme found for the provided &#x60;SchemeId&#x60;")]
        [SwaggerResponse(statusCode: 500, type: typeof(Error), description: "Unexpected error")]
        public virtual IActionResult SchemeRefGet([FromRoute (Name = "ref")][Required]string _ref)
        {

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(Scheme));
            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(404, default(Error));
            //TODO: Uncomment the next line to return response 500 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(500, default(Error));
            string exampleJson = null;
            exampleJson = "{\r\n  \"additionalInformation\" : {\r\n    \"details\" : \"details\"\r\n  },\r\n  \"details\" : {\r\n    \"boilers\" : [ {\r\n      \"tagNumber\" : 1.4658129805029452,\r\n      \"yearCommissioned\" : 5.962133916683182,\r\n      \"maximumRatedPower\" : \"maximumRatedPower\",\r\n      \"details\" : \"details\",\r\n      \"model\" : \"model\",\r\n      \"maximumRatedHeat\" : \"maximumRatedHeat\",\r\n      \"type\" : \"type\",\r\n      \"manufacturer\" : \"manufacturer\"\r\n    }, {\r\n      \"tagNumber\" : 1.4658129805029452,\r\n      \"yearCommissioned\" : 5.962133916683182,\r\n      \"maximumRatedPower\" : \"maximumRatedPower\",\r\n      \"details\" : \"details\",\r\n      \"model\" : \"model\",\r\n      \"maximumRatedHeat\" : \"maximumRatedHeat\",\r\n      \"type\" : \"type\",\r\n      \"manufacturer\" : \"manufacturer\"\r\n    } ],\r\n    \"fuelBillFrequency\" : \"Monthly\",\r\n    \"primeMovers\" : [ {\r\n      \"tagNumber\" : 0.8008281904610115,\r\n      \"yearCommissioned\" : 6.027456183070403,\r\n      \"fuel\" : \"fuel\",\r\n      \"maximumRatedPower\" : \"maximumRatedPower\",\r\n      \"model\" : \"model\",\r\n      \"maximumRatedHeat\" : \"maximumRatedHeat\",\r\n      \"type\" : \"type\",\r\n      \"manufacturer\" : \"manufacturer\"\r\n    }, {\r\n      \"tagNumber\" : 0.8008281904610115,\r\n      \"yearCommissioned\" : 6.027456183070403,\r\n      \"fuel\" : \"fuel\",\r\n      \"maximumRatedPower\" : \"maximumRatedPower\",\r\n      \"model\" : \"model\",\r\n      \"maximumRatedHeat\" : \"maximumRatedHeat\",\r\n      \"type\" : \"type\",\r\n      \"manufacturer\" : \"manufacturer\"\r\n    } ],\r\n    \"diagrams\" : [ \"diagrams\", \"diagrams\" ],\r\n    \"sector\" : \"Chemical industry\"\r\n  },\r\n  \"info\" : {\r\n    \"ref\" : \"ref\",\r\n    \"name\" : \"name\"\r\n  },\r\n  \"meters\" : {\r\n    \"electricityMeters\" : [ {\r\n      \"yearInstalled\" : 7.061401241503109,\r\n      \"serialNumber\" : \"serialNumber\",\r\n      \"outputsRange\" : \"outputsRange\",\r\n      \"tag\" : \"tag\",\r\n      \"modelType\" : \"modelType\",\r\n      \"uncertainty\" : 9.301444243932576,\r\n      \"diagramReferenceNumber\" : \"diagramReferenceNumber\",\r\n      \"meterPointReference\" : \"meterPointReference\",\r\n      \"outputsUnit\" : \"outputsUnit\"\r\n    }, {\r\n      \"yearInstalled\" : 7.061401241503109,\r\n      \"serialNumber\" : \"serialNumber\",\r\n      \"outputsRange\" : \"outputsRange\",\r\n      \"tag\" : \"tag\",\r\n      \"modelType\" : \"modelType\",\r\n      \"uncertainty\" : 9.301444243932576,\r\n      \"diagramReferenceNumber\" : \"diagramReferenceNumber\",\r\n      \"meterPointReference\" : \"meterPointReference\",\r\n      \"outputsUnit\" : \"outputsUnit\"\r\n    } ],\r\n    \"fuelMeters\" : [ {\r\n      \"yearInstalled\" : 5.637376656633329,\r\n      \"serialNumber\" : \"serialNumber\",\r\n      \"outputsRange\" : \"outputsRange\",\r\n      \"tag\" : \"tag\",\r\n      \"modelType\" : \"modelType\",\r\n      \"uncertainty\" : 2.3021358869347655,\r\n      \"diagramReferenceNumber\" : \"diagramReferenceNumber\",\r\n      \"meterPointReference\" : \"meterPointReference\",\r\n      \"outputsUnit\" : \"outputsUnit\"\r\n    }, {\r\n      \"yearInstalled\" : 5.637376656633329,\r\n      \"serialNumber\" : \"serialNumber\",\r\n      \"outputsRange\" : \"outputsRange\",\r\n      \"tag\" : \"tag\",\r\n      \"modelType\" : \"modelType\",\r\n      \"uncertainty\" : 2.3021358869347655,\r\n      \"diagramReferenceNumber\" : \"diagramReferenceNumber\",\r\n      \"meterPointReference\" : \"meterPointReference\",\r\n      \"outputsUnit\" : \"outputsUnit\"\r\n    } ],\r\n    \"heatMeters\" : [ {\r\n      \"yearInstalled\" : 7.061401241503109,\r\n      \"serialNumber\" : \"serialNumber\",\r\n      \"outputsRange\" : \"outputsRange\",\r\n      \"tag\" : \"tag\",\r\n      \"modelType\" : \"modelType\",\r\n      \"uncertainty\" : 9.301444243932576,\r\n      \"diagramReferenceNumber\" : \"diagramReferenceNumber\",\r\n      \"meterPointReference\" : \"meterPointReference\",\r\n      \"outputsUnit\" : \"outputsUnit\"\r\n    }, {\r\n      \"yearInstalled\" : 7.061401241503109,\r\n      \"serialNumber\" : \"serialNumber\",\r\n      \"outputsRange\" : \"outputsRange\",\r\n      \"tag\" : \"tag\",\r\n      \"modelType\" : \"modelType\",\r\n      \"uncertainty\" : 9.301444243932576,\r\n      \"diagramReferenceNumber\" : \"diagramReferenceNumber\",\r\n      \"meterPointReference\" : \"meterPointReference\",\r\n      \"outputsUnit\" : \"outputsUnit\"\r\n    } ]\r\n  }\r\n}";
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<Scheme>(exampleJson)
            : default(Scheme);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// Read all schemes for the supplied userId
        /// </summary>
        /// <param name="userId">The user id of the Responsible Person (RP)</param>
        /// <response code="200">The Scheme corresponding to the provided &#x60;SchemeId&#x60;</response>
        [HttpGet]
        [Route("/schemes/{userId}")]
        [Authorize(Policy = "ApiKey")]
        [ValidateModelState]
        [SwaggerOperation("SchemesUserIdGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(Scheme), description: "The Scheme corresponding to the provided &#x60;SchemeId&#x60;")]
        public virtual IActionResult SchemesUserIdGet([FromRoute (Name = "userId")][Required]string userId)
        {

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(Scheme));
            string exampleJson = null;
            exampleJson = "{\r\n  \"additionalInformation\" : {\r\n    \"details\" : \"details\"\r\n  },\r\n  \"details\" : {\r\n    \"boilers\" : [ {\r\n      \"tagNumber\" : 1.4658129805029452,\r\n      \"yearCommissioned\" : 5.962133916683182,\r\n      \"maximumRatedPower\" : \"maximumRatedPower\",\r\n      \"details\" : \"details\",\r\n      \"model\" : \"model\",\r\n      \"maximumRatedHeat\" : \"maximumRatedHeat\",\r\n      \"type\" : \"type\",\r\n      \"manufacturer\" : \"manufacturer\"\r\n    }, {\r\n      \"tagNumber\" : 1.4658129805029452,\r\n      \"yearCommissioned\" : 5.962133916683182,\r\n      \"maximumRatedPower\" : \"maximumRatedPower\",\r\n      \"details\" : \"details\",\r\n      \"model\" : \"model\",\r\n      \"maximumRatedHeat\" : \"maximumRatedHeat\",\r\n      \"type\" : \"type\",\r\n      \"manufacturer\" : \"manufacturer\"\r\n    } ],\r\n    \"fuelBillFrequency\" : \"Monthly\",\r\n    \"primeMovers\" : [ {\r\n      \"tagNumber\" : 0.8008281904610115,\r\n      \"yearCommissioned\" : 6.027456183070403,\r\n      \"fuel\" : \"fuel\",\r\n      \"maximumRatedPower\" : \"maximumRatedPower\",\r\n      \"model\" : \"model\",\r\n      \"maximumRatedHeat\" : \"maximumRatedHeat\",\r\n      \"type\" : \"type\",\r\n      \"manufacturer\" : \"manufacturer\"\r\n    }, {\r\n      \"tagNumber\" : 0.8008281904610115,\r\n      \"yearCommissioned\" : 6.027456183070403,\r\n      \"fuel\" : \"fuel\",\r\n      \"maximumRatedPower\" : \"maximumRatedPower\",\r\n      \"model\" : \"model\",\r\n      \"maximumRatedHeat\" : \"maximumRatedHeat\",\r\n      \"type\" : \"type\",\r\n      \"manufacturer\" : \"manufacturer\"\r\n    } ],\r\n    \"diagrams\" : [ \"diagrams\", \"diagrams\" ],\r\n    \"sector\" : \"Chemical industry\"\r\n  },\r\n  \"info\" : {\r\n    \"ref\" : \"ref\",\r\n    \"name\" : \"name\"\r\n  },\r\n  \"meters\" : {\r\n    \"electricityMeters\" : [ {\r\n      \"yearInstalled\" : 7.061401241503109,\r\n      \"serialNumber\" : \"serialNumber\",\r\n      \"outputsRange\" : \"outputsRange\",\r\n      \"tag\" : \"tag\",\r\n      \"modelType\" : \"modelType\",\r\n      \"uncertainty\" : 9.301444243932576,\r\n      \"diagramReferenceNumber\" : \"diagramReferenceNumber\",\r\n      \"meterPointReference\" : \"meterPointReference\",\r\n      \"outputsUnit\" : \"outputsUnit\"\r\n    }, {\r\n      \"yearInstalled\" : 7.061401241503109,\r\n      \"serialNumber\" : \"serialNumber\",\r\n      \"outputsRange\" : \"outputsRange\",\r\n      \"tag\" : \"tag\",\r\n      \"modelType\" : \"modelType\",\r\n      \"uncertainty\" : 9.301444243932576,\r\n      \"diagramReferenceNumber\" : \"diagramReferenceNumber\",\r\n      \"meterPointReference\" : \"meterPointReference\",\r\n      \"outputsUnit\" : \"outputsUnit\"\r\n    } ],\r\n    \"fuelMeters\" : [ {\r\n      \"yearInstalled\" : 5.637376656633329,\r\n      \"serialNumber\" : \"serialNumber\",\r\n      \"outputsRange\" : \"outputsRange\",\r\n      \"tag\" : \"tag\",\r\n      \"modelType\" : \"modelType\",\r\n      \"uncertainty\" : 2.3021358869347655,\r\n      \"diagramReferenceNumber\" : \"diagramReferenceNumber\",\r\n      \"meterPointReference\" : \"meterPointReference\",\r\n      \"outputsUnit\" : \"outputsUnit\"\r\n    }, {\r\n      \"yearInstalled\" : 5.637376656633329,\r\n      \"serialNumber\" : \"serialNumber\",\r\n      \"outputsRange\" : \"outputsRange\",\r\n      \"tag\" : \"tag\",\r\n      \"modelType\" : \"modelType\",\r\n      \"uncertainty\" : 2.3021358869347655,\r\n      \"diagramReferenceNumber\" : \"diagramReferenceNumber\",\r\n      \"meterPointReference\" : \"meterPointReference\",\r\n      \"outputsUnit\" : \"outputsUnit\"\r\n    } ],\r\n    \"heatMeters\" : [ {\r\n      \"yearInstalled\" : 7.061401241503109,\r\n      \"serialNumber\" : \"serialNumber\",\r\n      \"outputsRange\" : \"outputsRange\",\r\n      \"tag\" : \"tag\",\r\n      \"modelType\" : \"modelType\",\r\n      \"uncertainty\" : 9.301444243932576,\r\n      \"diagramReferenceNumber\" : \"diagramReferenceNumber\",\r\n      \"meterPointReference\" : \"meterPointReference\",\r\n      \"outputsUnit\" : \"outputsUnit\"\r\n    }, {\r\n      \"yearInstalled\" : 7.061401241503109,\r\n      \"serialNumber\" : \"serialNumber\",\r\n      \"outputsRange\" : \"outputsRange\",\r\n      \"tag\" : \"tag\",\r\n      \"modelType\" : \"modelType\",\r\n      \"uncertainty\" : 9.301444243932576,\r\n      \"diagramReferenceNumber\" : \"diagramReferenceNumber\",\r\n      \"meterPointReference\" : \"meterPointReference\",\r\n      \"outputsUnit\" : \"outputsUnit\"\r\n    } ]\r\n  }\r\n}";
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<Scheme>(exampleJson)
            : default(Scheme);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// Create a submission
        /// </summary>
        /// <param name="_ref">The identifier of the scheme</param>
        /// <response code="201">The Scheme corresponding to the provided &#x60;SchemeId&#x60;</response>
        /// <response code="404">No Scheme found for the provided &#x60;SchemeId&#x60;</response>
        /// <response code="500">Unexpected error</response>
        [HttpPost]
        [Route("/submission/{ref}")]
        [Authorize(Policy = "ApiKey")]
        [ValidateModelState]
        [SwaggerOperation("SubmissionRefPost")]
        [SwaggerResponse(statusCode: 201, type: typeof(Scheme), description: "The Scheme corresponding to the provided &#x60;SchemeId&#x60;")]
        [SwaggerResponse(statusCode: 404, type: typeof(Error), description: "No Scheme found for the provided &#x60;SchemeId&#x60;")]
        [SwaggerResponse(statusCode: 500, type: typeof(Error), description: "Unexpected error")]
        public virtual IActionResult SubmissionRefPost([FromRoute (Name = "ref")][Required]string _ref)
        {

            //TODO: Uncomment the next line to return response 201 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(201, default(Scheme));
            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(404, default(Error));
            //TODO: Uncomment the next line to return response 500 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(500, default(Error));
            string exampleJson = null;
            exampleJson = "{\r\n  \"additionalInformation\" : {\r\n    \"details\" : \"details\"\r\n  },\r\n  \"details\" : {\r\n    \"boilers\" : [ {\r\n      \"tagNumber\" : 1.4658129805029452,\r\n      \"yearCommissioned\" : 5.962133916683182,\r\n      \"maximumRatedPower\" : \"maximumRatedPower\",\r\n      \"details\" : \"details\",\r\n      \"model\" : \"model\",\r\n      \"maximumRatedHeat\" : \"maximumRatedHeat\",\r\n      \"type\" : \"type\",\r\n      \"manufacturer\" : \"manufacturer\"\r\n    }, {\r\n      \"tagNumber\" : 1.4658129805029452,\r\n      \"yearCommissioned\" : 5.962133916683182,\r\n      \"maximumRatedPower\" : \"maximumRatedPower\",\r\n      \"details\" : \"details\",\r\n      \"model\" : \"model\",\r\n      \"maximumRatedHeat\" : \"maximumRatedHeat\",\r\n      \"type\" : \"type\",\r\n      \"manufacturer\" : \"manufacturer\"\r\n    } ],\r\n    \"fuelBillFrequency\" : \"Monthly\",\r\n    \"primeMovers\" : [ {\r\n      \"tagNumber\" : 0.8008281904610115,\r\n      \"yearCommissioned\" : 6.027456183070403,\r\n      \"fuel\" : \"fuel\",\r\n      \"maximumRatedPower\" : \"maximumRatedPower\",\r\n      \"model\" : \"model\",\r\n      \"maximumRatedHeat\" : \"maximumRatedHeat\",\r\n      \"type\" : \"type\",\r\n      \"manufacturer\" : \"manufacturer\"\r\n    }, {\r\n      \"tagNumber\" : 0.8008281904610115,\r\n      \"yearCommissioned\" : 6.027456183070403,\r\n      \"fuel\" : \"fuel\",\r\n      \"maximumRatedPower\" : \"maximumRatedPower\",\r\n      \"model\" : \"model\",\r\n      \"maximumRatedHeat\" : \"maximumRatedHeat\",\r\n      \"type\" : \"type\",\r\n      \"manufacturer\" : \"manufacturer\"\r\n    } ],\r\n    \"diagrams\" : [ \"diagrams\", \"diagrams\" ],\r\n    \"sector\" : \"Chemical industry\"\r\n  },\r\n  \"info\" : {\r\n    \"ref\" : \"ref\",\r\n    \"name\" : \"name\"\r\n  },\r\n  \"meters\" : {\r\n    \"electricityMeters\" : [ {\r\n      \"yearInstalled\" : 7.061401241503109,\r\n      \"serialNumber\" : \"serialNumber\",\r\n      \"outputsRange\" : \"outputsRange\",\r\n      \"tag\" : \"tag\",\r\n      \"modelType\" : \"modelType\",\r\n      \"uncertainty\" : 9.301444243932576,\r\n      \"diagramReferenceNumber\" : \"diagramReferenceNumber\",\r\n      \"meterPointReference\" : \"meterPointReference\",\r\n      \"outputsUnit\" : \"outputsUnit\"\r\n    }, {\r\n      \"yearInstalled\" : 7.061401241503109,\r\n      \"serialNumber\" : \"serialNumber\",\r\n      \"outputsRange\" : \"outputsRange\",\r\n      \"tag\" : \"tag\",\r\n      \"modelType\" : \"modelType\",\r\n      \"uncertainty\" : 9.301444243932576,\r\n      \"diagramReferenceNumber\" : \"diagramReferenceNumber\",\r\n      \"meterPointReference\" : \"meterPointReference\",\r\n      \"outputsUnit\" : \"outputsUnit\"\r\n    } ],\r\n    \"fuelMeters\" : [ {\r\n      \"yearInstalled\" : 5.637376656633329,\r\n      \"serialNumber\" : \"serialNumber\",\r\n      \"outputsRange\" : \"outputsRange\",\r\n      \"tag\" : \"tag\",\r\n      \"modelType\" : \"modelType\",\r\n      \"uncertainty\" : 2.3021358869347655,\r\n      \"diagramReferenceNumber\" : \"diagramReferenceNumber\",\r\n      \"meterPointReference\" : \"meterPointReference\",\r\n      \"outputsUnit\" : \"outputsUnit\"\r\n    }, {\r\n      \"yearInstalled\" : 5.637376656633329,\r\n      \"serialNumber\" : \"serialNumber\",\r\n      \"outputsRange\" : \"outputsRange\",\r\n      \"tag\" : \"tag\",\r\n      \"modelType\" : \"modelType\",\r\n      \"uncertainty\" : 2.3021358869347655,\r\n      \"diagramReferenceNumber\" : \"diagramReferenceNumber\",\r\n      \"meterPointReference\" : \"meterPointReference\",\r\n      \"outputsUnit\" : \"outputsUnit\"\r\n    } ],\r\n    \"heatMeters\" : [ {\r\n      \"yearInstalled\" : 7.061401241503109,\r\n      \"serialNumber\" : \"serialNumber\",\r\n      \"outputsRange\" : \"outputsRange\",\r\n      \"tag\" : \"tag\",\r\n      \"modelType\" : \"modelType\",\r\n      \"uncertainty\" : 9.301444243932576,\r\n      \"diagramReferenceNumber\" : \"diagramReferenceNumber\",\r\n      \"meterPointReference\" : \"meterPointReference\",\r\n      \"outputsUnit\" : \"outputsUnit\"\r\n    }, {\r\n      \"yearInstalled\" : 7.061401241503109,\r\n      \"serialNumber\" : \"serialNumber\",\r\n      \"outputsRange\" : \"outputsRange\",\r\n      \"tag\" : \"tag\",\r\n      \"modelType\" : \"modelType\",\r\n      \"uncertainty\" : 9.301444243932576,\r\n      \"diagramReferenceNumber\" : \"diagramReferenceNumber\",\r\n      \"meterPointReference\" : \"meterPointReference\",\r\n      \"outputsUnit\" : \"outputsUnit\"\r\n    } ]\r\n  }\r\n}";
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<Scheme>(exampleJson)
            : default(Scheme);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }
    }
}
