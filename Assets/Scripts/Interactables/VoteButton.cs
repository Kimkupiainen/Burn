using System.Collections;
using UnityEngine;

public class VoteButton : MonoBehaviour
{
    [SerializeField] private bool m_isYesButton;
    [SerializeField] private Material m_material;
    [SerializeField] private Light[] m_candleLights; // Array to hold the point lights that represent candles
    [SerializeField] private float m_materialAnimationDuration = 1.0f; // Duration of the emission animation
    [SerializeField] private float m_lightAnimationDuration = 1.0f; // Duration of the light color change animation
    [SerializeField] private Color m_acceptanceColor = Color.green; // Color for acceptance
    [SerializeField] private Color m_declineColor = Color.red; // Color for decline
    [SerializeField] private float m_maxIntensity = 0.0f; // Max intensity for the point lights
    [SerializeField] private Color m_emissionColor; // The original emission color
    [SerializeField] AudioClip[] bellclip;
    [SerializeField] AudioClip[] burning;
    [SerializeField] AudioSource burnsource;
    [SerializeField] AudioSource source;

    private Coroutine currentMaterialAnimation;
    private Coroutine currentLightAnimation;

    public void Interact()
    {
        if(!CultistManager.Instance.IsCultistAtTable) {
            return;
        }
        if (m_isYesButton)
        {
            CultistManager.Instance.AcceptCultist();
            if (currentMaterialAnimation != null)
            {
                StopCoroutine(currentMaterialAnimation);
            }
            currentMaterialAnimation = StartCoroutine(AnimateMaterialEmission(m_emissionColor));

            if (currentLightAnimation != null)
            {
                StopCoroutine(currentLightAnimation);
            }
            currentLightAnimation = StartCoroutine(ChangeCandleLights(m_acceptanceColor));
        }
        else
        {
            CultistManager.Instance.DeclineCultist();
            if (currentMaterialAnimation != null)
            {
                StopCoroutine(currentMaterialAnimation);
            }
            currentMaterialAnimation = StartCoroutine(AnimateMaterialEmission(m_emissionColor));

            if (currentLightAnimation != null)
            {
                StopCoroutine(currentLightAnimation);
            }
            currentLightAnimation = StartCoroutine(ChangeCandleLights(m_declineColor));
            burnsource.PlayOneShot(burning[Random.Range(0, burning.Length)]);
        }
    }

    private IEnumerator AnimateMaterialEmission(Color targetColor)
    {
        m_material.EnableKeyword("_EMISSION");
        source.PlayOneShot(bellclip[Random.RandomRange(0, bellclip.Length)]);
        float currentTime = 0;
        Color startColor = m_material.GetColor("_EmissionColor");

        while (currentTime < m_materialAnimationDuration)
        {
            float lerpFactor = Mathf.PingPong(currentTime, m_materialAnimationDuration / 2) / (m_materialAnimationDuration / 2);
            Color interpolatedColor = Color.Lerp(startColor, targetColor, lerpFactor);
            m_material.SetColor("_EmissionColor", interpolatedColor * Mathf.LinearToGammaSpace(1f));

            currentTime += Time.deltaTime;
            yield return null;
        }

        m_material.SetColor("_EmissionColor", startColor);
    }

    private IEnumerator ChangeCandleLights(Color targetColor)
    {
        Color[] initialColors = new Color[m_candleLights.Length];
        float[] initialIntensities = new float[m_candleLights.Length];
        for (int i = 0; i < m_candleLights.Length; i++)
        {
            initialColors[i] = m_candleLights[i].color;
            initialIntensities[i] = m_candleLights[i].intensity;
        }

        for (float t = 0; t < m_lightAnimationDuration; t += Time.deltaTime)
        {
            float normalizedTime = t / m_lightAnimationDuration;
            for (int i = 0; i < m_candleLights.Length; i++)
            {
                m_candleLights[i].color = Color.Lerp(initialColors[i], targetColor, normalizedTime);
                m_candleLights[i].intensity = Mathf.Lerp(initialIntensities[i], m_maxIntensity, normalizedTime);
            }
            yield return null;
        }

        // Wait for a moment before reverting
        yield return new WaitForSeconds(1.0f);

        for (float t = 0; t < m_lightAnimationDuration; t += Time.deltaTime)
        {
            float normalizedTime = t / m_lightAnimationDuration;
            for (int i = 0; i < m_candleLights.Length; i++)
            {
                m_candleLights[i].color = Color.Lerp(targetColor, initialColors[i], normalizedTime);
                m_candleLights[i].intensity = Mathf.Lerp(m_maxIntensity, initialIntensities[i], normalizedTime);
            }
            yield return null;
        }

        for (int i = 0; i < m_candleLights.Length; i++)
        {
            m_candleLights[i].color = initialColors[i];
            m_candleLights[i].intensity = initialIntensities[i];
        }
    }
}
