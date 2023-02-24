using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpPower;
    public float dropHeight;

    Rigidbody2D rb;

    public LayerMask passThroughPlatform;
    public LayerMask defaultLayer;

    public bool canJump;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Jump") && canJump)
        {
            rb.velocity = new Vector2(0, 0);
            rb.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
        }
        if (Input.GetButtonDown("Down"))
        {
            gameObject.layer = passThroughPlatform;
            transform.position = new Vector2(transform.position.x, transform.position.y - dropHeight);
        }
        if (Input.GetButtonUp("Down"))
        {
            gameObject.layer = defaultLayer;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(!canJump)
            canJump = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        canJump = false;
    }

}
