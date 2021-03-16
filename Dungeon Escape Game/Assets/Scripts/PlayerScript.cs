using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D _rigid;
    [SerializeField] private float jumpforce = 5.0f;
    [SerializeField] private bool grounded = false;
    [SerializeField] private LayerMask _groundLayer;


    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded == true)
        {
            
            
            _rigid.velocity = new Vector2(_rigid.velocity.x, jumpforce);
            grounded = false;
        }

        RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, Vector2.down, 0.8f, _groundLayer);
        Debug.DrawRay(transform.position, Vector2.down, Color.red);

        if (hitinfo.collider != null)
        {
            grounded = true;
            
        }

        //Horizontal Input for left+right

        float move = Input.GetAxisRaw("Horizontal");
        _rigid.velocity = new Vector2(move, _rigid.velocity.y);
    }

    void JumpFunction()
    {
        
        
       
   
    }
}
