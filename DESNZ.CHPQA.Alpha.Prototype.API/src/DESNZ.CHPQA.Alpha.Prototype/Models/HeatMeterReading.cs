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
    public partial class HeatMeterReading : IEquatable<HeatMeterReading>
    {
        /// <summary>
        /// Gets or Sets HeatType
        /// </summary>
        [DataMember(Name="heatType", EmitDefaultValue=false)]
        public string HeatType { get; set; }

        /// <summary>
        /// Gets or Sets HaveUsedCalculations
        /// </summary>
        [DataMember(Name="haveUsedCalculations", EmitDefaultValue=true)]
        public bool HaveUsedCalculations { get; set; }

        /// <summary>
        /// Gets or Sets Values
        /// </summary>
        [DataMember(Name="values", EmitDefaultValue=false)]
        public List<MeterReading> Values { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class HeatMeterReading {\n");
            sb.Append("  HeatType: ").Append(HeatType).Append("\n");
            sb.Append("  HaveUsedCalculations: ").Append(HaveUsedCalculations).Append("\n");
            sb.Append("  Values: ").Append(Values).Append("\n");
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
            return obj.GetType() == GetType() && Equals((HeatMeterReading)obj);
        }

        /// <summary>
        /// Returns true if HeatMeterReading instances are equal
        /// </summary>
        /// <param name="other">Instance of HeatMeterReading to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(HeatMeterReading other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    HeatType == other.HeatType ||
                    HeatType != null &&
                    HeatType.Equals(other.HeatType)
                ) && 
                (
                    HaveUsedCalculations == other.HaveUsedCalculations ||
                    
                    HaveUsedCalculations.Equals(other.HaveUsedCalculations)
                ) && 
                (
                    Values == other.Values ||
                    Values != null &&
                    other.Values != null &&
                    Values.SequenceEqual(other.Values)
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
                    if (HeatType != null)
                    hashCode = hashCode * 59 + HeatType.GetHashCode();
                    
                    hashCode = hashCode * 59 + HaveUsedCalculations.GetHashCode();
                    if (Values != null)
                    hashCode = hashCode * 59 + Values.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(HeatMeterReading left, HeatMeterReading right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(HeatMeterReading left, HeatMeterReading right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
