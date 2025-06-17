using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]private AudioSource bgaudioSource;
    [SerializeField] private AudioSource effect;

    [SerializeField] private AudioClip bg;
    [SerializeField] private AudioClip jump;
    [SerializeField] private AudioClip coin;
    // Start is called before the first frame update
    void Start()
    {
        PlayBG(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayBG()
    {
        bgaudioSource.clip = bg;
        bgaudioSource.Play();
    }
    public void PlayCoin()
    {
        effect.PlayOneShot(coin);
    }
    public void PlayJump()
    {
        effect.PlayOneShot(jump);
    }
}
