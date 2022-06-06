using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    private float velocidade;
    private Vector3 direcao;

    CharacterController controller;

    Vector3 vertical;
    Vector3 forward;
    Vector3 strafe;

    float gravity;
    float forwardSpeed = 6f;
    float strafeSpeed = 6f;
    float jumpSpeed;
    float maxJumpHeight = 2f;
    float timeToMaxHeight = 0.5f;

    //===========================//
    public static float VIDA = 100;
    //===========================//

    // Start é chamado antes da atualização do primeiro quadro
    void Start()
    {
        velocidade = 1.5f;
        direcao = Vector3.zero;
        controller = GetComponent<CharacterController>();

        gravity = (-2 * maxJumpHeight) / (timeToMaxHeight * timeToMaxHeight);
        jumpSpeed = (2 * maxJumpHeight) / timeToMaxHeight;
    }

    // A atualização é chamada uma vez por quadro
    void Update()
    {
        //==============================//
        if (VIDA <= 0)
        {
            Debug.Log("morreu");
        }
        //==============================//

        InputPersonagem();

        float forwardInput = Input.GetAxisRaw("Vertical");
        float strafeInput = Input.GetAxisRaw("Horizontal");

        // force = input * speed * direction
        forward = forwardInput * forwardSpeed * transform.forward;
        strafe = strafeInput * strafeSpeed * transform.right;

        vertical += gravity * Time.deltaTime * Vector3.up;

        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
        {
            vertical = jumpSpeed * Vector3.up;
        }

        if (vertical.y > 0 && (controller.collisionFlags & CollisionFlags.Above) != 0)
        {
            vertical = Vector3.zero;
        }

        //transform.Translate(direcao * velocidade * Time.deltaTime);

        Vector3 finalVelocity = forward + strafe + vertical;

        controller.Move(finalVelocity * Time.deltaTime * velocidade);
    }

    void InputPersonagem()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            velocidade = 3f;
        }

        if (Input.GetKeyUp(KeyCode.Tab))
        {
            velocidade = 1.5f;
        }

        direcao = Vector3.zero;

        // Movimentação e andar do personagem quando o mesmo estiver com a seguinte tecla pressioanda
        if (Input.GetKey(KeyCode.W))
        {
            direcao += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direcao += Vector3.back;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direcao += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direcao += Vector3.right;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            controller.height = 0.05f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            controller.height = 0.1f;
        }
    }
}