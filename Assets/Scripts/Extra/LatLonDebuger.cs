// better globe texture : http://paulillsley.com/gia/index.html
// ref (lat,log) : http://60n95w.com/blogs/oh60n95w/17378537-latitude-and-longitude-basics-for-the-modern-explorer
// ref2 (calc method) : https://rbrundritt.wordpress.com/2008/10/14/conversion-between-spherical-and-cartesian-coordinates-systems/
// ref3 (calc method): http://stackoverflow.com/questions/1185408/converting-from-longitude-latitude-to-cartesian-coordinates
// ref4 (Octahedron Sphere) : http://www.binpress.com/tutorial/creating-an-octahedron-sphere/162

//to use : slide lat,lon val in inspector

using UnityEngine;
using System.Collections;

public class LatLonDebuger : MonoBehaviour {

	public float rad; //globe radius
	public float lat,lon = 0;
	private float lat2,lon2;
	private GameObject globe;
	private bool run;
	
	void Start () {
		globe = GameObject.Find("Globe");
		rad = globe.GetComponent<SphereCollider>().radius * globe.transform.lossyScale.x;
		
		run = true;
		// lat2 = lat;
		// lon2 = lon;
	}
	
	void Update () {
		lat2 = lat;
		lon2 = lon;
		lat2 = Mathf.PI  * lat2 / 180;
		lon2 = Mathf.PI  * lon2 / 180;

		//adjust position by radians
		lat2 -= 90.0f * Mathf.Deg2Rad; //subtract 90 deg

		Vector3 pos = new Vector3();
		pos.x = rad * Mathf.Sin(lat2) * Mathf.Cos(lon2);
		pos.z = rad * Mathf.Sin(lat2) * Mathf.Sin(lon2);
		pos.y = rad * Mathf.Cos(lat2);

		transform.position = pos;

		//xyz back 2 lat, log
		// lat = Mathf.Asin(pos.z / pos.z);
		// lon = Mathf.Atan2(pos.y , pos.x);
	}

	void OnDrawGizmos() {
		if(run){		
			//when the globe's rotation (0,90,0) 
			// X(blue line) at Longtitude 0deg
		 	Gizmos.color = Color.red;
			Gizmos.DrawLine(Vector3.zero, Vector3.left * globe.transform.lossyScale.y);

			// Y(green line) at Latitude +90deg
		 	Gizmos.color = Color.green;
			Gizmos.DrawLine(Vector3.zero, Vector3.up * globe.transform.lossyScale.y);

			// Z(green line) at Longtitude +90deg
		 	Gizmos.color = Color.blue;
			Gizmos.DrawLine(Vector3.zero, Vector3.back * globe.transform.lossyScale.y);
		}
	}
}
