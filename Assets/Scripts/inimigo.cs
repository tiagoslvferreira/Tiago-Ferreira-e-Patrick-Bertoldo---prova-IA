using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigo : MonoBehaviour
{
    public float speed;
    public Rigidbody2D inimigorb;
    private bool face;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

    }

    private void Flip()
    {
        if(face)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D col) 
    {
         if(col.collider.CompareTag("playerATT"))
        {
            Destroy(this.gameObject);
        }

        if(col != null  && !col.collider.CompareTag("chao"))
        {
            face = !face;
        }

        Flip();

       
    }

    

   
}
