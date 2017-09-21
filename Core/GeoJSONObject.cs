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

		static public FeatureCollection Deserialize(string encodedString) {
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

		virtual public JSONObject Serialize () {

			JSONObject rootObject = new JSONObject (JSONObject.Type.OBJECT);
			rootObject.AddField ("type", type);

			SerializeContent (rootObject);

			return rootObject;
		}

		protected virtual void SerializeContent(JSONObject rootObject) {}
	}
}