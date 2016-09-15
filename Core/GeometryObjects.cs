using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GeoJSON {

	[System.Serializable]
	public class GeometryObject : GeoJSONObject {

		public GeometryObject(JSONObject jsonObject) : base(jsonObject) {
		}

		virtual public List<PositionObject> AllPositions() {
			return new List<PositionObject>();
		}
	}

	[System.Serializable]
	public class SingleGeometryObject : GeometryObject {
		public PositionObject coordinates;

		public SingleGeometryObject(JSONObject jsonObject) : base(jsonObject) {
			coordinates = new PositionObject (jsonObject["coordinates"]);
		}

		override public List<PositionObject> AllPositions() {
			List<PositionObject> list = new List<PositionObject> ();
			list.Add (coordinates);
			return list;
		}
	}
	[System.Serializable]
	public class ArrayGeometryObject : GeometryObject {
		public List<PositionObject> coordinates;

		public ArrayGeometryObject(JSONObject jsonObject) : base(jsonObject) {
			coordinates = new List<PositionObject>();
			foreach(JSONObject j in jsonObject["coordinates"].list){
				coordinates.Add(new PositionObject (j));
			}
		}

		override public List<PositionObject> AllPositions() {
			return coordinates;
		}
	}
	[System.Serializable]
	public class ArrayArrayGeometryObject : GeometryObject {
		public List<List<PositionObject>> coordinates;

		public ArrayArrayGeometryObject(JSONObject jsonObject) : base(jsonObject) {

			coordinates = new List<List<PositionObject>> ();
			foreach (JSONObject l in jsonObject["coordinates"].list) {
				List<PositionObject> polygon = new List<PositionObject>();
				coordinates.Add (polygon);
				foreach (JSONObject l2 in l.list) {
					polygon.Add (new PositionObject (l2));
				}
			}
		}

		override public List<PositionObject> AllPositions() {
			List<PositionObject> list = new List<PositionObject> ();
			foreach (List<PositionObject> l in coordinates) {
				foreach (PositionObject pos in l) {
					list.Add (pos);
				}
			}
			return list;
		}
	}

	[System.Serializable]
	public class PointGeometryObject : SingleGeometryObject {
		public PointGeometryObject(JSONObject jsonObject) : base(jsonObject) {
		}
	}
	[System.Serializable]
	public class MultiPointGeometryObject : ArrayGeometryObject {
		public MultiPointGeometryObject(JSONObject jsonObject) : base(jsonObject) {
		}
	}

	[System.Serializable]
	public class LineStringGeometryObject : ArrayGeometryObject {
		public LineStringGeometryObject(JSONObject jsonObject) : base(jsonObject) {
		}
	}
	[System.Serializable]
	public class MultiLineStringGeometryObject : ArrayArrayGeometryObject {
		public MultiLineStringGeometryObject(JSONObject jsonObject) : base(jsonObject) {
		}
	}

	[System.Serializable]
	public class PolygonGeometryObject : ArrayArrayGeometryObject {
		public PolygonGeometryObject(JSONObject jsonObject) : base(jsonObject) {
		}
	}
	[System.Serializable]
	public class MultiPolygonGeometryObject : ArrayArrayGeometryObject {
		public MultiPolygonGeometryObject(JSONObject jsonObject) : base(jsonObject) {
		}
	}
}