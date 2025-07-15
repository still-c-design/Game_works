using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LookBackGameManager : MonoBehaviour
{
    public Canvas canvas;
    public GameObject notLookBackButton;

    public float createDuration = 0.5f;
    public RectTransform spawnArea;
    public float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= createDuration)
        {
            CreateButton();
            timer = 0f;
        }
    }

    void CreateButton()
    {
        GameObject buttonInstance = Instantiate(notLookBackButton, canvas.transform);

        RectTransform rectTransform = buttonInstance.GetComponent<RectTransform>();
        if (rectTransform != null && spawnArea != null)
        {
            float areaWidth = spawnArea.rect.width;
            float areaHeight = spawnArea.rect.height;
            Vector2 areaPosition = spawnArea.anchoredPosition;

            float randomX = Random.Range(areaPosition.x - areaWidth / 2, areaPosition.x + areaWidth / 2);
            float randomY = Random.Range(areaPosition.y - areaHeight / 2, areaPosition.y + areaHeight / 2);
            rectTransform.anchoredPosition = new Vector2(randomX, randomY);
        }
    }
}
