using UnityEngine;
using System.Collections;

public class API : MonoBehaviour {
	
	// Singleton
	private static API _instance;
	public static API Instance{
		get{
			if (!_instance){
					GameObject container = new GameObject();
					container.name = "APIContainer";
					_instance = container.AddComponent(typeof(API)) as API;
				}
			return _instance;
		}
	}
	
	// Configurable Vars (Per Project)
	private static readonly string API_BASE_URL 			= "http://API_BASE_URL";
	private static readonly string API_AUTH_USERNAME	= "HTACCESS_USERNAME"; 	// Leave blank if unused
	private static readonly string API_AUTH_PASSWORD 	= "HTACCESS_PASSWORD"; 	// Leave blank if unused
	private static readonly string API_KEY			 			= "API_KEY";						// Leave blank if unused
	
	
	// Public vars
	public static bool canShowGUI = true;
	
	// Private vars
	
	public static void Post(GameObject target, string path, Hashtable parameters, string callbackMethod = ""){
		API.canShowGUI = false;
		
		// ToDo:
		// Add "loading" animation to the passed gameObject's Main Camera

		string url = API.API_BASE_URL + path; // 
		
		WWWForm form = new WWWForm();
		System.Collections.Hashtable headers = form.headers;
		headers["Authorization"] = "Basic " + System.Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(API.API_AUTH_USERNAME + ":" + API.API_AUTH_PASSWORD));
		
		if(API.API_KEY != ""){
			form.AddField("apikey", API.API_KEY);
		}

		foreach(DictionaryEntry parameter in parameters){
			form.AddField((string)parameter.Key, (string)parameter.Value);
		}
		byte[] rawData = form.data;
		
		API.Instance.StartCoroutine(Internal_SendPost(url, form, rawData, headers, target, callbackMethod));
	}
	
	public static IEnumerator Internal_SendPost(string url, WWWForm form, byte[] rawData, Hashtable headers, GameObject callbackTarget, string callbackMethod = ""){
		WWW www = new WWW(url, rawData, headers);
        yield return www;
		API.canShowGUI = true;
		JSONObject jsonObject = new JSONObject(www.text);
		callbackTarget.SendMessage(callbackMethod, jsonObject);
	}
}
