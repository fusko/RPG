using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{

    public DefaultInputActions1 actions;
    public CharacterController cc;
    public float speed;

    public Vector2 Position { get; private set; }

    void Awake()
    {
        actions = new DefaultInputActions1();
    }
    public void Start()
    {
        cc = GetComponent<CharacterController>();  
    }

    public void SetMove(InputAction.CallbackContext context)
    {

        Position = context.ReadValue<Vector2>();
    }
    public void FixedUpdate()
    {
        Position = actions.Player.Move.ReadValue<Vector2>();
        cc.SimpleMove(new Vector3(Position.x, 0, Position.y) * speed);
    }

    // Update is called once per frame

    private void OnEnable()
    {
        actions.Enable();
    }
    private void OnDisable()
    {
        actions.Disable();
    }
}
