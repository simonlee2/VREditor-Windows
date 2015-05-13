using UnityEngine;
using System.Collections;

public class CrossHair : MonoBehaviour {

	OVRCameraRig CameraController;
	OVRPlayerController PlayerController;

	/// <summary>
	/// Crosshair rendered onto 3D plane.
	/// </summary>
	public UnityEngine.Texture  CrosshairImage 			= null;
	private OVRCrosshair Crosshair        	= new OVRCrosshair();

	void Awake() {
		// Find camera controller
		OVRCameraRig[] CameraControllers;
		CameraControllers = gameObject.GetComponentsInChildren<OVRCameraRig>();
		
		if(CameraControllers.Length == 0)
			Debug.LogWarning("OVRMainMenu: No OVRCameraRig attached.");
		else if (CameraControllers.Length > 1)
			Debug.LogWarning("OVRMainMenu: More then 1 OVRCameraRig attached.");
		else{
			CameraController = CameraControllers[0];
			#if USE_NEW_GUI
			OVRUGUI.CameraController = CameraController;
			#endif
		}
		
		// Find player controller
		OVRPlayerController[] PlayerControllers;
		PlayerControllers = gameObject.GetComponentsInChildren<OVRPlayerController>();
		
		if(PlayerControllers.Length == 0)
			Debug.LogWarning("OVRMainMenu: No OVRPlayerController attached.");
		else if (PlayerControllers.Length > 1)
			Debug.LogWarning("OVRMainMenu: More then 1 OVRPlayerController attached.");
		else{
			PlayerController = PlayerControllers[0];
			#if USE_NEW_GUI
			OVRUGUI.PlayerController = PlayerController;
			#endif
		}
	}

	// Use this for initialization
	void Start () {
		// Crosshair functionality
		Crosshair.Init();
		Crosshair.SetCrosshairTexture(ref CrosshairImage);
		Crosshair.SetOVRCameraController (ref CameraController);
		Crosshair.SetOVRPlayerController(ref PlayerController);
	}
	
	// Update is called once per frame
	void Update () {
		// Crosshair functionality
		Crosshair.UpdateCrosshair();
	}
}
