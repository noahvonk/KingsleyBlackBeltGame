using UnityEngine;

public class StartAudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;

    public AudioClip TitleMusic;

    public void Start(){
        musicSource.clip = TitleMusic;
        musicSource.Play();
    }
}
