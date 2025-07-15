using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
流れていくオブジェクトにつけるスクリプト
自分のBlockと流れてくるBlockの判定を行う
間違っていればゲームオーバーへ

*/

public class ObjectMover_Blockver2 : MonoBehaviour
{
    private Vector3 _targetPosition;
    private float _speed;

    public void SetTarget(Vector3 target, float moveSpeed)
    {
        _targetPosition = target;
        _speed = moveSpeed;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            _targetPosition,
            _speed * Time.deltaTime
            );

        if (transform.position == _targetPosition)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("greenPlayer") && gameObject.CompareTag("greenPlayer"))
        {
            ScoreManagerBlockver2.Instance.AddScore(1); // 点数を加算
        }
        else if (other.CompareTag("redPlayer") && gameObject.CompareTag("redPlayer"))
        {
            ScoreManagerBlockver2.Instance.AddScore(1); // 点数を加算
        }
        else
        {
            GameOver();
        }
        Destroy(gameObject);
    }

    public void GameOver()
    {
        PlayerPrefs.SetInt("FinalScore", ScoreManagerBlockver2.Instance.GetScore());
        PlayerPrefs.Save();

        SceneManager.LoadScene("GameOverScene");
    }
}
