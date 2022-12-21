using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralAnimation : MonoBehaviour
{
    private Transform parent;

    [SerializeField] private float f = 1, z = 1, r = 2;
    private float k1, k2, k3;

    private const float PI = Mathf.PI;

    private Vector2 y, dy, dy2, x, dx; 
    private Vector2 last_x; 

    void Awake(){
        parent = transform.parent;
    }

    void Start(){
        //Initialize state variables
        last_x = parent.position;
        y = last_x;
        dy = Vector2.zero;
    }

    void Update(){
        k1 = z / (PI * f);
        k2 = 1/ (4 * PI * PI * f * f);
        k3 = r * z / (2 * PI * f);

        float T = Time.deltaTime;

        //estimate velocity 
        x = parent.position;
        dx = (x - last_x) / T;
        last_x = x;

        //Calculate acceleration
        dy2 = (x + k3 * dx - y - k1 * dy) / k2; 

        //Update State Variables
        y = y + T * dy;
        dy = dy + T * dy2;

        transform.SetPositionAndRotation(y, Quaternion.identity);
    }

}
