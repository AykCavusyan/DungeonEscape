using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerScript : MonoBehaviour
{
    public Image[] lifeImages;

    private static UIManagerScript _instance;
    public static UIManagerScript Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("null");
            }
            return _instance;
        }
    }

    public Text _playerGamCountText;
    public Image _selectionSlider;
    public Text _gemCount;

   


    private void Awake()
    {
        _instance = this;
    }
    public void UpdateShopSelection(int yPosition)
    {
        _selectionSlider.rectTransform.anchoredPosition = new Vector2(_selectionSlider.rectTransform.anchoredPosition.x, yPosition);
    }


    public void OpenShop(int gemCount)
    {
        _playerGamCountText.text = "" + gemCount + "G";
    }

    public void UpdateGemCount(int count)
    {
        _gemCount.text = "" + count;
    }

    public void UpdateLives(int livesRemaining)
    {
        lifeImages[livesRemaining].enabled = false;
    }
}
