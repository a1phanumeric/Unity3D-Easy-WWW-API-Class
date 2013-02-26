using UnityEngine;
using System.Collections;

public class Login : MonoBehaviour {

	void OnGUI(){
		if(API.canShowGUI){
			if (GUI.Button(new Rect(10, 10, 200, 60), "Login")){
	        	PerformLogin();
			}
		}
	}

	void PerformLogin(){
		Hashtable parameters = new Hashtable();
		parameters.Add("username", "a1phanumeric");
		parameters.Add("password", "superSecret");
		API.Post(gameObject, "/user/login", parameters, "TestCallback");
	}

	void TestCallback(JSONObject returnData){
		Debug.Log("Login Response:");
		accessData(returnData);
	}
	
	void accessData(JSONObject obj){
		switch(obj.type){
			case JSONObject.Type.OBJECT:
				for(int i = 0; i < obj.list.Count; i++){
					string key = (string)obj.keys[i];
					JSONObject j = (JSONObject)obj.list[i];
					Debug.Log(key);
					accessData(j);
				}
				break;
			case JSONObject.Type.ARRAY:
				foreach(JSONObject j in obj.list){
					accessData(j);
				}
				break;
			case JSONObject.Type.STRING:
				Debug.Log(obj.str);
				break;
			case JSONObject.Type.NUMBER:
				Debug.Log(obj.n);
				break;
			case JSONObject.Type.BOOL:
				Debug.Log(obj.b);
				break;
			case JSONObject.Type.NULL:
				Debug.Log("NULL");
				break;
	 
		}
	}
}
