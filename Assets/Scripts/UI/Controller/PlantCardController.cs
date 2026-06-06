using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Read PlantCard SO and display them in the UI
// Trong hierachy, object luu anh plant phai de ten la seed (doan nay hardcode chua biet xu ly sao)

public class PlantCardController : MonoBehaviour
{
    [Header("Cards Parameters")]
    public int amountOfCards;
    public PlantCard[] plantCardSO; // du lieu plant so
    public GameObject plantCardPrefab; // prefab de day du lieu plant vao
    public Transform plantCardTransform;

    [Header("Plants Parameters")]
    private List<GameObject> plantCards;

    private void Start()
    {
        amountOfCards = plantCardSO.Length;
        plantCards = new List<GameObject>();

        for(int i = 0; i < amountOfCards; i++)
        {
            AddPlantCard(i);
        }
    }

    public void AddPlantCard(int index)
    {
        GameObject card = Instantiate(plantCardPrefab, plantCardTransform);

        plantCards.Add(card);

        card.GetComponent<PlantCardView>().setData(plantCardSO[index]);
        card.GetComponent<PlacementManager>().setPlantSO(plantCardSO[index]);
    }
}
