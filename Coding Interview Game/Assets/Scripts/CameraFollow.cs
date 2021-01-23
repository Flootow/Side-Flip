using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject player;
    public float cameraDistance;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = player.transform.position;
        this.transform.Rotate(0, -2f * Input.GetAxis("Mouse X"), 0, Space.World);
        this.transform.rotation *= Quaternion.Euler(2f * Input.GetAxis("Mouse Y"), 0, 0);
        this.transform.Translate(Vector3.back * 10, Space.Self);
    }
}
