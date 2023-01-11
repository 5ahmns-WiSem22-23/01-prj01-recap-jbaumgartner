using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    GameManager gm;

    [SerializeField]
    Sprite baseSprite;

    [SerializeField]
    Sprite carryingSprite;

    [SerializeField]
    float speed;

    Rigidbody2D rb;
    SpriteRenderer spRen;
    bool carriesCollectable;

    //hier wird ein Rigidbody zugewiesen
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spRen = GetComponent<SpriteRenderer>();

        spRen.sprite = baseSprite;
    }

    void FixedUpdate()
    {

        //Vorwärts und Rückwärts Bewegung durch Vertikale Achse
        rb.velocity = transform.rotation * new Vector2(0, Input.GetAxis("Vertical")) * speed;

        //Rotation durch die Horizontale Achse
        transform.Rotate(0, 0, -Input.GetAxis("Horizontal")*(speed/4));
    }

    //hier wird überprüft ob es kollidiert, wenn Item kollidiert wird altes Collectable zerstört und ein neues gespawnt
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Bei Collision mit Item wird altes Item zerstört
        if (collision.CompareTag("Collectable"))
        {
            spRen.sprite = carryingSprite;
            Destroy(collision.gameObject);
            carriesCollectable = true;
        }
        //Bei Collision mit DropOff spawnt ein neues Collectable
        else if (collision.CompareTag("DropOff") && carriesCollectable)
        {
            spRen.sprite = baseSprite;
            gm.SpawnCollectable();
            GameManager.CollectableCount++;
            carriesCollectable = false;
        }
    }
}
