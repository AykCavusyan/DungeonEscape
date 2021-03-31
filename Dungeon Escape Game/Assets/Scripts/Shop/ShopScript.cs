using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class ShopScript : MonoBehaviour
{

    public GameObject _shopPanel;
    public int _currentSelectedItem;
    public int _currentItemCost;

    public PlayerScript player;
    // Start is called before the first frame update
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerGameObject")
        {
            player = collision.GetComponent<PlayerScript>();
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
                _currentSelectedItem = 0;
                _currentItemCost = 200;
        break;
            case 1:
                UIManagerScript.Instance.UpdateShopSelection(-35);
                _currentSelectedItem = 1;
                _currentItemCost = 400;
                break;
            case 2:
                UIManagerScript.Instance.UpdateShopSelection(-135);
                _currentSelectedItem = 2;
                _currentItemCost = 100;
                break;
        }

    }

    public void BuyItem()
    {
        if (player._diamondAmount >= _currentItemCost)
        {

            if (_currentSelectedItem == 2)
            {
                GameManager.Instance._hasKeyToCastle = true;
            }

            //award item
            player._diamondAmount -= _currentItemCost;
            Debug.Log("Purchased" + _currentSelectedItem);
            Debug.Log("Remaining Gem Count : " + player._diamondAmount);
            _shopPanel.SetActive(false);
        }
        else
            Debug.Log("Not enough gems");
        _shopPanel.SetActive(false);
                
    }
}

