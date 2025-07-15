using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
ゲームの中心となるスクリプト
Blockの生成、テキストの生成、スコアの表示
*/

public class GameManager_Blockver2 : MonoBehaviour
{
    [Header("spawn setting")]
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float spawnInterval = 1.5f;

    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private Transform[] targetPoints;

    [SerializeField] private GameObject greenPrefab;
    [SerializeField] private GameObject redPrefab;

    [Space(20)]
    [Header("UI")]
    [SerializeField] private GameObject speedUpTMP;
    [SerializeField] private Transform uiCanvas;

    [Header("sounds")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip speedupSound;


    private float _scorespeedInterval = 10f;
    private float _speedIncrease = 1.1f;
    private int _score = 0;

    void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    private void CheckSpeedIncrease()
    {
        if (_score >= _scorespeedInterval)
        {
            moveSpeed *= _speedIncrease;
            _score = 0;
            Debug.Log("Speed increased! New speed: " + moveSpeed);

            GenerateSpeedUpText();
        }
    }

    private void GenerateSpeedUpText()
    {
        GameObject _textobj = Instantiate(speedUpTMP, uiCanvas);
        audioSource.PlayOneShot(speedupSound);
        Destroy(_textobj, 2f);
    }

    private IEnumerator SpawnObjects()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnAtAllSpawnPoints();
        }

    }

    private void SpawnAtAllSpawnPoints()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            GameObject prefabToSpawn = Random.value > 0.5f ? greenPrefab : redPrefab;
            GameObject obj = Instantiate(
                prefabToSpawn,
                spawnPoints[i].position,
                Quaternion.identity
                );
            Transform targetPoint = targetPoints[i];
            obj.AddComponent<ObjectMover_Blockver2>().SetTarget(targetPoint.position, moveSpeed);
        }
        CheckSpeedIncrease();
        _score += 3;
    }
}
