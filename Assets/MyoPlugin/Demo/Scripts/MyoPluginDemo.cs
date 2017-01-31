using UnityEngine;
using System.Collections;
using MyoUnity;

public class MyoPluginDemo : MonoBehaviour 
{
	public Transform objectToRotate;
	
	private Quaternion myoRotation;
	private MyoPose myoPose = MyoPose.UNKNOWN;

	void Start () 
	{		
		MyoManager.Initialize ();
		MyoManager.PoseEvent += OnPoseEvent;
	}

	void OnPoseEvent( MyoPose pose )
	{
		myoPose = pose;
	}
	
	void Update()
	{
		if (MyoManager.GetIsAttached()) {	
			myoRotation = MyoManager.GetQuaternion ();
			objectToRotate.rotation = myoRotation;
		}
	}
	
	void OnGUI()
	{
		GUI.BeginGroup( new Rect( 10, 10, 600, 750 ) );
		
		if (GUILayout.Button ( "Attach to Adjacent" , GUILayout.MinWidth(300), GUILayout.MinHeight(150) ) )
		{
			MyoManager.AttachToAdjacent();
		}
		
		if (GUILayout.Button ( "Vibrate Short" , GUILayout.MinWidth(300), GUILayout.MinHeight(50) ) )
		{
			MyoManager.VibrateForLength( MyoVibrateLength.SHORT );
		}
		
		if (GUILayout.Button ( "Vibrate Medium" , GUILayout.MinWidth(300), GUILayout.MinHeight(50) ) )
		{
			MyoManager.VibrateForLength( MyoVibrateLength.MEDIUM );
		}
		
		if (GUILayout.Button ( "Vibrate Long" , GUILayout.MinWidth(300), GUILayout.MinHeight(50) ) )
		{
			MyoManager.VibrateForLength( MyoVibrateLength.LONG );
		}

		if (!MyoManager.GetIsInitialized()) {
			if (GUILayout.Button ("Initialize MyoPlugin", GUILayout.MinWidth (300), GUILayout.MinHeight (150))) {
				MyoManager.Initialize ();
			}
		} else {
			if (GUILayout.Button ("Uninitialize MyoPlugin", GUILayout.MinWidth (300), GUILayout.MinHeight (150))) {
				MyoManager.Uninitialize ();
			}
		}
		
		GUILayout.Label ( "Myo Quaternion: " + myoRotation.ToString(), GUILayout.MinWidth(300), GUILayout.MinHeight(75) );
		
		GUILayout.Label ( "Myo Pose: " + myoPose.ToString(), GUILayout.MinWidth(300), GUILayout.MinHeight(75) );

		GUILayout.Label ( "Initialized: " + MyoManager.GetIsInitialized(), GUILayout.MinWidth(300), GUILayout.MinHeight(75) );

		GUILayout.Label ( "Attached: " + MyoManager.GetIsAttached(), GUILayout.MinWidth(300), GUILayout.MinHeight(75) );
		
		GUI.EndGroup();
	}
}