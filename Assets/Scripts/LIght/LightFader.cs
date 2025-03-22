using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LigntFader : MonoBehaviour
{
    public Light sceneLight; 
    public float fadeDuration = 5f; 
    private float initialIntensity; 

    // Start is called before the first frame update
    void Start()
    {
        if (sceneLight == null)
            sceneLight = GetComponent<Light>(); 

        if (sceneLight != null)
            initialIntensity = sceneLight.intensity; 
    }

    // Update is called once per frame
    void Update()
    {
        if (sceneLight != null)
        {
            
            sceneLight.intensity = Mathf.Lerp(initialIntensity, 0, Time.time / fadeDuration);

            
            if (sceneLight.intensity <= 0.01f)
                sceneLight.intensity = 0;
        }
    }
}
