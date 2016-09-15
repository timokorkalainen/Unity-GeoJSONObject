# GeoJSONObject
A simple [RFC 7946 GeoJSON](https://tools.ietf.org/html/rfc7946) parser in C# for Unity 3D. Utilizes the [JSONObject](https://github.com/mtschoen/JSONObject) library by Matt Schoen.

## Prerequisite
Import the JSONObject library from https://github.com/mtschoen/JSONObject

## Example
```C#
//Read a TextAsset and parse as a FeatureCollection
FeatureCollection collection = GeoJSON.GeoJSONObject.ParseAsCollection (encodedGeoJSON.text);
```

## Getting started
1. Import directory into Unity
2. See the example scene

## Missing features
* Encoding/Serialization
* Bounding Box support

## Author
Timo Korkalainen <timo@timokorkalainen.net> 

## License
MIT License

Copyright (c) 2016 Timo Korkalainen

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.