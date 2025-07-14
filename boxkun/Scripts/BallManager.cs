using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 一定時間経過した時にballを生成する
*/

public class BallManager : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private float createTime;
    [SerializeField] private Vector3 createPos;

    private float _timer = 0;

    void Start()
    {
        
    }

    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= createTime)
        {
            Instantiate(ballPrefab, createPos, Quaternion.identity);
            _timer = 0f;
        }
    }
}
