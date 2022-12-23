using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOrbit : MonoBehaviour
{
    
    [SerializeField] private float radius;
    [SerializeField] private float orbitAngleDegrees;   
    [SerializeField] private float rotationDegreesOffset;

    private Transform parent;

    //MonoBehaviour has deprecated member variable camera, so must put new
    private new Camera camera; 

    void Awake(){
        parent = transform.parent;
        camera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        float orbitAngleRadians = orbitAngleDegrees * Mathf.Deg2Rad;
        float x = radius * Mathf.Cos(orbitAngleRadians);
        float y = radius * Mathf.Sin(orbitAngleRadians);  
        Vector3 pos = new Vector3(x, y, 0);

        float rotationDegrees = orbitAngleDegrees + rotationDegreesOffset;
        
        transform.SetLocalPositionAndRotation(pos, Quaternion.Euler(0, 0, rotationDegrees));   
    }


    public void SetOrbitAngleDegrees(float angle){
        orbitAngleDegrees = angle;
    }

    public void PointTowardsScreenSpace(Vector2 pointScreenSpace){
        Vector3 pointWorldSpace = camera.ScreenToWorldPoint(pointScreenSpace);

        float xdiff = pointWorldSpace.x - parent.position.x;
        float ydiff = pointWorldSpace.y - parent.position.y;

        float angleRads = Mathf.Atan2(ydiff, xdiff);
        orbitAngleDegrees = angleRads * Mathf.Rad2Deg;
    }

}
