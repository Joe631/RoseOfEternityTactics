using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections;

namespace RoseOfEternity {
	
	public class Attribute {

		private float _currentValue;

		/// <summary>
		/// Initializes a new instance of the <see cref="RoseOfEternity.Attribute"/> class.
		/// </summary>
		/// <param name="type">Type.</param>
		/// <param name="name">Name.</param>
		/// <param name="shortName">Short name.</param>
		/// <param name="toolTip">Tool tip.</param>
		/// <param name="currentValue">Current value.</param>
		/// <param name="minimumValue">Minimum value.</param>
		/// <param name="maximumValue">Maximum value.</param>
		public Attribute(AttributeEnums.AttributeType type, string name, string shortName, string toolTip, float currentValue, float minimumValue, float maximumValue) {
			Type = type;
			Name = name;
			ShortName = shortName;
			ToolTip = toolTip;
			MinimumValue = minimumValue;
			MaximumValue = maximumValue;
			_currentValue = currentValue;
		}

		// Properties
		[JsonConverter(typeof(StringEnumConverter))] public AttributeEnums.AttributeType Type { get; private set; }
		public string Name { get; private set; }
		public string ShortName { get; private set; }
		public string ToolTip { get; private set; }
		public float MinimumValue { get; private set; }
		public float MaximumValue { get; set; }

		/// <summary>
		/// Gets or sets the current value. When setting, value will be clamped to the min/max.
		/// </summary>
		/// <value>The current value.</value>
		[JsonIgnore] public float CurrentValue { get { return _currentValue; } set { _currentValue = Mathf.Clamp (value, MinimumValue, MaximumValue); }}

		/// <summary>
		/// Returns a deep copied instance.
		/// </summary>
		/// <returns>The copy.</returns>
		public Attribute DeepCopy() {
			return new Attribute (Type, Name, ShortName, ToolTip, CurrentValue, MinimumValue, MaximumValue);
		}

		/// <summary>
		/// Increment the current value.
		/// </summary>
		/// <param name="incrementValue">Increment value.</param>
		public void Increment(float incrementValue) {
			CurrentValue += incrementValue;
		}

		/// <summary>
		/// Decrement the current value.
		/// </summary>
		/// <param name="decrementValue">Decrement value.</param>
		public void Decrement(float decrementValue) {
			CurrentValue -= decrementValue;
		}

		/// <summary>
		/// Returns a <see cref="System.String"/> that represents the current <see cref="RoseOfEternity.Attribute"/>.
		/// </summary>
		/// <returns>A <see cref="System.String"/> that represents the current <see cref="RoseOfEternity.Attribute"/>.</returns>
		public override string ToString ()
		{
			return string.Format ("[Attribute: Name={0}, ShortName={1}, ToolTip={2}, MinimumValue={3}, MaximumValue={4}, CurrentValue={5}]", Name, ShortName, ToolTip, MinimumValue, MaximumValue, CurrentValue);
		}
	}
}