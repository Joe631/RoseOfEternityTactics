using UnityEngine;
using System.Text;
using System.Collections.Generic;

public class Inventory {
	private List<Item> _items = new List<Item> ();

	/// <summary>
	/// Returns a deep copied instance.
	/// </summary>
	/// <returns>The copy.</returns>
	public Inventory DeepCopy() {
		Inventory deepCopy = new Inventory ();
		foreach (var item in _items)
			deepCopy.Add (item.DeepCopy());
		return deepCopy;
	}

	/// <summary>
	/// Gets the items.
	/// </summary>
	/// <value>The items.</value>
	public List<Item> Items { get { return _items; } }

	/// <summary>
	/// Add the specified item.
	/// </summary>
	/// <param name="item">Item.</param>
	public void Add(Item item) {
		_items.Add (item);
	}

	/// <summary>
	/// Remove the specified item.
	/// </summary>
	/// <param name="item">Item.</param>
	public void Remove(Item item) {
		if (_items.Contains (item))
			_items [_items.IndexOf (item)] = null;
	}

	/// <summary>
	/// Gets the item by id.
	/// </summary>
	/// <returns>The by identifier.</returns>
	/// <param name="id">Identifier.</param>
	public Item GetById(int id) {
		foreach (Item item in _items)
			if (item.Id == id)
				return item;
		return null;
	}

	/// <summary>
	/// Gets the first item by name.
	/// </summary>
	/// <returns>The first item by name.</returns>
	/// <param name="name">Name.</param>
	public Item GetFirstItemByName(string name) {
		foreach (Item item in _items)
			if (item.Name == name)
				return item;
		return null;
	}

	/// <summary>
	/// Gets list of items by name.
	/// </summary>
	/// <returns>The items by name.</returns>
	/// <param name="name">Name.</param>
	public List<Item> GetItemsByName(string name) {
		List<Item> items = new List<Item> ();

		foreach (Item item in _items)
			if (item.Name == name)
				items.Add (item);

		return items;
	}

	/// <summary>
	/// Insert the specified item at the index.
	/// If index doesn't exist, it just gets added to the end of the collection.
	/// </summary>
	/// <param name="item">Item.</param>
	/// <param name="index">Index.</param>
	public void Upsert(Item item, int index) {
		if (index + 1 > _items.Count)
			Add (item);
		else
			_items [index] = item;
	}

	/// <summary>
	/// Get the item by index.
	/// </summary>
	/// <param name="index">Index.</param>
	public Item Get(int index) {
		return _items [index];
	}

	/// <summary>
	/// Number of items in the inventory (disregards "null")
	/// </summary>
	public int Count() {
		int count = 0;
		foreach (Item item in _items) {
			if (item != null)
				count++;
		}
		return count;
	}

	/// <summary>
	/// Returns a <see cref="System.String"/> that represents the current <see cref="Inventory"/>.
	/// </summary>
	/// <returns>A <see cref="System.String"/> that represents the current <see cref="Inventory"/>.</returns>
	public override string ToString ()
	{
		StringBuilder sb = new StringBuilder ();
		foreach (Item item in _items) {
			string s = "[NO ITEM]";
			if (item != null)
				s = string.Format("[{0}]", item.Name);
			sb.Append (s);
		}
		return sb.ToString ();		
	}
}