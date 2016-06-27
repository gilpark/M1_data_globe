using UnityEngine;
using System.Collections;
 
public class CameraFacing : MonoBehaviour
{
    Camera m_Camera;
 	void  Awake ()
	{
		// if no camera referenced, grab the main camera
		
			m_Camera = Camera.main; 

	}
    void Update()
    {
        transform.LookAt(transform.position + m_Camera.transform.rotation * Vector3.forward,
            m_Camera.transform.rotation * Vector3.up);
    }
}