using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_Blockver2 : MonoBehaviour
{
    [SerializeField] private PlayerLane[] playerLanes;

    // Update is called once per frame
    void Update()
    {
        foreach (var lane in playerLanes)
        {
            if (Input.GetKeyDown(lane.toggleKey))
            {
                ToggleActive(lane.objects);
                PlaySound(lane.audioSource, lane.tapSound);
            }
        }
    }

    private void ToggleActive(GameObject[] objects)
    {
        objects[0].SetActive(!objects[0].activeSelf);
        objects[1].SetActive(!objects[1].activeSelf);
    }

    private void PlaySound(AudioSource audioSource, AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}



[System.Serializable]
public class PlayerLane
{
    public GameObject[] objects;
    public KeyCode toggleKey;
    public AudioSource audioSource;
    public AudioClip tapSound;
}
