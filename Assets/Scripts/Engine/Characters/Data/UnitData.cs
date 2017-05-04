using UnityEngine;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RoseOfEternity;

public class UnitData {
	[JsonProperty] public string ResRef { get; set; }
	[JsonProperty] public string FirstName { get; set; }
	[JsonProperty] public string LastName { get; set; }
	[JsonProperty] public string Class { get; set; }
	[JsonProperty] public string PortraintLocation { get; set; }

	[JsonProperty] public Dictionary<AttributeEnums.AttributeType, float> Attributes {
		get {
			var attributeCurrentValues = new Dictionary<AttributeEnums.AttributeType, float> ();
			foreach (var item in AttributeCollection.GetAttributes())
				attributeCurrentValues.Add (item.Key, item.Value.CurrentValue);
			return attributeCurrentValues;
		}
	}
	[JsonProperty] public Dictionary<InventorySlots.SlotType, int> Inventory {
		get {
			var itemsInSlots = new Dictionary<InventorySlots.SlotType, int> ();
			foreach (var item in InventorySlots.GetInventorySlots())
				itemsInSlots.Add (item.Key, item.Value.Id);
			return itemsInSlots;
		}
	}

	[JsonIgnore] public AttributeCollection AttributeCollection { get; set; }
	[JsonIgnore] public InventorySlots InventorySlots { get; set; }

	/// <summary>
	/// Initializes a new instance of the <see cref="UnitData"/> class.
	/// </summary>
	public UnitData() {}

	public UnitData DeepCopy() {
		return new UnitData (ResRef, FirstName, LastName, Class, PortraintLocation, Attributes, Inventory);
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="UnitData"/> class.
	/// </summary>
	/// <param name="resRef">Resource reference.</param>
	/// <param name="firstName">First name.</param>
	/// <param name="lastName">Last name.</param>
	/// <param name="class">Class.</param>
	/// <param name="portraitLocation">Portrait location.</param>
	/// <param name="attributes">Attributes.</param>
	/// <param name="inventorySlots">Inventory slots.</param>
	[JsonConstructor]
	private UnitData(string resRef, string firstName, string lastName, string @class, string portraitLocation, Dictionary<AttributeEnums.AttributeType, float> attributes, Dictionary<InventorySlots.SlotType, int> inventory) {
		ResRef = resRef;
		FirstName = firstName;
		LastName = lastName;
		Class = @class;
		PortraintLocation = portraitLocation;

		// Set attributes in their collection. If attribute already exists, set value,
		// else, grab from global collection and set new attribute and value
		AttributeCollection globalAttributeCollection = AttributeManager.Instance.GlobalAttributeCollection;
		if (AttributeCollection == null)
			AttributeCollection = new AttributeCollection ();
		foreach (var item in attributes) {
			AttributeEnums.AttributeType type = item.Key;
			Attribute attribute;
			if (!AttributeCollection.HasType (type)) {
				attribute = globalAttributeCollection.Get (type).DeepCopy ();
				AttributeCollection.Add (type, attribute);
			} 
			else
				attribute = AttributeCollection.Get (type);
			attribute.CurrentValue = item.Value;
		}

		// Create inventory slots for unit
		InventorySlots = new InventorySlots();
		foreach (var inventorySlot in inventory) {

			// Get item from global inventory
			Item item = ItemManager.Instance.GlobalInventory.GetById(inventorySlot.Value).DeepCopy();
			InventorySlots.Add (inventorySlot.Key, item);
		}					
	}

	/// <summary>
	/// Returns a <see cref="System.String"/> that represents the current <see cref="UnitData"/>.
	/// </summary>
	/// <returns>A <see cref="System.String"/> that represents the current <see cref="UnitData"/>.</returns>
	public override string ToString ()
	{
		return string.Format ("[UnitData: FirstName={0}, LastName={1}, Class={2}, PortraintLocation={3}, AttributeCollection={4}, InventorySlots={5}]", FirstName, LastName, Class, PortraintLocation, AttributeCollection, InventorySlots);
	}
}