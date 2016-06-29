//ref (material property block e.g) : http://answers.unity3d.com/questions/856056/help-with-materialpropertyblock-is-needed.html
//ref2 : http://docs.unity3d.com/ScriptReference/MaterialPropertyBlock.html
//ref3 (hex<->RGB) : http://answers.unity3d.com/questions/812240/convert-hex-int-to-colorcolor32.html
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Dp_interaction : MonoBehaviour {

	public GameObject tweet_UI;
	public Text user,text,ds;
	
	public Color main,hightlight;

	private MaterialPropertyBlock block;
	int _MKGlowColor, _Color, _MKGlowTexColor;
	public bool filtered;
	private Color normal_main,normal_glow,select_main,select_glow;
	public static Color hexToColor(string hex)
     {
         hex = hex.Replace ("0x", "");//in case the string is formatted 0xFFFFFF
         hex = hex.Replace ("#", "");//in case the string is formatted #FFFFFF
         byte a = 255;//assume fully visible unless specified in hex
         byte r = byte.Parse(hex.Substring(0,2), System.Globalization.NumberStyles.HexNumber);
         byte g = byte.Parse(hex.Substring(2,2), System.Globalization.NumberStyles.HexNumber);
         byte b = byte.Parse(hex.Substring(4,2), System.Globalization.NumberStyles.HexNumber);
         //Only use alpha if the string has enough characters
         if(hex.Length == 8){
             a = byte.Parse(hex.Substring(4,2), System.Globalization.NumberStyles.HexNumber);
         }
         return new Color32(r,g,b,a);
     }


	void Start () {
		normal_main = hexToColor("F5FFCCFF");
		normal_glow = hexToColor("00BCC4FF");
		select_main = hexToColor("DCFF3DFF");
		select_glow = hexToColor("FF00FFFF");
		
		block = new MaterialPropertyBlock();
		_MKGlowColor = Shader.PropertyToID("_MKGlowColor");
		block.Clear();
		block.AddVector(_MKGlowColor, Color.red);
		gameObject.GetComponent<Renderer>().SetPropertyBlock(block);

		// block = new MaterialPropertyBlock();
		_Color = Shader.PropertyToID("_Color");
		block.Clear();
		block.AddVector(_Color, normal_main);
		gameObject.GetComponent<Renderer>().SetPropertyBlock(block);

		// block = new MaterialPropertyBlock();
		_MKGlowTexColor = Shader.PropertyToID("_MKGlowTexColor");
		block.Clear();
		block.AddVector(_MKGlowTexColor, normal_glow);
		gameObject.GetComponent<Renderer>().SetPropertyBlock(block);
	}
	
	// Update is called once per frame
	void OnMouseDown(){
		tweet_UI.GetComponent<ActiveStateToggler>().ToggleActive();
		gameObject.GetComponent<Info_binder>().callInfo();
	}
	void OnMouseOver(){	

		if(filtered){
			gameObject.transform.localScale = new Vector3(0.12f,0.12f,0.12f); 
			ChangeColor(main, hightlight);
			}else{
			gameObject.transform.localScale = new Vector3(0.06f,0.06f,0.06f); 
			ChangeColor(select_main, select_glow);
		}
	}
	void OnMouseExit(){
		if(filtered){
			gameObject.transform.localScale = new Vector3(0.12f,0.12f,0.12f); 
			ChangeColor(main, hightlight);
		}
		else{
			gameObject.transform.localScale = new Vector3(0.03f,0.03f,0.03f);
			ChangeColor(normal_main, normal_glow);
		}
	}
	public void ChangeColor(Color c, Color d){
		_Color = Shader.PropertyToID("_Color");
		block.Clear();
		block.AddVector(_Color, c);
		gameObject.GetComponent<Renderer>().SetPropertyBlock(block);

		_MKGlowTexColor = Shader.PropertyToID("_MKGlowTexColor");
		block.Clear();
		block.AddVector(_MKGlowTexColor, d);
		gameObject.GetComponent<Renderer>().SetPropertyBlock(block);
	}
	public void ChangeSize(){
		filtered = !filtered;
	}
	void Draw(){
		if(filtered){
			ChangeColor(main, hightlight);
			// gameObject.transform.localScale = new Vector3(0.15f,0.15f,0.15f);
			} 

	}
}
