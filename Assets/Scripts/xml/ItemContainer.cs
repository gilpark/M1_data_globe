//ref : http://wiki.unity3d.com/index.php?title=Saving_and_Loading_Data:_XmlSerializer
//ref(utf8) : http://stackoverflow.com/questions/8151379/forcing-streamwriter-to-change-encoding
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Text;

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

	public void Save(string path)
 	{
 		var serializer = new XmlSerializer(typeof(ItemContainer));
 		var stream = new FileStream(path, FileMode.Create);
 		using(var xs = new StreamWriter(stream,Encoding.UTF8))
 		{
 			serializer.Serialize(xs, this);
 		}
 	}
 	
}
