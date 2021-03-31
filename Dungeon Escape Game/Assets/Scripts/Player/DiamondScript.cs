using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondScript : MonoBehaviour
{

    
    public int _gems = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerGameObject")

        {

            PlayerScript _playerscript = collision.GetComponent<PlayerScript>();
            if(_playerscript != null)
            {
                _playerscript.AddGems(_gems);
                
                Destroy(gameObject);
            }

        }
    }
}
