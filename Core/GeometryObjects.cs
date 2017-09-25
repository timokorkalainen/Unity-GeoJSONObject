using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GeoJSON {

	[System.Serializable]
	public class GeometryObject : GeoJSONObject {

		public GeometryObject() : base() {
		}

		public GeometryObject(JSONObject jsonObject) : base(jsonObject) {
		}

		/*
		 * Returns all PositionObjects in the Geometry as a single list
		 */
		virtual public List<PositionObject> AllPositions() {
			return null;
		}

		/*
		 * Returns first PositionObject in the Geometry
		 */
		virtual public PositionObject FirstPosition() {
			return null;
		}

		/*
		 * Returns the number of all PositionObjects in the Geometry
		 */
		virtual public int PositionCount() {
			return 0;
		}

		override protected void SerializeContent(JSONObject rootObject) {
			JSONObject coordinateObject = SerializeGeometry ();
			rootObject.AddField ("coordinates", coordinateObject);
		}

		virtual protected JSONObject SerializeGeometry() { return null; }
	}

	[System.Serializable]
	public class SingleGeometryObject : GeometryObject {
		public PositionObject coordinates;

		public SingleGeometryObject() : base() {
			type = "Point";
			coordinates = new PositionObject ();
		}

		public SingleGeometryObject(float longitude, float latitude) : base() {
			type = "Point";
			coordinates = new PositionObject (longitude, latitude);
		}

		public SingleGeometryObject(JSONObject jsonObject) : base(jsonObject) {
			coordinates = new PositionObject (jsonObject["coordinates"]);
		}

		override public List<PositionObject> AllPositions() {
			List<PositionObject> list = new List<PositionObject> ();
			list.Add (coordinates);
			return list;
		}

		override public PositionObject FirstPosition() {
			return coordinates;
		}

		override public int PositionCount() {
			return 1;
		}

		override protected JSONObject SerializeGeometry() {
			return coordinates.Serialize();
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

		override public PositionObject FirstPosition() {
			if(coordinates.Count > 0)
				return coordinates[0];

			return null;
		}

		override public int PositionCount() {
			return coordinates.Count;
		}

		override protected JSONObject SerializeGeometry() {

			JSONObject coordinateArray = new JSONObject (JSONObject.Type.ARRAY);
			foreach (PositionObject position in coordinates) {
				coordinateArray.Add (position.Serialize());
			}

			return coordinateArray;
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

		override public PositionObject FirstPosition() {
			if(coordinates.Count > 0 && coordinates[0].Count > 0)
				return coordinates[0][0];

			return null;
		}

		override public int PositionCount() {
			int totalPositions = 0;

			foreach (List<PositionObject> l in coordinates) {
				totalPositions += coordinates.Count;
			}

			return totalPositions;
		}


		override protected JSONObject SerializeGeometry() {

			JSONObject coordinateArrayArray = new JSONObject (JSONObject.Type.ARRAY);

			foreach (List<PositionObject> l in coordinates) {
				JSONObject coordinateArray = new JSONObject (JSONObject.Type.ARRAY);
				foreach (PositionObject pos in l) {
					coordinateArray.Add (pos.Serialize());
				}
				coordinateArrayArray.Add (coordinateArray);
			}

			return coordinateArrayArray;
		}
	}

	[System.Serializable]
	public class PointGeometryObject : SingleGeometryObject {
		public PointGeometryObject(JSONObject jsonObject) : base(jsonObject) {
		}
		public PointGeometryObject(float longitude, float latitude) : base(longitude, latitude) {
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