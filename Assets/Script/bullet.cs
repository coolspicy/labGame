using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    [SerializeField] public float speed = 3.0f;
    

    [SerializeField] Rigidbody2D rb2d;
    [SerializeField] Vector3 startPos;
   

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = transform.right * speed;

    }

    // Update is called once per frame
    void Update()
    {


    }

   

    void OnTriggerEnter2D(Collider2D other)
    {
        // check hit the ground
        if (other.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }

    public void setSpeed(float a) {
        speed = a;
    }
}
