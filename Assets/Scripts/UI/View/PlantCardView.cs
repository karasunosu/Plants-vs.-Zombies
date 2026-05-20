using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

// dat o thang card tong

public class PlantCardView : MonoBehaviour
{
    [Header("Plants Parameters")]
    private List<GameObject> plantCards;
    private int sunCost;
    private int cooldown;
    private Sprite cardImage;

    public void setData(PlantCard plantCardSO)
    {
        // Lay du lieu
        sunCost = plantCardSO.sunCost;
        cooldown = plantCardSO.cooldown;
        cardImage = plantCardSO.cardImage;

        // Day du lieu vao card
        transform.Find("seed").GetComponent<Image>().sprite = cardImage;
        GetComponentInChildren<TMP_Text>().text = sunCost.ToString();
    }
}
