using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip correctSound;
    public AudioClip wrongSound;

    public void PlayClick()
    {
        audioSource.PlayOneShot(correctSound);
    }

    public void PlayWrong()
    {
        audioSource.PlayOneShot(wrongSound);
    }
}