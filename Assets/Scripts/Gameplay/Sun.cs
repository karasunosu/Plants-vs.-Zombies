using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Sun : MonoBehaviour
{
    [SerializeField] int sunValue = 25;
    [SerializeField] float fallSpeed = 1f;
    [SerializeField] float flySpeed = 5f;

    Vector3 targetPos;

    public void Init(Vector3 pos)
    {
        targetPos = pos;

        StopAllCoroutines();
        StartCoroutine(FallCoroutine());
    }

    IEnumerator FallCoroutine()
    {
        while(Vector3.Distance(transform.position, targetPos) > 0.05f) // lay so dai khai thoi
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, fallSpeed * Time.deltaTime);

            yield return null;
        }

        transform.position = targetPos;
    }

    public void CollectSun(Transform sunOriginPos)
    {
        StopAllCoroutines();
        StartCoroutine(CollectSunCoroutine(sunOriginPos));
    }
    IEnumerator CollectSunCoroutine(Transform sunOriginPos)
    {
        while(Vector3.Distance(transform.position, sunOriginPos.position) > 0.05f) // lay so dai khai thoi
        {
            // move to origin pos (sun bar)
            transform.position = Vector3.MoveTowards(transform.position, sunOriginPos.position, flySpeed * Time.deltaTime);

            yield return null;
        }
        SunController.Instance.AddSun(sunValue);

        PoolManager.Instance.Return(PoolType.Sun, this.gameObject);
    }

    public const string SUN_TAG = "Sun";
}
