using UnityEngine;
using System.Text;
using System.Collections.Generic;

public class UnitDataCollection {
	private List<UnitData> _units = new List<UnitData> ();

	public List<UnitData> Units { get { return _units; } }

	/// <summary>
	/// Gets the by res reference.
	/// </summary>
	/// <returns>The by res reference.</returns>
	/// <param name="resRef">Res reference.</param>
	public UnitData GetByResRef(string resRef) {
		foreach (UnitData unitData in _units)
			if (unitData.ResRef == resRef)
				return unitData;
		return null;
	}

	/// <summary>
	/// Returns a <see cref="System.String"/> that represents the current <see cref="UnitDataCollection"/>.
	/// </summary>
	/// <returns>A <see cref="System.String"/> that represents the current <see cref="UnitDataCollection"/>.</returns>
	public override string ToString ()
	{
		StringBuilder sb = new StringBuilder ();
		foreach (var unit in _units) {
			string s = "[NO UNIT]";
			if (unit != null)
				s = string.Format("[{0}]", unit);
			sb.Append (s);
		}
		return sb.ToString ();				
	}	
}