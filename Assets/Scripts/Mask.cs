using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mask : MonoBehaviour
{
    
    private Animator anim; 
    public float speed;
    private Rigidbody2D rig;
    public Transform rigthCol;
    public Transform leftCol;
    public LayerMask layer;
    public Transform headPoint;
    public BoxCollider2D boxCollider2D;
    public CircleCollider2D circleCollider2D; 
    private bool colliding;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rig.velocity = new Vector2(speed, rig.velocity.y);
        colliding = Physics2D.Linecast(rigthCol.position, leftCol.position);

        if (colliding)
        {
            transform.localScale = new Vector2(transform.localScale.x * -1f, transform.localScale.y);
            speed = -speed;
        }
    }

    bool PlayerDestroyed;
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            float height = col.contacts[0].point.y - headPoint.position.y;
            
            if(height > 0 && !PlayerDestroyed)
            {
                col.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                speed = 0;
                anim.SetTrigger("die");
                boxCollider2D.enabled = false;
                circleCollider2D.enabled = false;
                rig.bodyType = RigidbodyType2D.Kinematic;
                Destroy(gameObject, 0.33f);
            }
            else
            {
                PlayerDestroyed = true;
                GameController.instance.showGameOver();
                Destroy(col.gameObject);
            }
        }

    }


}
