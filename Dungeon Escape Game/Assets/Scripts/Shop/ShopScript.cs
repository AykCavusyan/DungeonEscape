using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour
{

    public GameObject _shopPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerGameObject")
        {
            _shopPanel.SetActive(true);
        }
    }
}
