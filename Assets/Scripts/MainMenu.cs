using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	[Header("Panel")]
	[SerializeField] private GameObject panel; // Panel game object
	
	[Header("Panel Delay Time")]
	[SerializeField] private float delayPanelTime; // Panel delay => pause "several time" after change to black

	private Animator panelAnim;
	
	private void Start()
	{
		panel.SetActive(false);
		panelAnim = panel.GetComponent<Animator>(); // Get the animator component
	}

	public void LoadScene() // Load scene to game scene
	
	{	
		PlayPanelAnimation();
		StartCoroutine(DelayPanelAnim());
	}
	
	public void QuitGame() // Quit game and editor 
    {
	#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
	#else
        Application.Quit();
	#endif
    }

	public void PlayPanelAnimation() // Play panel animation logic
	{
		panel.SetActive(true);
		panelAnim.SetBool("isFade",true);
	}

	public IEnumerator DelayPanelAnim() // Delay Panel logic
	{
		yield return new WaitForSeconds(delayPanelTime);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
