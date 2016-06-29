// original code taken from : http://answers.unity3d.com/questions/629939/smooth-mouse-orbit-c.html
// modified : drag2rotate , sunAutoRotate

 using UnityEngine;
  using UnityEngine;
  using System.Collections;
 
[AddComponentMenu("Camera-Control/Mouse Orbit with zoom")]

public class MouseOrbitImproved : MonoBehaviour
  {
      public GameObject E_Master;
      public Transform target;
      public float distance = 5.0f;
      public float xSpeed = 120.0f;
      public float ySpeed = 120.0f;
  
      public float yMinLimit = -20f;
      public float yMaxLimit = 80f;
  
      public float distanceMin = .5f;
      public float distanceMax = 15f;
  
      public float smoothTime = 2f;
  
      float rotationYAxis = 0.0f;
      float rotationXAxis = 0.0f;
  
      float velocityX = 0.0f;
      float velocityY = 0.0f;
      float volocityZ = 0.0f; //mouse scroll
      //auto rotation
      public bool auto;
      public float timer;
      public float timeout2Auto = 10.0f;
      public float auto_Speed = 0.01f;
      //sun
      public GameObject Sun;
      public float sunRoateSpeed = 10.0f;
      // public float sunAngles;

      // Use this for initialization
      void Start()
      {
        


          Vector3 angles = transform.eulerAngles;
          rotationYAxis = angles.y;
          rotationXAxis = angles.x;
  
          // Make the rigid body not change rotation
          if (GetComponent<Rigidbody>())
          {
              GetComponent<Rigidbody>().freezeRotation = true;
          }
      }
      void Update(){

         Sun.transform.Rotate(Vector3.up * sunRoateSpeed * Time.deltaTime);
         timer += Time.deltaTime;
         if(timer > timeout2Auto && !Input.GetMouseButton(0)){
            auto = true;
         }else if(Input.GetMouseButton(0)){
            timer = 0;
         }else{
            auto = false;
         }
      }
      void LateUpdate()
      {
        if(!E_Master.GetComponent<UIEventMaster>().mouseOnUI){ 
          if (target)
          {
              if (Input.GetMouseButton(0))
              {
                  velocityX += xSpeed * Input.GetAxis("Mouse X") * distance * 0.02f;
                  velocityY += ySpeed * Input.GetAxis("Mouse Y") * 0.02f;
              }
              if(auto){
                velocityX +=  auto_Speed * distance * 0.02f;
              }
  
              rotationYAxis += velocityX;
              rotationXAxis -= velocityY;
  
              rotationXAxis = ClampAngle(rotationXAxis, yMinLimit, yMaxLimit);
  
              Quaternion fromRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);
              Quaternion toRotation = Quaternion.Euler(rotationXAxis, rotationYAxis, 0);
              Quaternion rotation = toRotation;
              distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel")*4, distanceMin, distanceMax);
        
              Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
              Vector3 position = rotation * negDistance + target.position;
              
              transform.rotation = rotation;
              transform.position = position;
  
              velocityX = Mathf.Lerp(velocityX, 0, Time.deltaTime * smoothTime);
              velocityY = Mathf.Lerp(velocityY, 0, Time.deltaTime * smoothTime);
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