using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField]
    GameManager gm;

    [SerializeField]
    float speed;

    //hier wird ein Rigidbody zugewiesen
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }



    private void FixedUpdate()
    {   //Rotation durch die Horizontale Achse
        transform.Rotate(0, 0, -Input.GetAxis("Horizontal")*(speed/4));

        //Vorwärts und Rückwärts Bewegung durch Vertikale Achse
        rb.velocity = transform.rotation * new Vector2(0, Input.GetAxis("Vertical")) * speed;
    }

    //hier wird überprüft ob es kollidiert, wenn Item kollidiert wird altes Collectable zerstört und ein neues gespawnt
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Collectable"))
        {
            gm.SpawnCollectable();
            Destroy(collision.gameObject);
        }
    }
}
