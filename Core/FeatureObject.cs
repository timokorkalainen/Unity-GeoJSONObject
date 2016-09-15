using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GeoJSON {
	
	[System.Serializable]
	public class FeatureObject {
	
		public string type;
		public GeometryObject geometry;
		public Dictionary<string, string> properties;

		public FeatureObject(JSONObject jsonObject) {
			type = jsonObject ["type"].str;
			geometry = parseGeometry (jsonObject ["geometry"]);

			properties = new Dictionary<string, string> ();
			parseProperties (jsonObject ["properties"]);
		}
		public FeatureObject(string encodedString) {
			JSONObject jsonObject = new JSONObject (encodedString);
			type = jsonObject ["type"].str;
			geometry = parseGeometry (jsonObject ["geometry"]);

			properties = new Dictionary<string, string> ();
			parseProperties (jsonObject ["properties"]);
		}

		protected void parseProperties(JSONObject jsonObject) {
			for(int i = 0; i < jsonObject.list.Count; i++){
				string key = (string)jsonObject.keys[i];
				JSONObject value = (JSONObject)jsonObject.list[i];
				properties.Add (key, value.str);
			}			
		}

		protected GeometryObject parseGeometry(JSONObject jsonObject){
			switch (jsonObject["type"].str) {
			case "Point":
				return new PointGeometryObject (jsonObject);
			case "MultiPoint":
				return new MultiPointGeometryObject (jsonObject);
			case "LineString":
				return new LineStringGeometryObject (jsonObject);
			case "MultiLineString":
				return new MultiLineStringGeometryObject (jsonObject);
			case "Polygon":
				return new PolygonGeometryObject (jsonObject);
			case "MultiPolygon":
				return new MultiPolygonGeometryObject (jsonObject);
			default:
				break;
			}
			return null;
		}

	}
}
