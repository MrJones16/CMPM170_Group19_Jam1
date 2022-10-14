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

    public void gameStartedMusic(){
        BGM.setParameterByName("gameStart", 1f);
    }

    public void lowEnemiesMusic(){
        BGM.setParameterByName("lowDensity", 1f);
    }

    public void medEnemiesMusic(){
        BGM.setParameterByName("midDensity", 1f);
    }

    public void highEnemiesMusic(){
        BGM.setParameterByName("highDensity", 1f);
    }

    public void endMusic(){
        BGM.setParameterByName("end", 1f);
        BGM.setParameterByName("gameStart", 0f);
        BGM.setParameterByName("lowDensity", 0f);
        BGM.setParameterByName("midDensity", 0f);
        BGM.setParameterByName("highDensity", 0f);
    }
    public void stopMusic(){
        BGM.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
    }

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
