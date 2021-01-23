using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] Object projectile;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           Quaternion rotation = PlayerRotations.Instance.CameraRotationAlongY;
           GameObject newObject = (GameObject) Instantiate(projectile, (transform.position + 1.5f * Vector3.up), new Quaternion());
           newObject.GetComponent<Rigidbody>().velocity = 10 * (rotation * Vector3.forward);
        }
    }
}
