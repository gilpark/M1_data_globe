//ref (prebuild connector found here.. probably old): http://forum.unity3d.com/threads/unity-with-mysql.63364/ 
//ref2 (install SQL connector with mono) : http://dev.mysql.com/doc/connector-net/en/connector-net-installation-unix.html
//ref3 (SQL connection string) : http://www.connectionstrings.com/mysql/
//ref4 (writing SQL queries) : https://technet.microsoft.com/en-us/library/bb264565(v=sql.90).aspx

//sql time rang query: 
//// SELECT * FROM `tweets` WHERE `created_at` BETWEEN '2011-01-01 00:00:00' AND '2011-03-01 00:00:00'
//SELECT * FROM `tweets` WHERE `tweet_text` LIKE '%love%'
using UnityEngine;
using UnityEngine.UI;
using MySql.Data;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;


public class MySQLConnector : MonoBehaviour {
	
	public GameObject dataLoder;

	public static string UTF8ByteArrayToString(Byte[] characters){
	  return System.Text.Encoding.UTF8.GetString(characters, 0, characters.Length);
	}
 
	public static Byte[] StringToUTF8ByteArray(String text){
	  return System.Text.Encoding.UTF8.GetBytes(text);
	}

    string filename;
    string oldTimeStamp,newTimeStamp;

	string constr = "Server=mysql.gilpark.com;Database=m1_twitter;User ID=gilparkcom1;Password=CNzZ!vyh;Pooling=true";
 // connection object
    MySqlConnection con = null;
    // command object
    MySqlCommand cmd = null;
    // reader object
    MySqlDataReader rdr = null;	
	ItemContainer ic;

    void Start(){

    	ic = new ItemContainer();
        oldTimeStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        print(oldTimeStamp);
    }

    public void Request(string search){


     	// string f = year + _from.text + time;
     	// string t = year + _to.text + time;
        print(search); 
     	ReadEntries(search);
     	LogGameItems();
     	dataLoder.GetComponent<ItemLoder>().Add_dp_with_label(ic);
    }

    public void Save(){
        if(!filename.Equals("")){
         ic.Save("Assets/data/"+filename+".xml" );
          print("xml Saved...");
        ic.items.Clear();
        filename = "";
        }
          
    }
    
    public void dpClear(){
    	ItemLoder iL  = dataLoder.GetComponent<ItemLoder>();
    	if(iL.datapoints.Count !=0){
			foreach( GameObject g in iL.datapoints ){
				Destroy(g);
			}
			dataLoder.GetComponent<ItemLoder>().datapoints.Clear();
		}
    }

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
     void OnApplicationQuit()
    {
        Debug.Log("killing con");
        if (con != null)
        {
            if (con.State.ToString() != "Closed")
                con.Close();
            con.Dispose();
        }
    }

   
    void ReadEntries(string search)
    {
        filename = filename + search + "+";
        string query = string.Empty;
        if(search.Equals("stream")){
            ic.items.Clear();
            newTimeStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            query = "SELECT * FROM tweets WHERE created_at BETWEEN '" + oldTimeStamp + "' AND '" + newTimeStamp+"'";
             oldTimeStamp = newTimeStamp;
            }else{
            string term = "LIKE '%" + search + "%'";
            query = "SELECT * FROM tweets WHERE tweet_text " +term;
        }
            print(query);
    	//WHERE `created_at` BETWEEN '2011-01-01 00:00:00' AND '2011-03-01 00:00:00'
        // Error trapping in the simplest form
        try
        {

            if (con.State.ToString() != "Open")
                con.Open();
            using (con)
            {
                using (cmd = new MySqlCommand(query, con))
                {
                    rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                        while (rdr.Read())
                        {
                            Item itm = new Item();
                            itm.tweet_id = double.Parse(rdr["tweet_id"].ToString());
                            itm.text = UTF8ByteArrayToString(StringToUTF8ByteArray(rdr["tweet_text"].ToString())).Replace("&", "");
                            itm.geo_lat = float.Parse(rdr["geo_lat"].ToString());
                            itm.geo_long = float.Parse(rdr["geo_long"].ToString());

                            itm.name = UTF8ByteArrayToString(StringToUTF8ByteArray(rdr["name"].ToString())).Replace("&", "");
                            itm.place = UTF8ByteArrayToString(StringToUTF8ByteArray(rdr["place"].ToString())).Replace("&", "");
                            itm.lang = UTF8ByteArrayToString(StringToUTF8ByteArray(rdr["lang"].ToString())).Replace("&", "");
                            itm.description = UTF8ByteArrayToString(StringToUTF8ByteArray(rdr["description"].ToString())).Replace("&", "");
                            ic.items.Add(itm);
                        }
                    rdr.Dispose();
                }
            }
        }
        catch (Exception ex)
        {
            Debug.Log(ex.ToString());
        }
        finally
        {
        }
                                       
    }
	
	void LogGameItems()
    {
        if (ic.items != null)
        {
            if (ic.items.Count > 0)
            {
                foreach (Item itm in ic.items)
                {
                    Debug.Log("tweet_id: " + itm.tweet_id);
                    Debug.Log("text: " + itm.text);
                    Debug.Log("geo_lat: " + itm.geo_lat);
                    Debug.Log("geo_long: " + itm.geo_long);
                    Debug.Log("name: " + itm.name);
                    Debug.Log("place: " + itm.place);
                    Debug.Log("lang: " + itm.lang);
                    Debug.Log("description: " + itm.description);

                }
            }
        }
    }	
}
