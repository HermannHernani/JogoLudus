using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpAndDonw : MonoBehaviour
{
    public float speed;
    public float moveTime;
    private bool dirUp = true;
    private float timer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dirUp)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }

        timer += Time.deltaTime;
        if (timer >= moveTime)
        {
            dirUp = !dirUp;
            timer = 0f;
        }

    }
}
