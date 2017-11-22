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
			fadeOutUIText.text = story [SceneManager.GetActiveScene ().buildIndex - 1];
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
		"Didn't think so.",
		"As expected.",
		"You failed.",
		"You lost.",
		"What a surprise...",
		"Can you try harder?",
		"Well that was entertaining.",
		"I think you can do better. MUCH better",
		"Oh, you lost?",
		"Oh, you're still here?",
		"Impressive, let's try winning this time.",
		"That was... sad.",
		"Why are you still here?",
		"And I almost had faith in you.",
		"Looks like you're not the one.",
		"Oh, please.",
		"You died.",
		"Dead again.",
		"Try harder this time."
	};

	string[] story = {
		"Oh... A new challenger, huh?\nYou must be here for the trial.\n\nWell, let's see what you're made of.",
		"Heh, don't pat yourself on the back yet.\nThat was the easy part.",
		"Well that took long enough,\nbut I'm still not impressed. \n\nLet's see how much control you really have.",
		"Not bad, not bad at all.\nOh, this one is fun. And deadly.",
		"Hmm... you seem to have a knack for this. \nOr maybe you're just lucky? Let's find out.",
		"Wow. You actually made that.\nVery few have made it this far.",
		"I... I...\n\nYou're not quite like the others.\nMaybe you could... Please, continue.",
		"Amazing!\nYou may actually do this!\nOkay, listen. We're getting close... just focus!\n\nI have been in here for so long."
	};
	#endregion
}