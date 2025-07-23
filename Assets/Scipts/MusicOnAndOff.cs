using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicOnAndOff : MonoBehaviour
{
    public void MusicOnandOff(){
      if(AudioManager.Instan.MusicOn == true){
         Debug.Log("MusicOff");
         AudioManager.Instan.MusicOn = false;
      } else {
         Debug.Log("MusicOn");
         AudioManager.Instan.MusicOn = true;
      }
   }
}
