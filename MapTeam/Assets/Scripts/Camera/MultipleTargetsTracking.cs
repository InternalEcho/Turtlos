using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class MultipleTargetsTracking : MonoBehaviour {

    [Header("Cam view")]
    public List<Transform> players;
    public Vector3 offset;
    public Transform myCamPos;
    private Camera cam;
    private Vector3 velocity = new Vector3(0,0,0);
    public float camSpeed = 0.08f;

    [Header("Cam zoom")]
    public float minZoom = 100f;
    public float maxZoom = 40f;
    public float zoomSpeedFactor = 2;
    public float zoomLimiter = 100f;
    
    void Start()
    {
        cam = GetComponent<Camera>();
    }	

	void LateUpdate ()
    {
        foreach (var player in players)
        {
            if (player == null)
                players.Remove(player);
        }
            if (players.Count == 0)
            return;
        moveCam();
        zoomCam();
	}

    void moveCam()
    {
        Vector3 center = GetCenterPoint();
        Vector3 newPosition = center + offset;
        myCamPos.position = Vector3.SmoothDamp(this.transform.position, newPosition, ref velocity, camSpeed);
    }
    
    void zoomCam()
    {
        float newZoom = Mathf.Lerp(maxZoom, minZoom, GetGreatestDistance() / zoomLimiter);
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime * zoomSpeedFactor);
    }

    float GetGreatestDistance()
    {
        Bounds bounds = new Bounds(players[0].position, Vector3.zero);
        foreach (Transform i in players)
        {
            bounds.Encapsulate(i.position);
        }

        if (bounds.size.x <= bounds.size.z)
        {
            return bounds.size.z;
        }
        else
        {
            return bounds.size.x;
        }
    }

    Vector3 GetCenterPoint()
    {
        if (players.Count == 1)
        {
            return players[0].position;
        }

        Bounds bounds = new Bounds(players[0].position, Vector3.zero);
        foreach (Transform x in players)
        {
            bounds.Encapsulate(x.position);
        }
        return bounds.center;
    }

    //source  : d god brackeys
}
