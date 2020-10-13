using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private InputActionAsset _controls;

    [SerializeField]
    private float speed = 6f;

    private Vector2 movement = Vector2.zero;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        InputActionMap playerMap =_controls.FindActionMap("Player");
        InputAction moveAction = playerMap.FindAction("Move");
        moveAction.performed += (ctx) => { movement = ctx.ReadValue<Vector2>(); };
        moveAction.canceled += (ctx) =>{ movement = Vector2.zero; };
        _controls.Enable();

    }




    //Start is called before the first frame update
    //void Start()
    //{

    //}

    //Update is called once per frame
    private void Update()
    {
        //Debug.DrawRay(transform.position, movement, Color.green, .2f,true);
        Move(movement, Time.deltaTime);

    }

    private void Move(Vector2 direction,float deltaTime)
    {
        if (direction == null) {           
            return; 
        }
        direction.Normalize();
        Vector3 movement = new Vector3(direction.x, 0f, direction.y);
        transform.position += movement * speed * deltaTime;
        transform.forward = movement;
    //    animator.SetBool("isWalking", movement!=Vector3.zero);

    }
}
