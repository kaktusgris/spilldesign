using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
public class SceneFader : MonoBehaviour {
	#region FIELDS
	public RawImage fadeOutUIImage;
	public Text fadeOutUIText;
	public float fadeSpeed = 0.8f; 
	public float fadeWait = 0.0f;
	private static bool[] scenes = { false, false, false, false, false, false, false, false};
	public enum FadeDirection
	{
		In, //Alpha = 1
		Out // Alpha = 0
	}
	#endregion
	#region MONOBHEAVIOR
	void OnEnable()
	{
		if (!scenes [SceneManager.GetActiveScene ().buildIndex - 1]) {
			StartCoroutine (Fade (FadeDirection.Out));
		} else {
			fadeOutUIImage.color = new Color (fadeOutUIImage.color.r,fadeOutUIImage.color.g, fadeOutUIImage.color.b, 0);
			fadeOutUIText.color = new Color (fadeOutUIText.color.r,fadeOutUIText.color.g, fadeOutUIText.color.b, 0);
		}
	}
	#endregion
	#region FADE
	private IEnumerator Fade(FadeDirection fadeDirection) 
	{
		float alpha = (fadeDirection == FadeDirection.Out)? 1 : 0;
		float fadeEndValue = (fadeDirection == FadeDirection.Out)? 0 : 1;
		if (fadeDirection == FadeDirection.Out) {
			yield return new WaitForSeconds (fadeWait);
			while (alpha >= fadeEndValue)
			{
				SetColorImage (ref alpha, fadeDirection);
				yield return null;
			}
			fadeOutUIImage.enabled = false;
			fadeOutUIText.enabled = false;
			scenes [SceneManager.GetActiveScene ().buildIndex - 1] = true;
		} else {
			fadeOutUIImage.enabled = true; 
			while (alpha <= fadeEndValue)
			{
				SetColorImage (ref alpha, fadeDirection);
				yield return null;
			}
		}
	}
	#endregion
	#region HELPERS
	public IEnumerator FadeAndLoadScene(FadeDirection fadeDirection, int sceneToLoad) 
	{
		yield return Fade(fadeDirection);
		UnityEngine.SceneManagement.SceneManager.LoadScene(sceneToLoad);
	}
	private void SetColorImage(ref float alpha, FadeDirection fadeDirection)
	{
		fadeOutUIImage.color = new Color (fadeOutUIImage.color.r,fadeOutUIImage.color.g, fadeOutUIImage.color.b, alpha);
		fadeOutUIText.color = new Color (fadeOutUIText.color.r,fadeOutUIText.color.g, fadeOutUIText.color.b, alpha);
		alpha += Time.deltaTime * (1.0f / fadeSpeed) * ((fadeDirection == FadeDirection.Out)? -1 : 1) ;
	}
	#endregion
}