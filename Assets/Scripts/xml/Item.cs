using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System;

public class Item : ICloneable{
	public double tweet_id;
	public string text;
	// public DateTime time;
	public float geo_lat;
	public float geo_long;
	public string name;
	 public string place;
	 public string lang;
	 public string description;

	
	public object Clone(){
		return this.MemberwiseClone();
	}
}
