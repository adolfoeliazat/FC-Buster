using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsCamera : MonoBehaviour
{

    public float speed;
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, Camera.main.transform.position, step);
    }
}
