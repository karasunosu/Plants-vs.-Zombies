using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform sunOriginPos;

    void Update()
    {
        CollectSun();
    }

    void CollectSun()
    {
        if (Mouse.current != null && Mouse.current.leftButton.isPressed)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

            RaycastHit2D[] raycasts = Physics2D.RaycastAll(mousePos, Vector2.down);

            foreach(var hit in raycasts)
            {
                if(hit.collider != null && hit.collider.CompareTag(Sun.SUN_TAG))
                {
                    Sun sun = hit.collider.GetComponent<Sun>();

                    if(sun != null)
                    {
                        sun.CollectSun(sunOriginPos);
                    }
                }
            }
        }
    }
}
