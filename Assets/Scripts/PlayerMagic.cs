using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMagic : MonoBehaviour
{
    private GameObject rangeCenter;
    private GameObject mousePointer;

    private Collider[] hitHumans;

    /// <summary>
    /// 魔法の距離
    /// </summary>
    [Header("魔法の距離")]
    [SerializeField]
    private float magicDistance = 3f;
    /// <summary>
    /// 中心角の大きさ
    /// </summary>
    [Header("中心角の大きさ")]
    [SerializeField]
    private float magicAngle = 30f;

    /// <summary>
    /// 現在のMP
    /// </summary>
    private float magicPoint;
    /// <summary>
    /// 最大MP
    /// </summary>
    [Header("最大MP")]
    [SerializeField]
    private float maxMagicPoint = 100f;
    /// <summary>
    /// 消費MP
    /// </summary>]
    [Header("消費MP")]
    [SerializeField]
    private float useMagicPoint = 30f;
    /// <summary>
    /// MP自動回復速度
    /// </summary>
    [Header("MP自動回復速度")]
    [SerializeField]
    private float recoverySpeed = 30f;

    private Slider magicPointSlider;

    void Awake()
    {
        rangeCenter = transform.Find("RangeCenter").gameObject;
        mousePointer = GameObject.Find("MousePointer");
        magicPointSlider = GameObject.Find("MagicPointSlider").GetComponent<Slider>();
    }

    void Start()
    {
        magicPoint = maxMagicPoint;
    }

    void Update()
    {
        UpdateRange();
        UpdateAttack();
    }

    void UpdateRange()
    {
        // マウスの位置を取得
        Vector3 pos = Input.mousePosition;
        // スクリーン座標をワールド座標へ変換
        pos = Camera.main.ScreenToWorldPoint(pos);
        // Rayを下に飛ばす
        Ray ray = new Ray(pos, Vector3.down);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            mousePointer.transform.position = hit.point;

            rangeCenter.transform.LookAt(hit.point);
            rangeCenter.transform.eulerAngles = new Vector3(
                0f, rangeCenter.transform.eulerAngles.y, 0f);
        }
    }

    void UpdateAttack()
    {
        // Human
        int layerMask = 1 << 8;

        // 魔法の射程内の人を取得
        hitHumans = Physics.OverlapSphere(transform.position, magicDistance, layerMask);

        if (Input.GetMouseButtonDown(0))
        {
            // 現在のMPが消費MP以上だったら
            if (magicPoint >= useMagicPoint)
            {
                // MP消費
                magicPoint = magicPoint - useMagicPoint;

                Debug.Log("攻撃");
                //GetComponent<AudioSource>().Play();

                foreach (Collider human in hitHumans)
                {
                    // 射程内の人との角度を求める
                    float dx = human.gameObject.transform.position.x - gameObject.transform.position.x;
                    float dz = human.gameObject.transform.position.z - gameObject.transform.position.z;
                    float rad = Mathf.Atan2(dz, dx) * Mathf.Rad2Deg + rangeCenter.transform.eulerAngles.y;

                    if (rad >= 360f)
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

        if (magicPoint < maxMagicPoint)
        {
            // MP自動回復
            magicPoint += recoverySpeed * Time.deltaTime;
        }
        else
        {
            magicPoint = maxMagicPoint;
        }

        // スライダーの値を更新
        magicPointSlider.value = magicPoint / maxMagicPoint;
    }
}
