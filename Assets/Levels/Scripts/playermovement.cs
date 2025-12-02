using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    private void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(moveX, 0f, moveZ);
        transform.Translate(move * speed * Time.deltaTime);
    }


    public float jump = 5f;
    private Rigidbody2D rb;
    private bool isGrounded = true;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jump, (ForceMode2D)ForceMode.Impulse); 
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }


    public IEnumerator BoostSpeed(float boostAmount, float boostDuration)
    {
        speed += boostAmount;
        yield return new WaitForSeconds(boostDuration);
    }

    public IEnumerator BoostJump(float boostAmount, float boostDuration)
    {
        jump += boostAmount;
        yield return new WaitForSeconds(boostDuration);
    }


}