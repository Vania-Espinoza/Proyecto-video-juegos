using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jugador1 : MonoBehaviour
{
     public float fuerzaSalto;
     public GameManage gameManager;

     private Rigidbody2D rigidbody2D;
     private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("estasSaltando", true);
            rigidbody2D.AddForce(new Vector2(0, fuerzaSalto));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "suelo")
        {
             animator.SetBool("estasSaltando", false);
        }

        if (collision.gameObject.tag == "obstaculo")
         {
             gameManager.gameOver = true;
        }
    }
}
