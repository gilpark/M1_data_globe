//ref : http://wiki.unity3d.com/index.php?title=Saving_and_Loading_Data:_XmlSerializer

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("TweetCollection")]
public class ItemContainer {

	[XmlArray("tweets")]
	[XmlArrayItem("tweet")]
	public List<Item> items = new List<Item>();
	
	public static ItemContainer Load(string path){
		
		var serializer = new XmlSerializer(typeof(ItemContainer));
 		using(var stream = new FileStream(path, FileMode.Open))
 		{
 			return serializer.Deserialize(stream) as ItemContainer;
 		}
	}
}
