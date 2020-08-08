using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class numove : MonoBehaviour
{
    Playercontrols controls;
    Vector2 move;
    public float speed = 12f;

    private void Awake()
    {
        controls = new Playercontrols();
        controls.gameplay.controllermove.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.gameplay.controllermove.canceled += ctx => move = Vector2.zero;

    }

    void Update()
    {
        Vector2 m = new Vector2(move.x, move.y) * Time.deltaTime*speed;
        transform.Translate(m, Space.World);
    }
    void OnEnable()
    {
        controls.gameplay.Enable();
    }
}
