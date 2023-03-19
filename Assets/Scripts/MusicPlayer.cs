using System.Collections;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioClip intro;
    public AudioClip loop;
    public float timeUntilLoop = 1.19f;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        AudioSource introsource = gameObject.AddComponent<AudioSource>();
        AudioSource loopsource = gameObject.AddComponent<AudioSource>();
        loopsource.playOnAwake = false;

        introsource.clip = intro;
        introsource.Play();

        yield return new WaitForSeconds(timeUntilLoop);

        loopsource.clip = loop;
        loopsource.loop = true;
        loopsource.Play();
    }
}
