using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

// Đặt ở prefab card
// Chưa implement object pool

public class PlacementManager : MonoBehaviour, IPointerDownHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] GameObject plantImagePrefab; // sinh ra thang nay, prefab mau cho tat ca plant (dang preview de keo tha, chu ko phai plant that)

    PlantCard plantCardSO;
    Sprite plantSprite;
    GameObject plant;
    CanvasGroup canvasGroup;
    Tile tile;

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // canvasGroup.blocksRaycasts = false;
        // canvasGroup.alpha = 0.6f;

    }

    public void OnDrag(PointerEventData eventData)
    {
        if(plant == null) return;

        plant.transform.position = GetMouseWorldPos(eventData);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        plant = Instantiate(plantImagePrefab, GetMouseWorldPos(eventData), Quaternion.identity, transform);
        plantSprite = plantCardSO.sprite;       
        plant.GetComponent<SpriteRenderer>().sprite = plantSprite; 

        plant.transform.position = GetMouseWorldPos(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Vector3 dropPos = plant.transform.position;
        tile = GridManager.Instance.GetTileAtWorldPos(dropPos);
        // if() // dieu kien dat cay
        plant.transform.position = tile.transform.position;
    }
    public void setPlantSO(PlantCard plantCard)
    {
        plantCardSO = plantCard;
    }

    private Vector3 GetMouseWorldPos(PointerEventData eventData)
    {
        Vector3 screenPos = eventData.position;

        // khoảng cách từ camera tới mặt phẳng z = 0
        screenPos.z = -Camera.main.transform.position.z;

        Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);

        worldPos.z = 0;

        return worldPos;
    }

    
}
