using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(MaskableGraphic))]
public class ScreenFader : MonoBehaviour {

	MaskableGraphic m_graphic;
	Color m_color;
	float m_currentAlpha;
	float m_increment;

	public float solidAlpha = 1f;
	public float clearAlpha = 0f;
	public float delay = 1f;
	public float timeToFade = 1f;

	private void Start()
	{
		m_graphic = GetComponent<MaskableGraphic>();
		m_color = m_graphic.color;
		//FadeOff();
	}

	IEnumerator FadeRoutine(float startAlpha, float endAlpha)
	{
		m_graphic.color = new Color(m_color.r, m_color.g, m_color.b, startAlpha);
		m_currentAlpha = startAlpha;

		m_increment = (endAlpha - startAlpha) / timeToFade * Time.deltaTime;

		yield return new WaitForSeconds(delay);

		while (Mathf.Abs(endAlpha - m_currentAlpha) > 0.01)
		{
			yield return null;
			m_currentAlpha += m_increment;
			m_graphic.color = new Color(m_color.r, m_color.g, m_color.b, m_currentAlpha);
		}

		m_currentAlpha = endAlpha;
	}

	public void FadeOn()
	{
		StartCoroutine(FadeRoutine(clearAlpha, solidAlpha));
	}

	public void FadeOff()
	{
		StartCoroutine(FadeRoutine(solidAlpha, clearAlpha));
	}

}
