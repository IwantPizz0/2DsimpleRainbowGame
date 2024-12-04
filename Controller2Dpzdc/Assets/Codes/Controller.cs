using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private int tileTouchCount = 0;

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private LayerMask groundLayerMask;
    [field: SerializeField] public Color accentColor;
    [SerializeField] private Color defaultColor;

    private bool isGrounded = false;
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    private bool canDoubleJump = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        if (moveInput > 0)
            sr.flipX = false;
        else if (moveInput < 0)
            sr.flipX = true;

        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            canDoubleJump = true;
        }

        // Проверка возможности двойного прыжка
        if (canDoubleJump && Input.GetButtonUp("Jump"))
        {
            if (!isGrounded && rb.velocity.y <= 0)
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                canDoubleJump = false;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (layerMaskUtil.layerMaskContainsLayer(groundLayerMask,
            collision.gameObject.layer))
        {
            isGrounded = true;
            ColorTitle(collision.gameObject.GetComponent<SpriteRenderer>());
            canDoubleJump = true;
        }



    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (layerMaskUtil.layerMaskContainsLayer(groundLayerMask,
            collision.gameObject.layer))
        {
            isGrounded = false;
        }
    }
    private void ColorTitle(SpriteRenderer spriteRenderer)
    {
        if (spriteRenderer.color == defaultColor)
        {
            spriteRenderer.color = accentColor;
        }
        else
        {
            spriteRenderer.color = defaultColor;
        }
    }

}