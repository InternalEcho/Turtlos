using UnityEngine;
using System.Collections;

public class OrbitCamera : MonoBehaviour {
	
	public Transform target;
	public Transform cam;
	public Vector3 offset = Vector3.zero;
    public float sensitivity;
	private float cameraRotSide;
	private float cameraRotUp;
	private float cameraRotSideCur;
	private float cameraRotUpCur;
	private float distance;

	void Start () {
		cameraRotSide = transform.eulerAngles.y;
		cameraRotSideCur = transform.eulerAngles.y;
		cameraRotUp = transform.eulerAngles.x;
		cameraRotUpCur = transform.eulerAngles.x;
		distance = -cam.localPosition.z;
	}
	
	void Update () {
		if (Input.GetMouseButton(0)) {
			cameraRotSide += Input.GetAxis("Mouse X")* sensitivity;
			cameraRotUp -= Input.GetAxis("Mouse Y")* sensitivity;
		}
		cameraRotSideCur = Mathf.LerpAngle(cameraRotSideCur, cameraRotSide, Time.deltaTime*5);
		cameraRotUpCur = Mathf.Lerp(cameraRotUpCur, cameraRotUp, Time.deltaTime*5);

		distance *= (1-1*Input.GetAxis("Mouse ScrollWheel"));
		
		transform.position = new Vector3(target.position.x, target.position.y+1.2f, target.position.z) ;
		transform.rotation = Quaternion.Euler(cameraRotUpCur, cameraRotSideCur, 0);
		
		float dist = Mathf.Lerp(-cam.transform.localPosition.z, distance, Time.deltaTime*20);
		cam.localPosition = -Vector3.forward * dist;
	}
}
