using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(ItemOrbit))]
[RequireComponent(typeof(PlayerInput))]
public class ItemOrbitInputAim : MonoBehaviour
{
    
    private ItemOrbit itemOrbit;

    private Vector2 mouseScreenPos;

    void Awake(){
        itemOrbit = GetComponent<ItemOrbit>();
    }

    void Update(){
        itemOrbit.PointTowardsScreenSpace(mouseScreenPos);
    }

    private void OnMouseMove(InputValue value){
        mouseScreenPos = value.Get<Vector2>();
    }

}
