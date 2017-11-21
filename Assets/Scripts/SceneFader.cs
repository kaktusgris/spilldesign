using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
public class SceneFader : MonoBehaviour {
	#region FIELDS
	public RawImage fadeOutUIImage;
	public Text fadeOutUIText;
	public Text nextText;
	public float fadeSpeed = 0.8f; 
	public float fadeWait = 0.0f;
	//one true for each level to keep track of which texts have been displayed
	private static bool[] scenes = { true, true, true, true, true, true, true, true, true, true };
	public bool deathScreen = false;
	private bool closeText = false;
	private int r = 0; // Random nuber used for death flares
	public enum FadeDirection
	{
		In, //Alpha = 1
		Out // Alpha = 0
	}
	#endregion

	#region MONOBHEAVIOR
	void OnEnable()
	{
		bool showText = scenes [SceneManager.GetActiveScene ().buildIndex - 1];

		if (deathScreen) {
			// Just removes death screen (if the story is to be shown)
			if (showText) {
				fadeOutUIImage.color = new Color (fadeOutUIImage.color.r,fadeOutUIImage.color.g, fadeOutUIImage.color.b, 0);
				fadeOutUIText.color = new Color (fadeOutUIText.color.r,fadeOutUIText.color.g, fadeOutUIText.color.b, 0);
				nextText.color = new Color (nextText.color.r,nextText.color.g, nextText.color.b, 0);
			// Sets text on death screen to a random from list
			} else {
				r = Random.Range (0, deathFlares.Length - 1);
				fadeOutUIText.text = deathFlares [r];
				StartCoroutine (Fade (FadeDirection.Out));
			}
		}
		// Fades text if it should be shown
		else if (showText) {
			StartCoroutine (Fade (FadeDirection.Out));
		} 
		// Just removes story (if it has been shown already)
		else {
			fadeOutUIImage.color = new Color (fadeOutUIImage.color.r,fadeOutUIImage.color.g, fadeOutUIImage.color.b, 0);
			fadeOutUIText.color = new Color (fadeOutUIText.color.r,fadeOutUIText.color.g, fadeOutUIText.color.b, 0);
			nextText.color = new Color (nextText.color.r,nextText.color.g, nextText.color.b, 0);
		}
	}
	void Update() {
		if (Input.GetKey("space")) {
			closeText = true;
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
			yield return new WaitUntil(() => closeText);

			while (alpha >= fadeEndValue)
			{
				SetColorImage (ref alpha, fadeDirection);
				yield return null;
			}
			fadeOutUIImage.enabled = false;
			fadeOutUIText.enabled = false;
			scenes [SceneManager.GetActiveScene ().buildIndex - 1] = false;
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
		nextText.color = new Color (nextText.color.r,nextText.color.g, nextText.color.b, alpha);
		alpha += Time.deltaTime * (1.0f / fadeSpeed) * ((fadeDirection == FadeDirection.Out)? -1 : 1) ;
	}
	#endregion
	#region text
	string[] deathFlares =  {
		"Didn't think so",
		"As expected",
		"What a failure",
		"You lost",
		"What a surprise..",
		"Can you try harder?",
		"Pathetic",
		"XD",
		"Give up",
		"Oh, you lost?",
		"Why are you still trying?",
		"Stop trying and start doing",
		"Did you do it? No",
		"Why are you still here?",
		"And I almost had my hopes in you",
		"Like you could be the one",
		"Please.",
		"You died",
		"Dead again",
		"Need to try harder"
	};
	#endregion
}