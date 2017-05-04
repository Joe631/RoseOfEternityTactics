using UnityEngine;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using RoseOfEternity;

public class UnitDataManager : MonoBehaviour {

	private const string ITEM_DATA_FILE = "Data/units.json";

	private static UnitDataManager _instance;

	/// <summary>
	/// Gets the instance.
	/// </summary>
	/// <value>The instance.</value>
	public static UnitDataManager Instance { get { return _instance; } }

	/// <summary>
	/// Gets the global unit data collection.
	/// </summary>
	/// <value>The global unit data collection.</value>
	public UnitDataCollection GlobalUnitDataCollection { get; private set; }

	/// <summary>
	/// Awake this instance and destroy duplicates.
	/// </summary>
	void Awake() {
		print ("UnitDataManager.Awake()");
		if (_instance == null) {
			string path = Path.Combine (Application.streamingAssetsPath, ITEM_DATA_FILE);
			string data = File.ReadAllText (path);

			GlobalUnitDataCollection = JsonConvert.DeserializeObject<UnitDataCollection> (data);
			_instance = this;
		}
		else if (_instance != this)
			Destroy (this.gameObject);
		DontDestroyOnLoad (this.gameObject);
	}
}