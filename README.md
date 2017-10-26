# Unity-GeoJSONObject
A simple [RFC 7946 GeoJSON](https://tools.ietf.org/html/rfc7946) parser in C# for Unity 3D. Utilizes the [JSONObject](https://github.com/mtschoen/JSONObject) library by Matt Schoen.

## Prerequisite
Import the JSONObject library from https://github.com/mtschoen/JSONObject

## Example
```C#
//Read a TextAsset and parse as a FeatureCollection
FeatureCollection collection = GeoJSON.GeoJSONObject.Deserialize(encodedGeoJSON.text);

//Serialize collection back to text
string json = collection.Serialize().ToString();

```

## Getting started
(0. Import the JSONObject library from https://github.com/mtschoen/JSONObject into Unity)
1. Import directory into Unity
2. See the example scene

## Missing features
* Bounding Box support
