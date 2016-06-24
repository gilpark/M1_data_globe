using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System;

public class Item : ICloneable{

	public float geo_lat;
	public float geo_long;
	public string name;
	public string text;
	
	public object Clone(){
		return this.MemberwiseClone();
	}
}
