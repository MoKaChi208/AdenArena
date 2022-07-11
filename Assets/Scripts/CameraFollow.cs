using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 2f;
    // Start is called before the first frame update
    private void Start()
    {


        smoothSpeed = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != target.position)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, 2);
        }
    }
}
