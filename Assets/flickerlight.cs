using UnityEngine;

public class FlickerLight : MonoBehaviour
{
    Light flickerLight;
    public float minIntensity = 0f;
    public float maxIntensity = 1f;
    public float flickerSpeed = 0.1f;

    private void Reset()
    {
        flickerLight = GetComponent<Light>();
    }

    private void Update()
    {
        if (flickerLight != null)
        {
            flickerLight.intensity = Mathf.Lerp(minIntensity, maxIntensity, Mathf.PingPong(Time.time * flickerSpeed, 1));

        }
    }
}
