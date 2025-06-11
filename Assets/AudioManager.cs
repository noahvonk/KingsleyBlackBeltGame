using UnityEngine;

public class AudioManager : MonoBehaviour
{
   public static AudioManager Instan;
   [SerializeField] AudioSource musicSource;
   [SerializeField] AudioSource SFXSource;

   public AudioClip TutorialMusic;
   public AudioClip BackgroundMusic;
   public AudioClip Wave25OnwardsMusic;
   public AudioClip Wave50OnwardsMusic;
   public AudioClip Wave75OnwardsMusic;
   public AudioClip FinalWaveMusic;
   public AudioClip Attack;
   public AudioClip Death;
   public AudioClip RecieveDamage;
   public AudioClip WallAttack;

   void Awake(){
        Instan = this;
   }

   private void Start(){
        musicSource.clip = TutorialMusic;
        musicSource.Play();
   }

   public void Update(){
     if(GameManager.Instance.TTS >= 19 && musicSource.clip != BackgroundMusic && GameManager.Instance.wave <= 24){
        Debug.Log("Music Change");
        //musicSource.Stop();
        musicSource.clip = BackgroundMusic;
        musicSource.Play();
        //musicSource.clip.Play();
     } else {

     };

     if(GameManager.Instance.wave >= 25 && musicSource.clip != Wave25OnwardsMusic && GameManager.Instance.wave <= 49){
        musicSource.clip = Wave25OnwardsMusic;
        musicSource.Play();
     } else if (GameManager.Instance.wave >= 50 && musicSource.clip != Wave50OnwardsMusic && GameManager.Instance.wave <= 74){
        musicSource.clip = Wave50OnwardsMusic;
        musicSource.Play();
     } else if (GameManager.Instance.wave >= 75 && musicSource.clip != Wave75OnwardsMusic && GameManager.Instance.wave <= 98){
        musicSource.clip = Wave75OnwardsMusic;
        musicSource.Play();
    } else if (GameManager.Instance.wave >= 99 && musicSource.clip != FinalWaveMusic){
        musicSource.clip = FinalWaveMusic;
        musicSource.Play();
    } else {

   };

}
};
