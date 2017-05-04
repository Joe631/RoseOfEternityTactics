using UnityEngine;
using System.Collections.Generic;
using System.Text;

public class InventorySlots  {

	/// <summary>
	/// All available slots.
	/// </summary>
	public enum SlotType {
		ANY,
		RIGHT_HAND,
		LEFT_HAND,
		HEAD,
		BODY,
		FEET,
		HANDS,
		BACK,
		RING_1,
		RING_2,
		AMULET,
		CONSUMABLE,
		MONSTER,
	}

	private Dictionary<SlotType, Item> _items = new Dictionary<SlotType, Item>();

	/// <summary>
	/// Add the item to the specified slot.
	/// Slot will be inferred from the item.
	/// </summary>
	/// <param name="item">Item.</param>
	public void Add(Item item) {

		// Get inventory slot from item
		InventorySlots.SlotType slotType = item.SlotType;
		if (_items.ContainsKey (slotType)) {

			// Remove currently equipped item
			Remove (slotType);
		}

		// Add item to slot
		Add(slotType, item);
	}

	/// <summary>
	/// Add the item to the specified slot.
	/// </summary>
	/// <param name="slotType">Slot type.</param>
	/// <param name="item">Item.</param>
	public void Add(InventorySlots.SlotType slotType, Item item) {
		_items.Add(slotType, item);
	}

	/// <summary>
	/// Remove the item from the specified slot.
	/// </summary>
	/// <param name="slotType">Slot.</param>
	public Item Remove(SlotType slotType) {
		if (_items.ContainsKey(slotType)) {

			// Remove item from item slot
			Item item = _items[slotType];
			_items.Remove (slotType);

			return item;
		}
		return null;
	}

	/// <summary>
	/// Get an item by the specified slot.
	/// </summary>
	/// <param name="slotType">Slot.</param>
	public Item Get(SlotType slotType) {
		if (_items.ContainsKey (slotType))
			return _items [slotType];
		return null;
	}

	/// <summary>
	/// Gets the inventory slots.
	/// </summary>
	/// <returns>The inventory slots.</returns>
	public Dictionary<SlotType, Item> GetInventorySlots() {
		return _items;
	}

	/// <summary>
	/// Returns a <see cref="System.String"/> that represents the current <see cref="InventorySlots"/>.
	/// </summary>
	/// <returns>A <see cref="System.String"/> that represents the current <see cref="InventorySlots"/>.</returns>
	public override string ToString ()
	{
		StringBuilder sb = new StringBuilder ();
		foreach (Item item in _items.Values)
			sb.Append (item.ToString ());
		return sb.ToString ();
	}
}