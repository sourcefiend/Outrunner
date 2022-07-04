using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public float movementSpeed;

    private Rigidbody2D rb;
    private Animator anim;

    public float health;

    private Vector2 movementAmount;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector2 movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        movementAmount = movementInput.normalized * movementSpeed;

        if (movementInput != Vector2.zero) {
            anim.SetBool("isRunning", true);
        } else {
            anim.SetBool("isRunning", false);
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movementAmount * Time.fixedDeltaTime);
    }

    public void TakeDamage(int damageAmount) {

        health -= damageAmount;

        if (health <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Lose");
        }
    }
}
