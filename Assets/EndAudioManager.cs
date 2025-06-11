using UnityEngine;

public class EndAudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;

    public AudioClip EndingMusic;

    public void Start(){
        musicSource.clip = EndingMusic;
        musicSource.Play();
    }
}
