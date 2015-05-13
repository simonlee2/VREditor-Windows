/******************************************
  * uWebKit 
  * (c) 2014 THUNDERBEAST GAMES, LLC
  * http://www.uwebkit.com
  * sales@uwebkit.com
*******************************************/

using UnityEngine;
using System.Collections;

/// <summary>
/// Simple menu for WebTexture Example
/// </summary>
public class WebTextureExample : MonoBehaviour
{
	WebTexture webTexture;

	void Start()
	{
		webTexture = GameObject.FindObjectOfType (typeof(WebTexture)) as WebTexture;
	}

	void OnGUI ()
	{
	

	}

	void SourcePopupClosed()
	{
		UnityEngine.Object.Destroy(gameObject.GetComponent<SourceCodePopup>());		
		webTexture.HasFocus = true;
	}

	SourceCodePopup sourcePopup;

	
}