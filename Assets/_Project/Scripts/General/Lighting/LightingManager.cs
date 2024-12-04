using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class LightingManager : MonoBehaviour
{
    public static LightingManager Instance;

    [SerializeField] private Light directionalLight;
    [SerializeField] private LightingPreset preset;

    [SerializeField, Range(0, 190)] public float timeOfDay;

    [SerializeField] private bool isTimeFrozen = false;
    public bool start = false;


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    void Update()
    {
        if (isTimeFrozen)
            return;

        if (preset == null)
            return;


        if(Application.isPlaying)
        {
            if (!start)
                return;

            timeOfDay += Time.deltaTime;
            timeOfDay %= 190;
            UpdateLighting(timeOfDay / 190f);
        }
        else
        {
            UpdateLighting(timeOfDay / 190f);
        }
    }

    private void UpdateLighting(float timePercent)
    {
        RenderSettings.ambientLight = preset.AmbientColor.Evaluate(timePercent);
        RenderSettings.fogColor = preset.FogColor.Evaluate(timePercent);

        if(directionalLight != null)
        {
            float _offset = 0.35f * (0.6f - timePercent);


            directionalLight.color = preset.DirectionalColor.Evaluate(timePercent);
            directionalLight.transform.localRotation = Quaternion.Euler(new Vector3(((timePercent + _offset) * 360f) -70f, -170, 0));
        }
    }

    //Tenta encontrar um Directional Light caso nao tenha um setado
    private void OnValidate()
    {
        if (directionalLight != null)
            return;

        if (RenderSettings.sun != null)
            directionalLight = RenderSettings.sun;

        else
        {
            Light[] lights = GameObject.FindObjectsByType<Light>(FindObjectsSortMode.None);
            foreach (Light light in lights)
            {
                if(light.type == LightType.Directional)
                {
                    directionalLight = light;
                    return;
                }
            }
        }
    }
}
