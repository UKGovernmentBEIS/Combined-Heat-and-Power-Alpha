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
    public partial class Boiler : IEquatable<Boiler>
    {
        /// <summary>
        /// Gets or Sets TagNumber
        /// </summary>
        [Required]
        [DataMember(Name="tagNumber", EmitDefaultValue=true)]
        public decimal TagNumber { get; set; }

        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [Required]
        [DataMember(Name="type", EmitDefaultValue=false)]
        public string Type { get; set; }

        /// <summary>
        /// Gets or Sets Details
        /// </summary>
        [Required]
        [DataMember(Name="details", EmitDefaultValue=false)]
        public string Details { get; set; }

        /// <summary>
        /// Gets or Sets Manufacturer
        /// </summary>
        [Required]
        [DataMember(Name="manufacturer", EmitDefaultValue=false)]
        public string Manufacturer { get; set; }

        /// <summary>
        /// Gets or Sets Model
        /// </summary>
        [Required]
        [DataMember(Name="model", EmitDefaultValue=false)]
        public string Model { get; set; }

        /// <summary>
        /// Gets or Sets YearCommissioned
        /// </summary>
        [Required]
        [DataMember(Name="yearCommissioned", EmitDefaultValue=true)]
        public decimal YearCommissioned { get; set; }

        /// <summary>
        /// Gets or Sets MaximumRatedHeat
        /// </summary>
        [Required]
        [DataMember(Name="maximumRatedHeat", EmitDefaultValue=false)]
        public string MaximumRatedHeat { get; set; }

        /// <summary>
        /// Gets or Sets MaximumRatedPower
        /// </summary>
        [Required]
        [DataMember(Name="maximumRatedPower", EmitDefaultValue=false)]
        public string MaximumRatedPower { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Boiler {\n");
            sb.Append("  TagNumber: ").Append(TagNumber).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Details: ").Append(Details).Append("\n");
            sb.Append("  Manufacturer: ").Append(Manufacturer).Append("\n");
            sb.Append("  Model: ").Append(Model).Append("\n");
            sb.Append("  YearCommissioned: ").Append(YearCommissioned).Append("\n");
            sb.Append("  MaximumRatedHeat: ").Append(MaximumRatedHeat).Append("\n");
            sb.Append("  MaximumRatedPower: ").Append(MaximumRatedPower).Append("\n");
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
            return obj.GetType() == GetType() && Equals((Boiler)obj);
        }

        /// <summary>
        /// Returns true if Boiler instances are equal
        /// </summary>
        /// <param name="other">Instance of Boiler to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Boiler other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    TagNumber == other.TagNumber ||
                    
                    TagNumber.Equals(other.TagNumber)
                ) && 
                (
                    Type == other.Type ||
                    Type != null &&
                    Type.Equals(other.Type)
                ) && 
                (
                    Details == other.Details ||
                    Details != null &&
                    Details.Equals(other.Details)
                ) && 
                (
                    Manufacturer == other.Manufacturer ||
                    Manufacturer != null &&
                    Manufacturer.Equals(other.Manufacturer)
                ) && 
                (
                    Model == other.Model ||
                    Model != null &&
                    Model.Equals(other.Model)
                ) && 
                (
                    YearCommissioned == other.YearCommissioned ||
                    
                    YearCommissioned.Equals(other.YearCommissioned)
                ) && 
                (
                    MaximumRatedHeat == other.MaximumRatedHeat ||
                    MaximumRatedHeat != null &&
                    MaximumRatedHeat.Equals(other.MaximumRatedHeat)
                ) && 
                (
                    MaximumRatedPower == other.MaximumRatedPower ||
                    MaximumRatedPower != null &&
                    MaximumRatedPower.Equals(other.MaximumRatedPower)
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
                    
                    hashCode = hashCode * 59 + TagNumber.GetHashCode();
                    if (Type != null)
                    hashCode = hashCode * 59 + Type.GetHashCode();
                    if (Details != null)
                    hashCode = hashCode * 59 + Details.GetHashCode();
                    if (Manufacturer != null)
                    hashCode = hashCode * 59 + Manufacturer.GetHashCode();
                    if (Model != null)
                    hashCode = hashCode * 59 + Model.GetHashCode();
                    
                    hashCode = hashCode * 59 + YearCommissioned.GetHashCode();
                    if (MaximumRatedHeat != null)
                    hashCode = hashCode * 59 + MaximumRatedHeat.GetHashCode();
                    if (MaximumRatedPower != null)
                    hashCode = hashCode * 59 + MaximumRatedPower.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(Boiler left, Boiler right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Boiler left, Boiler right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
