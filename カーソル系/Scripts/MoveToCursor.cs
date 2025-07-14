using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveToCursor : MonoBehaviour
{
    [Header("設定")]
    [SerializeField] private float minSpeed = 1.0f;
    [SerializeField] private float maxSpeed = 10.0f;
    [SerializeField] private Slider speedSlider;
    [SerializeField] private Text speedText;
    //[SerializeField] private GameObject stop;

    private float moveSpeed;
    //private Vector3 targetPos;
    //private bool isMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        // スライダーの範囲を設定
        if (speedSlider != null)
        {
            speedSlider.minValue = minSpeed;
            speedSlider.maxValue = maxSpeed;
            speedSlider.value = minSpeed;
        }

        moveSpeed = speedSlider.value;
    }

    // Update is called once per frame
    void Update()
    {
        // スライダーの値をリアルタイムで更新
        if (speedSlider != null)
        {
            moveSpeed = speedSlider.value;
            string speedstr = moveSpeed.ToString("f2");
            speedText.text = speedstr;
        }

        // カーソルのワールド座標を取得
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        // 現在のオブジェクトの位置
        Vector3 objectPos = transform.position;

        // マウスの方向へ移動（スムーズな移動）
        transform.position = Vector3.MoveTowards(objectPos, mousePos, moveSpeed * Time.deltaTime);
    }
}
