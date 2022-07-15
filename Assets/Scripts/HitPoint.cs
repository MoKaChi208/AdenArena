using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class HitPoint : MonoBehaviour
{
    public float RotationSpeed = 720;
    public GameObject pivotObject;

    public void Rotate(){
        transform.RotateAround(pivotObject.transform.position, new Vector3(0, 1, 0), RotationSpeed* Time.deltaTime);
    }
}

