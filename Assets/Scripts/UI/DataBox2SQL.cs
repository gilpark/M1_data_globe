using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class DataBox2SQL : MonoBehaviour {

	// Use this for initialization
	public Text search;
	public GameObject SQLconnector;
	MySQLConnector mySQL;
	public void Start(){
		mySQL = SQLconnector.GetComponent<MySQLConnector>();
	}
	public void SendRequest(){
		mySQL.Request(search.text);
	}
}
