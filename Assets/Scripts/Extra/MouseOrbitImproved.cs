// original code taken from : http://wiki.unity3d.com/index.php?title=MouseOrbitImproved
// modified : drag2rotate , sunAutoRotate

using UnityEngine;
using System.Collections;
 
[AddComponentMenu("Camera-Control/Mouse Orbit with zoom")]
public class MouseOrbitImproved : MonoBehaviour {
 
    public Transform target;
    public float distance = 5.0f;
    public float xSpeed = 120.0f;
    public float ySpeed = 120.0f;
    public float camAutoRotateSpeed = 10.0f;
 
    public float yMinLimit = -20f;
    public float yMaxLimit = 80f;
 
    public float distanceMin = .5f;
    public float distanceMax = 15f;
    
    //mouse threshold
    public float mXThreshhold , mYThreshhold = 0.2f;
    public GameObject Sun;
    public float sunRoateSpeed = 10.0f;
    public float sunAngles;

    private Rigidbody rigidbody;
 
    float x = 0.0f;
    float y = 0.0f;
 
    void Start () 
    {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;
 
        rigidbody = GetComponent<Rigidbody>();
 
        // Make the rigid body not change rotation
        if (rigidbody != null)
        {
            rigidbody.freezeRotation = true;
        }
    }
    
    void Update(){
        Sun.transform.Rotate(Vector3.up * sunRoateSpeed * Time.deltaTime);
    }

    void LateUpdate () 
    {

        if (target) 
        {
            //drag
            if(Input.GetMouseButton(0)){
                x += Input.GetAxis("Mouse X") * xSpeed * distance * 0.02f;
                y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
            }
           
 
            y = ClampAngle(y, yMinLimit, yMaxLimit);
 
            Quaternion rotation = Quaternion.Euler(y, x, 0);
            // Quaternion autoRotation = Quaternion.Euler(0.1f*Time.deltaTime*camAutoRotateSpeed, 0.1f, 0);
            distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel")*5, distanceMin, distanceMax);
 
            // RaycastHit hit;
            // if (Physics.Linecast (target.position, transform.position, out hit)) 
            // {
            //     distance -=  hit.distance;
            // }
        
            Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
            Vector3 position = rotation * negDistance + target.position;
            

            transform.rotation = rotation;
            transform.position = position;
            
             //mouse Movement detection
             if (Input.GetAxis("Mouse X") > mXThreshhold)
             {
             //mouse moving right
             //@TODO : adding acceletion
             }
             else if (Input.GetAxis("Mouse X") < -mXThreshhold)
             {
             //mouse moving left
             //@TODO : adding acceletion
             }
             else
             {
             //mouse standing still
                // Vector3 autoposition = autoRotation * negDistance + target.position;
                // transform.rotation = autoRotation;
                //  transform.position = autoposition;
             }
         
             if (Input.GetAxis("Mouse Y") > mYThreshhold)
             {
             //mouse moving forward
             //@TODO : adding acceletion
             }
             else if (Input.GetAxis("Mouse Y") < -mYThreshhold)
             {
             //mouse moving backward
             //@TODO : adding acceletion
             }
             else
             {
             //mouse standing still
             }
 
        }

    }
 
    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }
}