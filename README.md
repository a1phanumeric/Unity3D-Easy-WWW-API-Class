Unity3D-C-Sharp-API-Class
=========================

## Overview ##

This is a simple class you can use to perform web calls to and from a web server, passing the results directly back to the calling GameObject. As the response is always expected to be JSON data, this utilises the JSONObject.cs and Nullable.cs as written by Matt Schoen of Defective Studios.

## To-Do ##
- Add a loading view when each API call is POSTed to the server.
- Add better handling / parsing of the returned data.

## How to Integrate ##
Simply just drag the following three files into your project:

- API.cs
- JSONObject.cs (by Matt Schoen of Defective Studios)
- Nullable.cs (by Matt Schoen of Defective Studios)

## How to Setup ##

Open the API.cs and update the following lines to match your server:

```
private static readonly string API_BASE_URL 			= "http://API_BASE_URL";	// The base URL to your server (or API directory)
private static readonly string API_AUTH_USERNAME	= "HTACCESS_USERNAME"; 		// Leave blank if unused
private static readonly string API_AUTH_PASSWORD 	= "HTACCESS_PASSWORD"; 		// Leave blank if unused
private static readonly string API_KEY			 			= "API_KEY";							// Leave blank if unused
```

## How to Use ##

To post data to your server, the API class uses Hashtables. Once you;ve copied the above files into your project, and set (at the bare minimum) the `API_BASE_URL`, you can access API from anywhere within your C# code.

To make a basic call sending a couple of parameters, you'd use something like the following:

```
Hashtable parameters = new Hashtable();
parameters.Add("A Key", "A Value");
parameters.Add("username", "Ed");

API.Post(gameObject, "/user/test", parameters, "TestCallback");
```

- **First Parameter** - This is the gameObject that the API call should be actioned on, as well as the target for the callback method.
- **Second Parameter** - The path *after* the `API_BASE_URL` for this particular API call.
- **Third Parameter** - The hashtable of parameters to send to the server.
- **Fourth Parameter** - The callback method that handles the completion of this request.

An example of how the callback method should look is as the following:

```
void TestCallback(JSONObject returnData){
	Debug.Log("Call back with object: " + returnData);
}
```

Note that the callback function will always need one parameter - `(JSONObject returnData)`.

## Example ##

Look at the Login.cs code example to see a basic implementation of this class.

## Acknowledgements ##
Matt Schoen of Defective Studios for the JSONObject.cs and Nullable.cs class.

## MIT License ##
Copyright (c) 2013 Ed Rackham (edrackham.com)

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NON INFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.