using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkSound : MonoBehaviour
{
    private FMODUnity.StudioEventEmitter eventEmitterRef;
    float count = 1.0f;
    bool soundPlaying = false;
    bool currAtk = false;
    // Start is called before the first frame update
    void Start()
    {
        eventEmitterRef = GetComponent<FMODUnity.StudioEventEmitter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currAtk) {
            if (count > 0){
                count -= Time.deltaTime;
            }
            if (count < 0){
                count = 1.0f;
                currAtk = false;
            }
        } else {
            if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) 
                || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) 
                && !soundPlaying){
                soundPlaying = true;
                eventEmitterRef.Play();
            } else if (((!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) 
                && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D)) 
                && soundPlaying)){
                soundPlaying = false;
                eventEmitterRef.Stop();
            } else if ((!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) 
                && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D)) && Input.GetKeyDown(KeyCode.K)){
                currAtk = true;
            }
        }
    }
}

