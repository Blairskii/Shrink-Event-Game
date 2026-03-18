using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class OneShotAudio : MonoBehaviour
{
    [SerializeField] private AudioClip clip; // The audio clip to play as a one-shot

    private AudioSource audioSource;

    private void Awake() // Initialize the audio source reference
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayOneShot() // play the one-shot
    {
        if (clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}