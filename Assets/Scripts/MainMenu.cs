using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	[Header("Panel")]
	[SerializeField] private GameObject panel; // Panel game object
	
	[Header("Mission Text")]
	[SerializeField] private GameObject missionText;
	
	[Header("Panel Delay Time")]
	[SerializeField] private float delayPanelTime; // Panel delay => pause "several time" after change to black
	
	[Header("Mission Text Pause Time")]
	[SerializeField] private float missionTextDuration;

	private Animator panelAnim;
	private Animator missionTextAnim;
	
	private void Start()
	{
		panel.SetActive(false);
		panelAnim = panel.GetComponent<Animator>(); // Get the animator component
		
		missionText.SetActive(false);
		missionTextAnim = missionText.GetComponent<Animator>();
	}

	public void LoadScene() // Load scene to game scene
	
	{	
		PlayPanelAnimation();
		StartCoroutine(MissionTextDuration());
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
	

	public IEnumerator MissionTextDuration()
	{
		missionText.SetActive(true);
		yield return new WaitForSeconds(2.5f);
		missionTextAnim.SetBool("isFade", true);
		yield return new WaitForSeconds(missionTextDuration);
		missionTextAnim.SetBool("isFade", false);
	}
}
