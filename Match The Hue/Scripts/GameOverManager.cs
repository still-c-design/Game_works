using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    [SerializeField] private KeyCode nextKeyCode;

    [SerializeField] private GameObject _object;

    [SerializeField] private Vector3 rotationSpeed;

    void Start()
    {
        int finalScore = PlayerPrefs.GetInt("FinalScore", 0);
        scoreText.text = "" + finalScore;
    }

    void Update()
    {
        if (Input.GetKeyDown(nextKeyCode))
        {
            StartScene();
        }
        _object.transform.Rotate(rotationSpeed * Time.deltaTime);
    }

    private void StartScene()
    {
        SceneManager.LoadScene("StartScene");
    }
}
