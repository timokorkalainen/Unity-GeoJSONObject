using UnityEngine;
using System.Collections;


namespace GeoJSON {

	[System.Serializable]
	public class PositionObject {
		public float latitude;
		public float longitude;

		public PositionObject(JSONObject jsonObject) {
			longitude = jsonObject.list [0].f;
			latitude = jsonObject.list [1].f;
		}
	}
}
