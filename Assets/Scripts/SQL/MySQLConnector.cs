//ref (prebuild connector found here.. probably old): http://forum.unity3d.com/threads/unity-with-mysql.63364/ 
//ref2 (install SQL connector with mono) : http://dev.mysql.com/doc/connector-net/en/connector-net-installation-unix.html
//ref3 (SQL connection string) : http://www.connectionstrings.com/mysql/
//ref4 (writing SQL queries) : https://technet.microsoft.com/en-us/library/bb264565(v=sql.90).aspx

using UnityEngine;
using MySql.Data;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;

public class MySQLConnector : MonoBehaviour {
	MySqlConnection con = null;
	//connection
	string constr = "Server=mysql.gilpark.com;Database=m1_twitter;User ID=gilparkcom1;Password=CNzZ!vyh;Pooling=true";
	
	 void Awake(){
        try{
            // setup the connection element
            con = new MySqlConnection(constr);

            // lets see if we can open the connection
            con.Open();
            Debug.Log("MySQL Connection State: " + con.State);
        }
        catch (Exception ex){
            Debug.Log(ex.ToString());
        }

    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
