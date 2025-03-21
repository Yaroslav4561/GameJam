using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    private Light sceneLight;
    // Start is called before the first frame update
    void Start()
    {
        // Отримуємо компонент Light
        sceneLight = GetComponent<Light>();

        // Встановлюємо початкові параметри світла
        sceneLight.color = Color.white;
        sceneLight.intensity = 1.0f;
        sceneLight.type = LightType.Point;
    }

    

    // Update is called once per frame
    void Update()
    {
        // Зміна інтенсивності світла залежно від часу
        sceneLight.intensity = Mathf.PingPong(Time.time, 2.0f);
    }
}
