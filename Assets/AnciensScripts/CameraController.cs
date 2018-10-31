using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public float panSpeed = 4.0f;
	public float zoomSpeed = 4.0f;	

	private Vector3 mouseOrigin;
	private bool isPanning;	
	private bool isZooming;

	public GameObject bg;
	public GameObject bg2;


	void Update () 
	{

		if(Input.GetMouseButtonDown(1)){
			mouseOrigin = Input.mousePosition;
			isPanning = true;
		}

		if (Input.GetMouseButtonDown (2)) {
			mouseOrigin = Input.mousePosition;
			isZooming = true;
		}

		if (!Input.GetMouseButton (1)) {
			isPanning=false;
		}

		if (!Input.GetMouseButton (2)) {
			isZooming=false;
		}

		if (isPanning){
			Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);

			Vector3 move = new Vector3(pos.x * panSpeed, 0, 0);
			transform.Translate(move, Space.Self);

			if (GetComponent<Camera> ().transform.position.x <= -12) {
				GetComponent<Camera> ().transform.position = new Vector3 (-12, 2, -10);
				bg.transform.Translate (new Vector3 (0, 0, 0), Space.World);
				bg2.transform.Translate (new Vector3 (0, 0, 0), Space.World);

			}else if (GetComponent<Camera> ().transform.position.x >= 12) {
				GetComponent<Camera> ().transform.position = new Vector3 (12, 2, -10);
				bg.transform.Translate (new Vector3 (0, 0, 0), Space.World);
				bg2.transform.Translate (new Vector3 (0, 0, 0), Space.World);

			} else {
				bg.transform.Translate(new Vector3(pos.x * panSpeed / 5, 0, 0), Space.World);
				bg2.transform.Translate(new Vector3(pos.x * panSpeed / 7, 0, 0), Space.World);
			}


		}

		if (isZooming) {
			Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);
			GetComponent<Camera>().orthographicSize = GetComponent<Camera>().orthographicSize + pos.y * zoomSpeed;

			if(GetComponent<Camera>().orthographicSize < 8) GetComponent<Camera>().orthographicSize = 8;
			if(GetComponent<Camera>().orthographicSize > 10) GetComponent<Camera>().orthographicSize = 10;
			if(GetComponent<Camera>().orthographicSize > 10) GetComponent<Camera>().orthographicSize = 10;
		}

	}
}