using DESNZ.CHPQA.Alpha.Prototype.Attributes;
using DESNZ.CHPQA.Alpha.Prototype.Models;
using DESNZ.CHPQA.Alpha.Prototype.Services;
using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Extensions.Configuration;
using Microsoft.PowerPlatform.Dataverse.Client;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Meter = DESNZ.CHPQA.Alpha.Prototype.Services.Meter;

namespace DESNZ.CHPQA.Alpha.Prototype.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class DefaultApiController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly TelemetryClient _telemetryClient;

        public DefaultApiController(IConfiguration configuration, TelemetryClient telemetryClient)
        {
            _configuration = configuration;
            _telemetryClient = telemetryClient;
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

        private string GetSectorString(GlobalEnums.Sector sector)
        {
            switch (sector)
            {
                case GlobalEnums.Sector.Airports: return "Airports";
                case GlobalEnums.Sector.Chemicalandpharmaceuticalindustry: return "Chemical and pharmaceutical industry";
                case GlobalEnums.Sector.Construction: return "Construction";
                case GlobalEnums.Sector.Defence: return "Defence";
                case GlobalEnums.Sector.Education: return "Education";
                case GlobalEnums.Sector.Electricalandinstrumentengineering: return "Electrical and instrument engineering";
                case GlobalEnums.Sector.Extractionminingandagglomeration: return "Extraction, mining and agglomeration";
                case GlobalEnums.Sector.Foodbeveragesandtobacco: return "Food, beverages and tobacco";
                case GlobalEnums.Sector.Health: return "Health";
                case GlobalEnums.Sector.Horticulture: return "Horticulture";
                case GlobalEnums.Sector.Hotels: return "Hotels";
                case GlobalEnums.Sector.Ironandsteel: return "Iron and steel";
                case GlobalEnums.Sector.Localornationalgovernment: return "Local or national government";
                case GlobalEnums.Sector.Manufacturingandretail: return "Manufacturing and retail";
                case GlobalEnums.Sector.Mechanicalengineeringandmetalproducts: return "Mechanical engineering and metal products";
                case GlobalEnums.Sector.Mineralproductsegglasscementbricks: return "Mineral products (for example - glass, cement, bricks)";
                case GlobalEnums.Sector.Mixedcommunityheating: return "Mixed community heating";
                case GlobalEnums.Sector.Nonferrousmetals: return "Non-ferrous metals";
                case GlobalEnums.Sector.Offices: return "Offices";
                case GlobalEnums.Sector.Oilrefineries: return "Oil refineries";
                case GlobalEnums.Sector.Othercommerce: return "Other commerce";
                case GlobalEnums.Sector.Otherindustrialbranches: return "Other industrial branches";
                case GlobalEnums.Sector.Otherpublicadministration: return "Other public administration";
                case GlobalEnums.Sector.Paperpublishingandprinting: return "Paper, publishing and printing";
                case GlobalEnums.Sector.PostOffice: return "Post Office";
                case GlobalEnums.Sector.Privatehospitals: return "Private hospitals";
                case GlobalEnums.Sector.Publicsectorhousing: return "Public sector housing";
                case GlobalEnums.Sector.RoyalHousehold: return "Royal Household";
                case GlobalEnums.Sector.Scientificresearch: return "Scientific research";
                case GlobalEnums.Sector.Sewagetreatment: return "Sewage treatment";
                case GlobalEnums.Sector.Sportsandleisure: return "Sports and leisure";
                case GlobalEnums.Sector.Textilesclothingandfootwear: return "Textiles, clothing and footwear";
                case GlobalEnums.Sector.Timber: return "Timber";
                case GlobalEnums.Sector.Transport: return "Transport";
                case GlobalEnums.Sector.Vehicles: return "Vehicles";
                default
                    : return "Other";
            }
        }

        private GlobalEnums.Sector GetSectorEnum(string sector)
        {
            switch (sector)
            {
                case "Airports": return GlobalEnums.Sector.Airports;
                case "Chemical and pharmaceutical industry": return GlobalEnums.Sector.Chemicalandpharmaceuticalindustry;
                case "Construction": return GlobalEnums.Sector.Construction;
                case "Defence": return GlobalEnums.Sector.Defence;
                case "Education": return GlobalEnums.Sector.Education;
                case "Electrical and instrument engineering": return GlobalEnums.Sector.Electricalandinstrumentengineering;
                case "Extraction, mining and agglomeration": return GlobalEnums.Sector.Extractionminingandagglomeration;
                case "Food, beverages and tobacco": return GlobalEnums.Sector.Foodbeveragesandtobacco;
                case "Health": return GlobalEnums.Sector.Health;
                case "Horticulture": return GlobalEnums.Sector.Horticulture;
                case "Hotels": return GlobalEnums.Sector.Hotels;
                case "Iron and steel": return GlobalEnums.Sector.Ironandsteel;
                case "Local or national government": return GlobalEnums.Sector.Localornationalgovernment;
                case "Manufacturing and retail": return GlobalEnums.Sector.Manufacturingandretail;
                case "Mechanical engineering and metal products": return GlobalEnums.Sector.Mechanicalengineeringandmetalproducts;
                case "Mineral products (for example - glass, cement, bricks)": return GlobalEnums.Sector.Mineralproductsegglasscementbricks;
                case "Mixed community heating": return GlobalEnums.Sector.Mixedcommunityheating;
                case "Non-ferrous metals": return GlobalEnums.Sector.Nonferrousmetals;
                case "Offices": return GlobalEnums.Sector.Offices;
                case "Oil refineries": return GlobalEnums.Sector.Oilrefineries;
                case "Other commerce": return GlobalEnums.Sector.Othercommerce;
                case "Other industrial branches": return GlobalEnums.Sector.Otherindustrialbranches;
                case "Other public administration": return GlobalEnums.Sector.Otherpublicadministration;
                case "Paper, publishing and printing": return GlobalEnums.Sector.Paperpublishingandprinting;
                case "Post Office": return GlobalEnums.Sector.PostOffice;
                case "Private hospitals": return GlobalEnums.Sector.Privatehospitals;
                case "Public sector housing": return GlobalEnums.Sector.Publicsectorhousing;
                case "Royal Household": return GlobalEnums.Sector.RoyalHousehold;
                case "Scientific research": return GlobalEnums.Sector.Scientificresearch;
                case "Sewage treatment": return GlobalEnums.Sector.Sewagetreatment;
                case "Sports and leisure": return GlobalEnums.Sector.Sportsandleisure;
                case "Textiles, clothing and footwear": return GlobalEnums.Sector.Textilesclothingandfootwear;
                case "Timber": return GlobalEnums.Sector.Timber;
                case "Transport": return GlobalEnums.Sector.Transport;
                case "Vehicles": return GlobalEnums.Sector.Vehicles;
                default:
                    return GlobalEnums.Sector.Other;
            }
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
                            details = scheme.AdditionalInformation
                        },
                        details = new
                        {
                            sector = GetSectorString(scheme.Sector.Value).ToUpper(),
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
        public virtual IActionResult SubmissionRefPost([FromRoute(Name = "ref")][Required] string _ref, [FromBody][Required] dynamic scheme)
        {

            _telemetryClient.TrackEvent("Submission", new Dictionary<string, string>()
            {
                { "ref", _ref },
                { "scheme", scheme.ToString() }
            });

            (var serviceClient, var service) = GetService();

            try
            {
                var existingScheme = service.SchemeSet.FirstOrDefault(x => x.Ref == _ref);

                // Return not found if scheme not set
                if (existingScheme == null)
                {
                    return StatusCode(404, default(Error));
                }

                // Load related entities
                var relationships = existingScheme.RelationProperties.ToList();
                foreach (var relationship in relationships)
                {
                    service.LoadProperty(existingScheme, relationship.Key);
                }

                var submission = new Submission
                {
                    Ref = _ref,
                    SchemeRef = existingScheme.SchemeRef,
                    Scheme = existingScheme.SchemeId,
                    Company = existingScheme.Company.Value,
                    Site = existingScheme.Site.Value,

                    // Details (Sector, FuelBillFrequency)
                    Sector = GetSectorEnum(scheme.scheme.details.sector.ToString()),
                    FuelBillFrequency = scheme.scheme.details.fuelBillFrequency,

                    // Additional information
                    AdditionalInformation = scheme.scheme.additionalInformation.details
                };

                // Diagrams
                var diagrams = new List<Services.Diagram>();
                foreach (var diagram in scheme.scheme.details.diagrams)
                {
                    diagrams.Add(new Diagram
                    {
                        Name = diagram.ToString(),
                        Filename = diagram.ToString()
                    });
                }
                submission.DiagramsOfSubmission = diagrams.ToArray();

                // Prime movers
                var primeMovers = new List<Services.PrimeMover>();
                var primeMoverTypes = service.PrimeMoverTypeSet.ToList();
                var primeMoverFuels = service.FuelSet.ToList();
                var manufacturers = service.ManufacturerSet.ToList();
                var models = service.ModelSet.ToList();
                foreach (var primeMover in scheme.scheme.details.primeMovers)
                {
                    primeMovers.Add(new Services.PrimeMover()
                    {
                        TagNumber = primeMover.tagNumber,
                        Type = primeMoverTypes.FirstOrDefault(x => x.Name == primeMover.type.ToString())?.PrimeMoverTypeId,
                        Fuel = primeMoverFuels.FirstOrDefault(x => x.Name.ToLower() == primeMover.fuel.ToString().ToLower())?.FuelId,
                        Manufacturer = manufacturers.FirstOrDefault(x => x.Name == primeMover.manufacturer.ToString())?.ManufacturerId,
                        Model = models.FirstOrDefault(x => x.Name == primeMover.model.ToString())?.ModelId,
                        YearCommissioned = primeMover.yearCommissioned,
                        MaximumRatedHeat = primeMover.maximumRatedHeat,
                        MaximumRatedPower = primeMover.maximumRatedPower
                    });
                }
                submission.PrimeMoversOfSubmission = primeMovers.ToArray();

                // Boilers
                var boilers = new List<Services.Boiler>();
                var boilerTypes = service.BoilerTypeSet.ToList();
                foreach (var boiler in scheme.scheme.details.boilers)
                {
                    boilers.Add(new Services.Boiler()
                    {
                        TagNumber = boiler.tagNumber,
                        Details = boiler.details,
                        Type = boilerTypes.FirstOrDefault(x => x.Name == boiler.type.ToString())?.BoilerTypeId,
                        Manufacturer = manufacturers.FirstOrDefault(x => x.Name == boiler.manufacturer.ToString())?.ManufacturerId,
                        Model = models.FirstOrDefault(x => x.Name == boiler.model.ToString())?.ModelId,
                        YearCommissioned = boiler.yearCommissioned,
                        MaximumRatedHeat = boiler.maximumRatedHeat,
                        MaximumRatedPower = boiler.maximumRatedPower
                    });
                }
                submission.BoilersOfSubmission = boilers.ToArray();

                // Meters & readings
                var meters = new List<dynamic>();
                foreach (var meter in scheme.scheme.meters.fuelMeters)
                {
                    meter.meterType = GlobalEnums.MeterType.Fuel;
                }
                foreach (var meter in scheme.scheme.meters.electricityMeters)
                {
                    meter.meterType = GlobalEnums.MeterType.Electricity;
                }
                foreach (var meter in scheme.scheme.meters.heatMeters)
                {
                    meter.meterType = GlobalEnums.MeterType.Heat;
                }
                meters.AddRange(scheme.scheme.meters.fuelMeters);
                meters.AddRange(scheme.scheme.meters.electricityMeters);
                meters.AddRange(scheme.scheme.meters.heatMeters);

                var fuelCategories = service.FuelCategorySet.ToList();
                var fuelTypes = service.FuelTypeSet.ToList();

                var submissionMeters = new List<Services.Meter>();
                foreach (var meter in meters)
                {
                    var submissionMeter = new Services.Meter()
                    {
                        DiagramReferenceNumber = meter.diagramReferenceNumber,
                        MeterPointReference = meter.meterPointReference,
                        MeterType = meter.meterType,
                        ModelType = meter.modelType,
                        OutputsRange = meter.outputsRange,
                        OutputsUnit = meter.outputsUnit,
                        SerialNumber = meter.serialNumber,
                        Tag = meter.tag,
                        YearInstalled = meter.yearInstalled,
                        Uncertainty = meter.uncertainty
                    };
                    // Readings
                    if (meter.reading != null)
                    {
                        var meterReading = new MeterReadings();
                        meterReading.SubmissionAsSubmission = submission;

                        if (meter.reading.fuelCategory != null)
                        {
                            var fuelCategoryName = meter.reading.fuelCategory.ToString().ToLower();
                            var fuelTypeName = meter.reading.fuelType.ToString().ToLower();
                            var fuelCategory = fuelCategories.FirstOrDefault(x => x.Name.ToLower() == fuelCategoryName);
                            var fuelType = fuelTypes.FirstOrDefault(x => x.Name.ToLower() == fuelTypeName);
                            meterReading.FuelCategory = fuelCategory.FuelCategoryId;
                            meterReading.FuelType = fuelType.FuelTypeId;
                        }

                        meterReading.HaveUsedCalculations = meter.reading.haveUsedCalculations;
                        var meterReadingValues = new List<MeterReadingValue>();
                        foreach (var reading in meter.reading.values)
                        {
                            var readingValue = new MeterReadingValue
                            {
                                Value = reading.value,
                                Month = reading.month,
                                MonthName = reading.month,
                                SubmissionAsSubmission = submission
                            };
                            meterReadingValues.Add(readingValue);
                        }
                        meterReading.MeterReadingValuesOfMeterReading = meterReadingValues.ToArray();
                        var meterReadings = new List<MeterReadings>() { meterReading };
                        submissionMeter.MeterReadingssOfMeter = meterReadings.ToArray();
                    }
                    submissionMeters.Add(submissionMeter);
                }
                submission.MetersOfSubmission = submissionMeters.ToArray();

                service.AddObject(submission);
                service.SaveChanges();

                return new ObjectResult(submission);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
                throw;
            }
        }
    }
}
