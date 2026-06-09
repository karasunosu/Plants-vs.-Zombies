using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

// Đặt ở prefab card
// Chưa implement object pool

public class PlacementManager : MonoBehaviour, IPointerDownHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] GameObject plantImagePrefab; // sinh ra thang nay, prefab mau cho tat ca plant (dang preview de keo tha, chu ko phai plant that)
    [SerializeField] GameObject previewPrefab;
    SpriteRenderer previewPosDrop;
    PlantCard plantCardSO;
    Sprite plantSprite;
    GameObject plant;
    GameObject realPlant;
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
        tile = GridManager.Instance.GetTileAtWorldPos(plant.transform.position);
        if(tile == null)
        {
            previewPosDrop.enabled = false;
            return;
        }

        previewPosDrop.transform.position = tile.transform.position;
        Debug.Log("pre"+ previewPosDrop.transform.position);

        if(tile.GetComponentInChildren<Plant>() == null)
        {
            previewPosDrop.enabled = true;
            previewPosDrop.transform.position = tile.transform.position;
        }
        else
        {
            previewPosDrop.enabled = false;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        plant = Instantiate(plantImagePrefab, GetMouseWorldPos(eventData), Quaternion.identity);
        plantSprite = plantCardSO.sprite;       
        plant.GetComponent<SpriteRenderer>().sprite = plantSprite; 

        GameObject preview = Instantiate(previewPrefab);
        previewPosDrop = preview.GetComponent<SpriteRenderer>();

        previewPosDrop.sprite = plantSprite;
        previewPosDrop.enabled = false;

        plant.transform.position = GetMouseWorldPos(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Vector3 dropPos = plant.transform.position;
        tile = GridManager.Instance.GetTileAtWorldPos(dropPos);
        if(tile == null || tile.GetComponentInChildren<Plant>() != null)
        {
            Destroy(plant);
            return;
        }
        if(SunController.Instance.currentSun >= plantCardSO.sunCost && tile.GetComponentInChildren<Plant>() == null)
        {
            SunController.Instance.SpendSun(plantCardSO.sunCost);
            Destroy(plant);
            realPlant = plantCardSO.realPlant;
            GameObject rPlant = Instantiate(realPlant, tile.transform.position, Quaternion.identity, tile.gameObject.transform);
            Debug.Log("Local Scale: " + rPlant.transform.localScale);
            Debug.Log("World Scale: " + rPlant.transform.lossyScale);
        }
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
