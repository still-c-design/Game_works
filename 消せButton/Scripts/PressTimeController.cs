using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressTimeController : MonoBehaviour
{
    public Image targetImage;
    public Button targetbutton;
    public float duration = 5.0f;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clickSound;

    private float elapsedTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        targetbutton.onClick.AddListener(() => OnButtonClicked());
        if (audioSource != null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (targetImage != null && elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float fillValue = Mathf.Lerp(1f, 0f, elapsedTime / duration);
            targetImage.fillAmount = fillValue;

            if (fillValue == 0f)
            {
                Debug.Log("Game Over");
            }
        }

    }

    void OnButtonClicked()
    {
        audioSource.PlayOneShot(clickSound);
        Destroy(this.gameObject, 0.1f);
    }
}
