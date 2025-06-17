using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    [SerializeField] private Sprite soundOnSprite;
    [SerializeField] private Sprite soundOffSprite;
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource effectSource;
    private Image buttonImage;
    private bool isMuted;

    private void Start()
    {
        buttonImage = GetComponent<Image>();
        isMuted = PlayerPrefs.GetInt("Muted", 0) == 1;
        ApplySoundState();
    }

    public void ToggleSound()
    {
        isMuted = !isMuted;
        PlayerPrefs.SetInt("Muted", isMuted ? 1 : 0);
        ApplySoundState();
    }

    private void ApplySoundState()
    {
        musicSource.mute = isMuted;
        effectSource.mute = isMuted;
        buttonImage.sprite = isMuted ? soundOffSprite : soundOnSprite;
    }
}
