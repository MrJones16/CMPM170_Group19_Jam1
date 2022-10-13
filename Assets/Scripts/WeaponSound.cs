using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSound : MonoBehaviour
{
    private FMODUnity.StudioEventEmitter eventEmitterRef;
    float count = 1.0f;
    bool soundPlaying = false;
    // Start is called before the first frame update
    void Start()
    {
        eventEmitterRef = GetComponent<FMODUnity.StudioEventEmitter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K) && !soundPlaying && 
        (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) 
        && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))){
            eventEmitterRef.Play();
            soundPlaying = true;
        }
        if (soundPlaying){
            if (count > 0){
                count -= Time.deltaTime;
            }
            if (count < 0){
                count = 1.0f;
                soundPlaying = false;
            }
        }
    }
}
