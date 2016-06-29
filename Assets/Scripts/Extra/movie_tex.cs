using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class movie_tex : MonoBehaviour {
	
    MovieTexture m;
	RawImage r;

   void Start () {
    r = gameObject.GetComponent<RawImage>();
	m = (MovieTexture) r.mainTexture;
    m.loop = true;
    m.Play();
    }
}
