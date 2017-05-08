using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public float smoothTimeX = .05f;
    public float smoothTimeY = .05f;

    public bool bounds;

    public Vector3 minCameraPosition;
    public Vector3 maxCameraPosition;

    private Vector2 velocity; // Just required for the script to work

    public GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        float xPos = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
        float yPos = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);

        transform.position = new Vector3(xPos, yPos, transform.position.z);

        if (bounds)
        {
            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, minCameraPosition.x, maxCameraPosition.x),
                Mathf.Clamp(transform.position.y, minCameraPosition.y, maxCameraPosition.y),
                Mathf.Clamp(transform.position.z, minCameraPosition.z, maxCameraPosition.z));
        }
    }

    public void SetMinCameraPosition()
    {
        minCameraPosition = gameObject.transform.position;
    }

    public void SetMaxCameraPosition()
    {
        maxCameraPosition = gameObject.transform.position;
    }
}
