using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoteButton : MonoBehaviour
{
    [SerializeField] private bool m_isYesButton;
    [SerializeField] private Material m_material;
    [SerializeField] private float m_animationDuration = 1.0f; // Duration of the animation
    [SerializeField] private Color m_emissionColor; // The original emission color

    private Coroutine currentAnimation;

    public void Interact()
    {
        if (m_isYesButton)
        {
            CultistManager.Instance.AcceptCultist();
            // Start the emission animation
            if (currentAnimation != null)
            {
                StopCoroutine(currentAnimation);
            }
            currentAnimation = StartCoroutine(AnimateEmission(m_emissionColor));
        }
        else
        {
            CultistManager.Instance.DeclineCultist();
            // Start the emission animation
            if (currentAnimation != null)
            {
                StopCoroutine(currentAnimation);
            }
            currentAnimation = StartCoroutine(AnimateEmission(m_emissionColor));
        }
    }

    private IEnumerator AnimateEmission(Color targetColor)
    {
        // Enable emission on the material
        m_material.EnableKeyword("_EMISSION");

        float currentTime = 0;
        Color startColor = m_material.GetColor("_EmissionColor");

        while (currentTime < m_animationDuration)
        {
            float lerpFactor = Mathf.PingPong(currentTime, m_animationDuration / 2) / (m_animationDuration / 2);
            Color interpolatedColor = Color.Lerp(startColor, targetColor, lerpFactor);
            m_material.SetColor("_EmissionColor", interpolatedColor * Mathf.LinearToGammaSpace(1f));

            currentTime += Time.deltaTime;
            yield return null;
        }

        m_material.SetColor("_EmissionColor", startColor);
    }
}
