using UnityEngine;
using System.Collections;

public class TargetMover : MonoBehaviour {

	// define the possible states through an enumeration
	public enum motionDirections {Spin, Horizontal, Vertical, All };
	
	// store the state
	public motionDirections motionState = motionDirections.Horizontal;

	// motion parameters
	public float spinSpeed = 180.0f;
	public float motionMagnitude = 0.1f;

    // Update is called once per frame
    private float RedMove()
    {
        if (Time.timeSinceLevelLoad % 2 == 0.0f)
        {
            return -Time.timeSinceLevelLoad;
        }
        else {
            return Time.timeSinceLevelLoad;
        }
    }

	void Update () {

		// do the appropriate motion based on the motionState
		switch(motionState) {
			case motionDirections.Spin:
				// rotate around the up axix of the gameObject
				gameObject.transform.Rotate (Vector3.up * spinSpeed * Time.deltaTime);
				break;
			
			case motionDirections.Vertical:
				// move up and down over time
				gameObject.transform.Translate(Vector3.up * Mathf.Cos(Time.timeSinceLevelLoad) * motionMagnitude);
				break;

            case motionDirections.Horizontal:
                // move up and down over time
                gameObject.transform.Translate(Vector3.right * Mathf.Cos(Time.timeSinceLevelLoad) * motionMagnitude);
                break;

            case motionDirections.All:
                // move random over time
                gameObject.transform.Translate(Vector3.right * Mathf.Log(Time.timeSinceLevelLoad) * motionMagnitude);
                gameObject.transform.Translate(Vector3.up * Mathf.Cos(Time.timeSinceLevelLoad) * motionMagnitude);
                gameObject.transform.Rotate(Vector3.up * spinSpeed * Time.deltaTime);
                break;
        }
	}
}
