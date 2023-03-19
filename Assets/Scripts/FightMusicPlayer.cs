using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightMusicPlayer : MonoBehaviour
{
    public AudioClip intro;
    public AudioClip loop;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        AudioSource introsource = gameObject.AddComponent<AudioSource>();

        introsource.clip = intro;
        introsource.Play();

        yield return new WaitForSeconds(intro.length);

        introsource.clip = loop;
        introsource.loop = true;
        introsource.Play();
    }
}
