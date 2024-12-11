using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController2D : MonoBehaviour
{
    //Referencias privadas generales
    [SerializeField] Rigidbody2D playerRb;
    [SerializeField] PlayerInput playerInput;
    Vector2 moveImput; //Variable para referenciar el imput de los controladores

    [Header("Movement Parameters")]
    public float speed;

    [Header("Jump Parameters")]
    public float jumpForce;
    [SerializeField] private bool isGrounded;



    // Start is called before the first frame update
    void Start()
    {
        //Para autoreferenciar: nombre de la variable = GetComponent <tipo de variable>()
        playerRb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        playerRb.velocity = new Vector3(moveImput.x * speed, playerRb.velocity.y, 0);
    }

    #region Imput Methods
    //Métodos que permiten leer el input del New Imput System
    //Crearemos un método por cada acción

    public void HandleMovement(InputAction.CallbackContext context)
    {
        //Las acciones de tipo value deben almacenarse = ReadValue
        moveImput = context.ReadValue<Vector2>();
    }

    public void HandleJump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        }
        
    }

    #endregion



}
