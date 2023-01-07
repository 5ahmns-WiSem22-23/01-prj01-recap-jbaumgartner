using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    GameManager gameman;

    [SerializeField]
    Sprite baseSprite;

    [SerializeField]
    Sprite carryingSprite;

    [SerializeField]
    float speed;

    Rigidbody2D ridbod;
    SpriteRenderer spiRen;
    bool carriesItem;

    void Start()
    {
        ridbod = GetComponent<Rigidbody2D>();
        spiRen = GetComponent<SpriteRenderer>();

        spiRen.sprite = baseSprite;
    }
  

    void FixedUpdate()
    {
        //Rotation durch Horizontale Input Achse
        transform.Rotate(0, 0, -Input.GetAxis("Horizontal")*(speed/4));

        //Richtung durch Vertikale Input Achse
        ridbod.velocity = transform.rotation * new Vector2(0, Input.GetAxis("Vertical")) * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Bei Collision mit Item wird altes Item zerstört
        if (collision.CompareTag("Item"))
        {
            spiRen.sprite = carryingSprite;
            Destroy(collision.gameObject);
            carriesItem = true;
        }
        //Bei Collision mit Target wird ein neues Item gespawnt, wenn der Player ein Item mit sich trägt
        else if (collision.CompareTag("Target") && carriesItem)
        {
            spiRen.sprite = baseSprite;
            gameman.SpawnItem();
            GameManager.itemCount++;
            carriesItem = false;
        }
    }
}
