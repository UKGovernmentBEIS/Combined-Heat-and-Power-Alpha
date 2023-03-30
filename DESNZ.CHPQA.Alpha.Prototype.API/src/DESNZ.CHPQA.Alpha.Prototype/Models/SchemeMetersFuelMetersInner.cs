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
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using DESNZ.CHPQA.Alpha.Prototype.Converters;

namespace DESNZ.CHPQA.Alpha.Prototype.Models
{ 
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class SchemeMetersFuelMetersInner : IEquatable<SchemeMetersFuelMetersInner>
    {
        /// <summary>
        /// Gets or Sets Tag
        /// </summary>
        [Required]
        [DataMember(Name="tag", EmitDefaultValue=false)]
        public string Tag { get; set; }

        /// <summary>
        /// Gets or Sets DiagramReferenceNumber
        /// </summary>
        [Required]
        [DataMember(Name="diagramReferenceNumber", EmitDefaultValue=false)]
        public string DiagramReferenceNumber { get; set; }

        /// <summary>
        /// Gets or Sets YearInstalled
        /// </summary>
        [Required]
        [DataMember(Name="yearInstalled", EmitDefaultValue=true)]
        public decimal YearInstalled { get; set; }

        /// <summary>
        /// Gets or Sets OutputsRange
        /// </summary>
        [Required]
        [DataMember(Name="outputsRange", EmitDefaultValue=false)]
        public string OutputsRange { get; set; }

        /// <summary>
        /// Gets or Sets OutputsUnit
        /// </summary>
        [Required]
        [DataMember(Name="outputsUnit", EmitDefaultValue=false)]
        public string OutputsUnit { get; set; }

        /// <summary>
        /// Gets or Sets ModelType
        /// </summary>
        [Required]
        [DataMember(Name="modelType", EmitDefaultValue=false)]
        public string ModelType { get; set; }

        /// <summary>
        /// Gets or Sets Uncertainty
        /// </summary>
        [Required]
        [DataMember(Name="uncertainty", EmitDefaultValue=true)]
        public decimal Uncertainty { get; set; }

        /// <summary>
        /// Gets or Sets MeterPointReference
        /// </summary>
        [DataMember(Name="meterPointReference", EmitDefaultValue=false)]
        public string MeterPointReference { get; set; }

        /// <summary>
        /// Gets or Sets SerialNumber
        /// </summary>
        [Required]
        [DataMember(Name="serialNumber", EmitDefaultValue=false)]
        public string SerialNumber { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SchemeMetersFuelMetersInner {\n");
            sb.Append("  Tag: ").Append(Tag).Append("\n");
            sb.Append("  DiagramReferenceNumber: ").Append(DiagramReferenceNumber).Append("\n");
            sb.Append("  YearInstalled: ").Append(YearInstalled).Append("\n");
            sb.Append("  OutputsRange: ").Append(OutputsRange).Append("\n");
            sb.Append("  OutputsUnit: ").Append(OutputsUnit).Append("\n");
            sb.Append("  ModelType: ").Append(ModelType).Append("\n");
            sb.Append("  Uncertainty: ").Append(Uncertainty).Append("\n");
            sb.Append("  MeterPointReference: ").Append(MeterPointReference).Append("\n");
            sb.Append("  SerialNumber: ").Append(SerialNumber).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((SchemeMetersFuelMetersInner)obj);
        }

        /// <summary>
        /// Returns true if SchemeMetersFuelMetersInner instances are equal
        /// </summary>
        /// <param name="other">Instance of SchemeMetersFuelMetersInner to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SchemeMetersFuelMetersInner other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    Tag == other.Tag ||
                    Tag != null &&
                    Tag.Equals(other.Tag)
                ) && 
                (
                    DiagramReferenceNumber == other.DiagramReferenceNumber ||
                    DiagramReferenceNumber != null &&
                    DiagramReferenceNumber.Equals(other.DiagramReferenceNumber)
                ) && 
                (
                    YearInstalled == other.YearInstalled ||
                    
                    YearInstalled.Equals(other.YearInstalled)
                ) && 
                (
                    OutputsRange == other.OutputsRange ||
                    OutputsRange != null &&
                    OutputsRange.Equals(other.OutputsRange)
                ) && 
                (
                    OutputsUnit == other.OutputsUnit ||
                    OutputsUnit != null &&
                    OutputsUnit.Equals(other.OutputsUnit)
                ) && 
                (
                    ModelType == other.ModelType ||
                    ModelType != null &&
                    ModelType.Equals(other.ModelType)
                ) && 
                (
                    Uncertainty == other.Uncertainty ||
                    
                    Uncertainty.Equals(other.Uncertainty)
                ) && 
                (
                    MeterPointReference == other.MeterPointReference ||
                    MeterPointReference != null &&
                    MeterPointReference.Equals(other.MeterPointReference)
                ) && 
                (
                    SerialNumber == other.SerialNumber ||
                    SerialNumber != null &&
                    SerialNumber.Equals(other.SerialNumber)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                // Suitable nullity checks etc, of course :)
                    if (Tag != null)
                    hashCode = hashCode * 59 + Tag.GetHashCode();
                    if (DiagramReferenceNumber != null)
                    hashCode = hashCode * 59 + DiagramReferenceNumber.GetHashCode();
                    
                    hashCode = hashCode * 59 + YearInstalled.GetHashCode();
                    if (OutputsRange != null)
                    hashCode = hashCode * 59 + OutputsRange.GetHashCode();
                    if (OutputsUnit != null)
                    hashCode = hashCode * 59 + OutputsUnit.GetHashCode();
                    if (ModelType != null)
                    hashCode = hashCode * 59 + ModelType.GetHashCode();
                    
                    hashCode = hashCode * 59 + Uncertainty.GetHashCode();
                    if (MeterPointReference != null)
                    hashCode = hashCode * 59 + MeterPointReference.GetHashCode();
                    if (SerialNumber != null)
                    hashCode = hashCode * 59 + SerialNumber.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(SchemeMetersFuelMetersInner left, SchemeMetersFuelMetersInner right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SchemeMetersFuelMetersInner left, SchemeMetersFuelMetersInner right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
