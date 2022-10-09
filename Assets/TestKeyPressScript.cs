using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestKeyPressScript : MonoBehaviour
{
    private FMODUnity.StudioEventEmitter eventEmitterRef;
    // Start is called before the first frame update
    void Start()
    {
        eventEmitterRef = GetComponent<FMODUnity.StudioEventEmitter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            eventEmitterRef.Play();
        }
    }
}
