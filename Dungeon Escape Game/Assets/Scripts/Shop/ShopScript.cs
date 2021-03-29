using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class ShopScript : MonoBehaviour
{

    public GameObject _shopPanel;
    // Start is called before the first frame update
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerGameObject")
        {
            PlayerScript player = collision.GetComponent<PlayerScript>();
            if ( player != null)
            {
                UIManagerScript.Instance.OpenShop(player._diamondAmount);
            }
            _shopPanel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "PlayerGameObject")
        {
            _shopPanel.SetActive(false);
        }
    }

    public void SelectItem(int item)
    {
        switch (item)
        {
            case 0: 
        UIManagerScript.Instance.UpdateShopSelection(62);
        break;
            case 1:
                UIManagerScript.Instance.UpdateShopSelection(-35);
                break;
            case 2:
                UIManagerScript.Instance.UpdateShopSelection(-135);
                break;

        }

    }
}

