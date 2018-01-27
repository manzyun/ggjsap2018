using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagic : MonoBehaviour
{
    private GameObject rangePoint;
    private GameObject mousePointer;

    [SerializeField]
    private Collider[] hitHumans;

    /// <summary>
    /// 魔法の距離
    /// </summary>
    [SerializeField]
    private float magicDistance = 3f;
    /// <summary>
    /// 中心角の大きさ
    /// </summary>
    [SerializeField]
    private float magicAngle = 30f;

    void Awake()
    {
        rangePoint = transform.Find("RangePoint").gameObject;
        mousePointer = GameObject.Find("MousePointer");
    }

    void Update()
    {
        UpdateRange();

        int layerMask = 1 << 8;

        // 魔法の射程内の人を取得
        hitHumans = Physics.OverlapSphere(transform.position, magicDistance, layerMask);

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("攻撃");
            //GetComponent<AudioSource>().Play();

            foreach (Collider human in hitHumans)
            {
                float dx = human.gameObject.transform.position.x - gameObject.transform.position.x;
                float dz = human.gameObject.transform.position.z - gameObject.transform.position.z;
                float rad = Mathf.Atan2(dz, dx) * Mathf.Rad2Deg + rangePoint.transform.eulerAngles.y;

                if(rad >= 360f)
                {
                    rad = rad - 360f;
                }

                if (rad >= 90f - magicAngle && rad <= 90f + magicAngle)
                {
                    Destroy(human.gameObject);
                }
            }
        }
    }

    void UpdateRange()
    {
        Vector3 pos = Input.mousePosition;
        pos.z = 0f;
        pos = Camera.main.ScreenToWorldPoint(pos);
        Ray ray = new Ray(pos, Vector3.down);

        Debug.DrawRay(ray.origin, ray.direction, Color.red, 50.0f);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            //Debug.Log(hit.point);
            mousePointer.transform.position = hit.point;

            rangePoint.transform.LookAt(hit.point);
            rangePoint.transform.eulerAngles = new Vector3(
                0f, rangePoint.transform.eulerAngles.y, 0f);
        }
    }
}
