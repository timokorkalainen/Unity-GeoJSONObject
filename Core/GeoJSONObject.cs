using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GeoJSON {

	public class GeoJSONObject {

		public string type;

		public GeoJSONObject() {
		}

		public GeoJSONObject(JSONObject jsonObject) {
			if(jsonObject != null)
				type = jsonObject ["type"].str;
		}

		//Will always return a FeatureCollection...
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