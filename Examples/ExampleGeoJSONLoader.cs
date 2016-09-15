using UnityEngine;
using System.Collections;

public class ExampleGeoJSONLoader : MonoBehaviour {

	public TextAsset encodedGeoJSON;

	public GeoJSON.FeatureCollection collection;

	// Use this for initialization
	void Start () {
	}

	void OnGUI() {
		if (encodedGeoJSON != null) {
			if (GUI.Button (new Rect (0, 0, 200, 200), "Load GeoJSON"))
				collection = GeoJSON.GeoJSONObject.ParseAsCollection (encodedGeoJSON.text);
		}
	}
}
