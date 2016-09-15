using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GeoJSON {

	public class GeoJSONObject {

		public string type;

		public GeoJSONObject(JSONObject jsonObject) {
			type = jsonObject ["type"].str;
		}

		public GeoJSONObject() {
		}

		static public FeatureCollection ParseAsCollection(string encodedString) {
			FeatureCollection collection;

			JSONObject jsonObject = new JSONObject (encodedString);
			if (jsonObject ["type"].str == "FeatureCollection") {
				collection = new GeoJSON.FeatureCollection (jsonObject);
			} else {
				collection = new GeoJSON.FeatureCollection ();
				collection.features.Add (new GeoJSON.FeatureObject (jsonObject));
			}

			return collection;
		}
	}
}