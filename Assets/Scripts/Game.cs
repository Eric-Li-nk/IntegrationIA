using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Game : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private TextMeshProUGUI gameoverText;
    private bool isGameover = false;
    private bool ended = false;
    private bool isGrounded = false;

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(Vector2.up * 5f, ForceMode2D.Impulse);
        }

        if (isGameover && !ended)
        {
            gameoverText.enabled = true;
            ended = true;
        }
        if (rb.velocity == Vector2.zero)
        {
            isGameover = true;
        }
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.Raycast(rb.transform.position, Vector2.down, 1f, LayerMask.GetMask("Ground")).collider != null;

        if (!isGameover)
        {
            rb.velocity = new Vector2(5f, rb.velocity.y);
        }
        
    }
}
