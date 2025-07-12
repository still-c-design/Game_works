using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProbabilityButton : MonoBehaviour
{
    public Text scoreText;
    private int score = 2;

    public Text highScoreText;
    private int highscore = 0;

    private GameObject button1;
    private GameObject button2;

    // Start is called before the first frame update
    void Start()
    {
        CreateButton();
        //highscore = PlayerPrefs.GetInt("HighScore", 0);

        UpdateHighScoreText();
    }

    void CreateButton()
    {
        // ボタン1
        button1 = CreateButton("Button1", new Vector2(-431f, -100f));
        button1.GetComponent<Button>().onClick.AddListener(() => ButtonClicked(button1));

        // ボタン2
        button2 = CreateButton("Button2", new Vector2(431f, -100f));
        button2.GetComponent<Button>().onClick.AddListener(() => ButtonClicked(button2));
    }

    GameObject CreateButton(string buttonText, Vector2 position)
    {
        GameObject button = new GameObject(buttonText);
        button.transform.SetParent(this.transform);
        button.AddComponent<RectTransform>();
        button.AddComponent<Button>();

        RectTransform rt = button.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(185f, 310f);
        rt.anchoredPosition = position;

        Text text = button.AddComponent<Text>();
        text.text = buttonText;
        text.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");

        rt.localScale = Vector3.one;

        return button;
    }

    void ButtonClicked(GameObject clickedButton)
    {
        bool isWinner = Random.Range(0, 2) == 0; // ランダムで当たりかはずれかを決定

        if (isWinner)
        {
            // 当たりの場合、スコアを倍に増やす
            score *= 2;
            Debug.Log("Winner! New Score: " + score);
            UpdateScore(score);
        }
        else
        {
            // はずれの場合、スコアを元に戻す
            score = 2;
            Debug.Log("Loser! Score reset to: " + score);
        }

        // スコアをテキストに反映
        UpdateScoreText();

        Destroy(button1);
        Destroy(button2);

        CreateButton();
    }

    void UpdateScoreText()
    {
        scoreText.text = "" + score.ToString();
    }

    void UpdateHighScoreText()
    {
        highScoreText.text = "最高記録 : " + highscore.ToString();
    }

    void UpdateScore(int points)
    {
        score += points;

        if(score > highscore)
        {
            highscore = score;

            //PlayerPrefs.SetInt("HighScore", highscore);

            UpdateHighScoreText();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
