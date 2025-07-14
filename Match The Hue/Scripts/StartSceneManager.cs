using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class StartSceneManager : MonoBehaviour
{
    [SerializeField] private Button expButton;
    [SerializeField] private GameObject expPanel;
    [SerializeField] private KeyCode endPanel_KeyCode;

    [SerializeField] private Button gameStartButton;
    [SerializeField] private string nextGameSceneName;

    // Start is called before the first frame update
    void Start()
    {
        expPanel.SetActive(false);

        expButton.onClick.AddListener(ShowExpPanel);
        gameStartButton.onClick.AddListener(GameStart);
    }

    // Update is called once per frame
    void Update()
    {
        if (expPanel.activeSelf)
        {
            if (Input.GetKeyDown(endPanel_KeyCode))
            {
                expPanel.SetActive(false);
            }
        }
    }

    private void ShowExpPanel()
    {
        expPanel.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
    }

    private void GameStart()
    {
        SceneManager.LoadScene(nextGameSceneName);
    }
}
