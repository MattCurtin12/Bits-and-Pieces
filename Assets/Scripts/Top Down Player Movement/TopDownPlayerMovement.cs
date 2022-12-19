using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerInput))]
public class TopDownPlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    private Vector2 input;
    
    [SerializeField] private float speed = 1;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    //Called when Movement action taken in PlayerInput
    private void OnMovement(InputValue value){
        input = value.Get<Vector2>();
    }

    void FixedUpdate(){
        Vector2 change = input * speed * Time.fixedDeltaTime;
        Vector2 targetPosition = rb.position + change;
        rb.MovePosition(targetPosition);
    }
}
