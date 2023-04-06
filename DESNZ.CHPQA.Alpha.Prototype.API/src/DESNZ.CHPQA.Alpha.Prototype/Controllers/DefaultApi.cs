using DESNZ.CHPQA.Alpha.Prototype.Attributes;
using DESNZ.CHPQA.Alpha.Prototype.Models;
using DESNZ.CHPQA.Alpha.Prototype.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.PowerPlatform.Dataverse.Client;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DESNZ.CHPQA.Alpha.Prototype.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class DefaultApiController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public DefaultApiController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private (ServiceClient serviceClient, XrmServiceContext service) GetService()
        {
            var clientId = _configuration.GetValue("ClientId", string.Empty);
            var clientSecret = _configuration.GetValue("ClientSecret", string.Empty);
            var environmentUrl = _configuration.GetValue("EnvironmentUrl", string.Empty);
            var instanceUri = new Uri(environmentUrl);
            var serviceClient = new ServiceClient(instanceUri, clientId, clientSecret, true);
            var service = new XrmServiceContext(serviceClient);
            return (serviceClient, service);
        }

        /// <summary>
        /// Read all schemes for the supplied userId
        /// </summary>
        /// <param name="userId">The user id of the Responsible Person (RP)</param>
        /// <response code="200">The Schemes available to the supplied userId</response>
        [HttpGet]
        [Route("/schemes/{userId}")]
        [ValidateModelState]
        [SwaggerOperation("SchemesUserIdGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Services.Scheme>), description: "The Schemes available to the supplied userId")]
        public async Task<IActionResult> SchemesUserIdGet([FromRoute(Name = "userId")][Required] string userId)
        {
            (var serviceClient, var service) = GetService();

            try
            {
                var schemes = service.SchemeSet.ToList();
                foreach (var scheme in schemes)
                {
                    var relationships = scheme.RelationProperties.ToList();
                    foreach (var relationship in relationships)
                    {
                        service.LoadProperty(scheme, relationship.Key);
                    }
                }

                var results = schemes.Select(x => new
                {
                    info = new
                    {
                        x.Ref,
                        Name = x.CompanyName,
                    },
                    details = new
                    {
                        x.Sector,
                        x.FuelBillFrequency
                    }
                });

                return new ObjectResult(results);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
                throw;
            }
        }

        private string GetSectorKey(string sector)
        {
            switch (sector)
            {
                case "Airports": return "AIRPORT";
                case "Chemical and pharmaceutical industry": return "CHEM";
                case "Construction": return "CON";
                case "Defence": return "DEF";
                case "Education": return "EDU";
                case "Electrical and instrument engineering": return "ELEC";
                case "Extraction, mining and agglomeration": return "EXTRACT";
                case "Food, beverages and tobacco": return "FOOD";
                case "Health": return "HEALTH";
                case "Horticulture": return "HORT";
                case "Hotels": return "HOTELS";
                case "Iron and steel": return "IRON";
                case "Local or national government": return "GOV";
                case "Manufacturing and retail": return "MANUF";
                case "Mechanical engineering and metal products": return "MECH";
                case "Mineral products (for example - glass, cement, bricks)": return "MINERAL";
                case "Mixed community heating": return "MIXED";
                case "Non-ferrous metals": return "NONFERROUS";
                case "Offices": return "OFFICES";
                case "Oil refineries": return "OIL";
                case "Other commerce": return "OCOMM";
                case "Other industrial branches": return "OIND";
                case "Other public administration": return "OADMIN";
                case "Paper, publishing and printing": return "PAPER";
                case "Post Office": return "PO";
                case "Private hospitals": return "PHOSP";
                case "Public sector housing": return "PHOUSING";
                case "Royal Household": return "ROYAL";
                case "Scientific research": return "SCI";
                case "Sewage treatment": return "SEWAGE";
                case "Sports and leisure": return "SPORT";
                case "Textiles, clothing and footwear": return "TEXTILES";
                case "Timber": return "TIMBER";
                case "Transport": return "TRANSPORT";
                case "Vehicles": return "VEH";
            }
            return "";
        }

        /// <summary>
        /// Read a Scheme
        /// </summary>
        /// <param name="_ref">The identifier of the scheme</param>
        /// <response code="200">The Scheme identified by the supplied ref parameter</response>
        /// <response code="404">No Scheme found for the provided &#x60;ref&#x60;</response>
        /// <response code="500">Unexpected error</response>
        [HttpGet]
        [Route("/scheme/{ref}")]
        [ValidateModelState]
        [SwaggerOperation("SchemeRefGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(Services.Scheme), description: "The Scheme identified by the supplied ref parameter")]
        [SwaggerResponse(statusCode: 404, type: typeof(Error), description: "No Scheme found for the provided &#x60;ref&#x60;")]
        [SwaggerResponse(statusCode: 500, type: typeof(Error), description: "Unexpected error")]
        public virtual IActionResult SchemeRefGet([FromRoute(Name = "ref")][Required] string _ref)
        {
            (var serviceClient, var service) = GetService();

            try
            {
                var scheme = service.SchemeSet.FirstOrDefault(x => x.Ref == _ref);

                // Return not found if scheme not set
                if (scheme == null)
                {
                    return StatusCode(404, default(Error));
                }

                // Load related entities
                var relationships = scheme.RelationProperties.ToList();
                foreach (var relationship in relationships)
                {
                    service.LoadProperty(scheme, relationship.Key);
                }

                var result = new
                {
                    scheme = new
                    {
                        info = new
                        {
                            scheme.Ref,
                            Name = scheme.CompanyName,
                        },
                        additionalInformation = new
                        {
                            details = "" //WebUtility.UrlEncode(scheme.AdditionalInformation)
                        },
                        details = new
                        {
                            sector = GetSectorKey(scheme.Sector.ToString()),
                            fuelBillFrequency = scheme.FuelBillFrequency.ToString().ToUpper(),
                            diagrams = scheme.DiagramsOfScheme?.Select(diagram => diagram.Filename),
                            primeMovers = scheme.PrimeMoversOfScheme?.Select(primeMover => new
                            {
                                primeMover.TagNumber,
                                type = primeMover.TypeName,
                                fuel = primeMover.FuelName,
                                manufacturer = primeMover.ManufacturerName,
                                model = primeMover.ModelName,
                                primeMover.YearCommissioned,
                                primeMover.MaximumRatedHeat,
                                primeMover.MaximumRatedPower
                            }),
                            boilers = scheme.BoilersOfScheme?.Select(boiler => new
                            {
                                boiler.TagNumber,
                                type = boiler.TypeName,
                                boiler.Details,
                                manufacturer = boiler.ManufacturerName,
                                model = boiler.ModelName,
                                boiler.YearCommissioned,
                                boiler.MaximumRatedHeat,
                                boiler.MaximumRatedPower
                            })
                        },
                        meters = new
                        {
                            fuelMeters = scheme.MetersOfScheme?
                            .Where(meter => meter.MeterType == GlobalEnums.MeterType.Fuel)
                            .Select(meter => new
                            {
                                meter.Tag,
                                meter.DiagramReferenceNumber,
                                meter.YearInstalled,
                                meter.OutputsRange,
                                meter.OutputsUnit,
                                meter.ModelType,
                                meter.Uncertainty,
                                meter.MeterPointReference,
                                meter.SerialNumber
                            }),
                            electricityMeters = scheme.MetersOfScheme?
                            .Where(meter => meter.MeterType == GlobalEnums.MeterType.Electricity)
                            .Select(meter => new
                            {
                                meter.Tag,
                                meter.DiagramReferenceNumber,
                                meter.YearInstalled,
                                meter.OutputsRange,
                                meter.OutputsUnit,
                                meter.ModelType,
                                meter.Uncertainty,
                                meter.MeterPointReference,
                                meter.SerialNumber
                            }),
                            heatMeters = scheme.MetersOfScheme?
                            .Where(meter => meter.MeterType == GlobalEnums.MeterType.Heat)
                            .Select(meter => new
                            {
                                meter.Tag,
                                meter.DiagramReferenceNumber,
                                meter.YearInstalled,
                                meter.OutputsRange,
                                meter.OutputsUnit,
                                meter.ModelType,
                                meter.Uncertainty,
                                meter.MeterPointReference,
                                meter.SerialNumber
                            }),
                        }
                    }
                };

                return new ObjectResult(result);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
                throw;
            }
        }

        /// <summary>
        /// Create a submission
        /// </summary>
        /// <param name="_ref">The Scheme ref</param>
        /// <response code="201">The Scheme identified by the provided &#x60;ref&#x60;</response>
        /// <response code="404">No Scheme found for the provided &#x60;ref&#x60; parameter</response>
        /// <response code="500">Unexpected error</response>
        [HttpPost]
        [Route("/submission/{ref}")]
        [ValidateModelState]
        [SwaggerOperation("SubmissionRefPost")]
        [SwaggerResponse(statusCode: 201, type: typeof(Services.Scheme), description: "The Scheme identified by the provided &#x60;ref&#x60;")]
        [SwaggerResponse(statusCode: 404, type: typeof(Error), description: "No Scheme found for the provided &#x60;ref&#x60; parameter")]
        [SwaggerResponse(statusCode: 500, type: typeof(Error), description: "Unexpected error")]
        public virtual IActionResult SubmissionRefPost([FromRoute(Name = "ref")][Required] string _ref)
        {

            //TODO: Uncomment the next line to return response 201 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(201, default(Scheme));
            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(404, default(Error));
            //TODO: Uncomment the next line to return response 500 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(500, default(Error));
            string exampleJson = null;
            exampleJson = "{\r\n  \"boilers\" : [ {\r\n    \"tagNumber\" : 1.4658129805029452,\r\n    \"yearCommissioned\" : 5.962133916683182,\r\n    \"maximumRatedPower\" : \"maximumRatedPower\",\r\n    \"details\" : \"details\",\r\n    \"model\" : \"model\",\r\n    \"maximumRatedHeat\" : \"maximumRatedHeat\",\r\n    \"type\" : \"type\",\r\n    \"manufacturer\" : \"manufacturer\"\r\n  }, {\r\n    \"tagNumber\" : 1.4658129805029452,\r\n    \"yearCommissioned\" : 5.962133916683182,\r\n    \"maximumRatedPower\" : \"maximumRatedPower\",\r\n    \"details\" : \"details\",\r\n    \"model\" : \"model\",\r\n    \"maximumRatedHeat\" : \"maximumRatedHeat\",\r\n    \"type\" : \"type\",\r\n    \"manufacturer\" : \"manufacturer\"\r\n  } ],\r\n  \"additionalInformation\" : {\r\n    \"details\" : \"details\"\r\n  },\r\n  \"primeMovers\" : [ {\r\n    \"tagNumber\" : 0.8008281904610115,\r\n    \"yearCommissioned\" : 6.027456183070403,\r\n    \"fuel\" : \"fuel\",\r\n    \"maximumRatedPower\" : \"maximumRatedPower\",\r\n    \"model\" : \"model\",\r\n    \"maximumRatedHeat\" : \"maximumRatedHeat\",\r\n    \"type\" : \"type\",\r\n    \"manufacturer\" : \"manufacturer\"\r\n  }, {\r\n    \"tagNumber\" : 0.8008281904610115,\r\n    \"yearCommissioned\" : 6.027456183070403,\r\n    \"fuel\" : \"fuel\",\r\n    \"maximumRatedPower\" : \"maximumRatedPower\",\r\n    \"model\" : \"model\",\r\n    \"maximumRatedHeat\" : \"maximumRatedHeat\",\r\n    \"type\" : \"type\",\r\n    \"manufacturer\" : \"manufacturer\"\r\n  } ],\r\n  \"details\" : {\r\n    \"fuelBillFrequency\" : \"Monthly\",\r\n    \"diagrams\" : [ \"diagrams\", \"diagrams\" ],\r\n    \"sector\" : \"Chemical industry\"\r\n  },\r\n  \"info\" : {\r\n    \"ref\" : \"ref\",\r\n    \"name\" : \"name\"\r\n  },\r\n  \"meters\" : {\r\n    \"electricityMeters\" : [ {\r\n      \"yearInstalled\" : 5.637376656633329,\r\n      \"serialNumber\" : \"serialNumber\",\r\n      \"outputsRange\" : \"outputsRange\",\r\n      \"tag\" : \"tag\",\r\n      \"modelType\" : \"modelType\",\r\n      \"uncertainty\" : 2.3021358869347655,\r\n      \"diagramReferenceNumber\" : \"diagramReferenceNumber\",\r\n      \"meterPointReference\" : \"meterPointReference\",\r\n      \"outputsUnit\" : \"outputsUnit\"\r\n    }, {\r\n      \"yearInstalled\" : 5.637376656633329,\r\n      \"serialNumber\" : \"serialNumber\",\r\n      \"outputsRange\" : \"outputsRange\",\r\n      \"tag\" : \"tag\",\r\n      \"modelType\" : \"modelType\",\r\n      \"uncertainty\" : 2.3021358869347655,\r\n      \"diagramReferenceNumber\" : \"diagramReferenceNumber\",\r\n      \"meterPointReference\" : \"meterPointReference\",\r\n      \"outputsUnit\" : \"outputsUnit\"\r\n    } ],\r\n    \"fuelMeters\" : [ {\r\n      \"yearInstalled\" : 5.637376656633329,\r\n      \"serialNumber\" : \"serialNumber\",\r\n      \"outputsRange\" : \"outputsRange\",\r\n      \"tag\" : \"tag\",\r\n      \"modelType\" : \"modelType\",\r\n      \"uncertainty\" : 2.3021358869347655,\r\n      \"diagramReferenceNumber\" : \"diagramReferenceNumber\",\r\n      \"meterPointReference\" : \"meterPointReference\",\r\n      \"outputsUnit\" : \"outputsUnit\"\r\n    }, {\r\n      \"yearInstalled\" : 5.637376656633329,\r\n      \"serialNumber\" : \"serialNumber\",\r\n      \"outputsRange\" : \"outputsRange\",\r\n      \"tag\" : \"tag\",\r\n      \"modelType\" : \"modelType\",\r\n      \"uncertainty\" : 2.3021358869347655,\r\n      \"diagramReferenceNumber\" : \"diagramReferenceNumber\",\r\n      \"meterPointReference\" : \"meterPointReference\",\r\n      \"outputsUnit\" : \"outputsUnit\"\r\n    } ],\r\n    \"heatMeters\" : [ {\r\n      \"yearInstalled\" : 5.637376656633329,\r\n      \"serialNumber\" : \"serialNumber\",\r\n      \"outputsRange\" : \"outputsRange\",\r\n      \"tag\" : \"tag\",\r\n      \"modelType\" : \"modelType\",\r\n      \"uncertainty\" : 2.3021358869347655,\r\n      \"diagramReferenceNumber\" : \"diagramReferenceNumber\",\r\n      \"meterPointReference\" : \"meterPointReference\",\r\n      \"outputsUnit\" : \"outputsUnit\"\r\n    }, {\r\n      \"yearInstalled\" : 5.637376656633329,\r\n      \"serialNumber\" : \"serialNumber\",\r\n      \"outputsRange\" : \"outputsRange\",\r\n      \"tag\" : \"tag\",\r\n      \"modelType\" : \"modelType\",\r\n      \"uncertainty\" : 2.3021358869347655,\r\n      \"diagramReferenceNumber\" : \"diagramReferenceNumber\",\r\n      \"meterPointReference\" : \"meterPointReference\",\r\n      \"outputsUnit\" : \"outputsUnit\"\r\n    } ]\r\n  }\r\n}";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<Services.Scheme>(exampleJson)
            : default(Services.Scheme);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }
    }
}
