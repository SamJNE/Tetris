using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTheme : MonoBehaviour
{
    public AudioClip[] music = new AudioClip[3];
    private AudioSource gameAudio;
    private AudioClip audio;
    // Start is called before the first frame update
    void Start()
    {
        gameAudio = GetComponent<AudioSource>();
        StartCoroutine(PlayMusic());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator PlayMusic()
    {
        while (true)
        {
            audio = music[Random.Range(0, music.Length)];
            gameAudio.PlayOneShot(audio);
            yield return new WaitForSeconds(audio.length);
        }    
    }


}
