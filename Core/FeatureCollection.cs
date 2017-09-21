using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace GeoJSON {
	
	[System.Serializable]
	public class FeatureCollection : GeoJSONObject {

		public List<FeatureObject>features;

		public FeatureCollection(string encodedString) {
			features = new List<FeatureObject>();

			JSONObject jsonObject = new JSONObject(encodedString);

			ParseFeatures (jsonObject ["features"]);
			type = "FeatureCollection";
		}

		public FeatureCollection(JSONObject jsonObject) : base (jsonObject) {
			features = new List<FeatureObject>();

			ParseFeatures (jsonObject ["features"]);
		}

		public FeatureCollection() {
			features = new List<FeatureObject>();
			type = "FeatureCollection";
		}

		protected void ParseFeatures(JSONObject jsonObject) {
			foreach (JSONObject featureObject in jsonObject.list) {
				features.Add (new FeatureObject (featureObject));
			}
		}

		override protected void SerializeContent(JSONObject rootObject) {

			JSONObject jsonFeatures = new JSONObject(JSONObject.Type.ARRAY);
			foreach(FeatureObject feature in features) {
				jsonFeatures.Add (feature.Serialize ());
			}
			rootObject.AddField ("features", jsonFeatures);
		}

	}
}
