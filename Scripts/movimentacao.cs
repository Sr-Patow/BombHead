using UnityEngine;

public class movimentacao : MonoBehaviour
{

    public float velocidade;
    private Vector2 direcao;
    private Rigidbody2D rb;

    private bool grounded;

    void OnCollisionStay(Collision collisionInfo)
    {
        // Check if the collision normal is pointing upwards (prevents grounding on walls)
        foreach (ContactPoint contact in collisionInfo.contacts)
        if (contact.normal.y > 0.5) 
        // A threshold to determine if the surface is horizontal enough
        {
            grounded = true;
            return;
             // Exit the loop once ground is found
        }
    }
    
    void OnCollisionExit(Collision col)
    {
        grounded = false;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent <Rigidbody2D> ();
    }

    // Update is called once per frame
    void Update()
    {
        direcao = Vector2.zero;

        if(Input.GetKey(KeyCode.Space) && grounded)
        {
           rb.AddForce(Vector2.up * velocidade);        

        }

        if(Input.GetKey(KeyCode.A))
        {
            direcao += Vector2.left;
        }

        if(Input.GetKey(KeyCode.D))
        {
            direcao += Vector2.right;
        }

        
        transform.Translate(direcao * velocidade * Time.deltaTime);

    }
    
}
