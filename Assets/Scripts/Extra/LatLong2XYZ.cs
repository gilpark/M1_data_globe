using UnityEngine;
using System.Collections;

public class LatLong2XYZ : MonoBehaviour {
	public float lat,lon;

	private float rad; //globe radius
	private GameObject globe;

	void Start () {
		globe = GameObject.Find("Globe");
		rad = globe.GetComponent<SphereCollider>().radius * globe.transform.lossyScale.x;

		// transform.position = pos;
		lat = Mathf.PI  * lat / 180;
		lon = Mathf.PI  * lon / 180;

		//adjust position by radians
		lat -= 90.0f * Mathf.Deg2Rad; //subtract 90 deg

		Vector3 pos = new Vector3();
		pos.x = rad * Mathf.Sin(lat) * Mathf.Cos(lon);
		pos.z = rad * Mathf.Sin(lat) * Mathf.Sin(lon);
		pos.y = rad * Mathf.Cos(lat);

		transform.position = pos;
	}

}
