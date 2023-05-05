using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource audioSoucerMusicaFundo;
    public AudioClip[] musicasDeFundo;
    
    // Start is called before the first frame update
    void Start()
    {
        int IndexDaMusicaDeFundo = Random.Range(0, 2);
        AudioClip musicaFundo = musicasDeFundo[0];
        audioSoucerMusicaFundo.clip = musicaFundo;
        audioSoucerMusicaFundo.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    public void PararMusica()
    {
        audioSoucerMusicaFundo.Stop();
    }
    public void PausarMusica()
    {
        audioSoucerMusicaFundo.Pause();
    }
    public void PlayMusica()
    {
        audioSoucerMusicaFundo.Play();
    }
    public void ReiniciarMusica()
    {
        audioSoucerMusicaFundo.Play();
    }
    public void ToggleMusic()
    {
        if (audioSoucerMusicaFundo.isPlaying)
        {
            audioSoucerMusicaFundo.Stop();
        }
        else
        {
            audioSoucerMusicaFundo.Play();
        }
    }
}
