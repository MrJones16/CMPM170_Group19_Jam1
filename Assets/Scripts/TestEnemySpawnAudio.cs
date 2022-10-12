using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemySpawnAudio : MonoBehaviour
{
    private FMODUnity.StudioEventEmitter eventEmitterRef;
    float count = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        eventEmitterRef = GetComponent<FMODUnity.StudioEventEmitter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (count > 0){
            count -= Time.deltaTime;
        }
        if (count < 0){
            eventEmitterRef.Play();
            count = 3.0f;
        }
    }
}
