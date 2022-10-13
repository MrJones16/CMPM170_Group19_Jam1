using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class musicControl : MonoBehaviour
{
    // Start is called before the first frame update
    [FMODUnity.EventRef]
    public string backgroundMusic = "event:/AdaptiveMusic";
    
    FMOD.Studio.EventInstance BGM;

    void Start()
    {
        BGM = FMODUnity.RuntimeManager.CreateInstance(backgroundMusic);
        BGM.start();
    }

    //public void gameStartedMusic(){
        //BGM.setParameterValue("gameStart", 1f);
    //}

    // public void lowEnemiesMusic(){
    //     BGM.setParameterValue("firstWave", 1f);
    // }

    // public void medEnemiesMusic(){
    //     BGM.setParameterValue("secondWave", 1f);
    // }

    // public void highEnemiesMusic(){
    //     BGM.setParameterValue("thirdWave", 1f);
    // }

    // public void lowHPlowMusic(){
    //     BGM.setParameterValue("lowHPfirstWave", 1f);
    // }

    // public void lowHPmedMusic(){
    //     BGM.setParameterValue("lowHPsecondWave", 1f);
    // }

    // public void lowHPhighMusic(){
    //     BGM.setParameterValue("lowHPthirdWave", 1f);
    // }

    // Update is called once per frame
    void Update()
    {
        
    }
}
