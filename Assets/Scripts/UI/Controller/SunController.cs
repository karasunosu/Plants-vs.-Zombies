using TMPro;
using UnityEngine;

public class SunController : MonoBehaviour
{
    public static SunController Instance;

    [SerializeField] TextMeshProUGUI sunText;

    int currentSun = 50;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        UpdateUI();
    }

    public void AddSun(int sun)
    {
        currentSun += sun;
        UpdateUI();
    }

    public void SpendSun(int sun)
    {
        if(currentSun >= sun)
        {
            currentSun -= sun;
            UpdateUI();
        }
    }

    void UpdateUI()
    {
        sunText.text = currentSun.ToString();
    }
}
