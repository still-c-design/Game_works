using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorAvoidance : MonoBehaviour
{
    [Header("設定")]
    [SerializeField] private GameObject target;
    [SerializeField] private float avoidDistance = 2.0f;
    [SerializeField] private float moveSpeed = 3.0f;
    [Space(10)]
    [Header("最大移動距離_X/Y")]
    [SerializeField] private float maxMoveDistance_x = 3.0f;
    [SerializeField] private float maxMoveDistance_y = 3.0f;

    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        if (target == null)
        {
            target = this.gameObject;
        }

        // 初期位置を記録
        startPos = target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // カーソルのワールド座標を取得
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0; 

        // 現在のオブジェクトの位置
        Vector3 objectPos = transform.position;

        // カーソルとオブジェクトの距離を計算
        float distanceToMouse = Vector3.Distance(objectPos, mousePos);

        // 近づいた場合逃げる
        if (distanceToMouse < avoidDistance)
        {
            Vector3 moveDirection = (objectPos - mousePos).normalized;
            Vector3 newPosition = objectPos + moveDirection * moveSpeed * Time.deltaTime;

            float clamped_x = Mathf.Clamp(
                newPosition.x,
                startPos.x - maxMoveDistance_x,
                startPos.x + maxMoveDistance_x
                );

            float clamped_y = Mathf.Clamp(
                newPosition.y,
                startPos.y - maxMoveDistance_y,
                startPos.y + maxMoveDistance_y
                );

            float distanceFromStart = Vector3.Distance(startPos, newPosition);

            // もし最大距離を超えてないなら移動する
            if (distanceFromStart < maxMoveDistance_x)
            {
                transform.position = new Vector3(clamped_x, clamped_y, objectPos.z);
            }
        }
    }
}
