using System.Collections;
using UnityEngine;

public class IntroFade : MonoBehaviour
{
    [Header("Panel")]
    [SerializeField] private GameObject panel; // Panel game object
	
    [Header("Panel Delay Time")]
    [SerializeField] private float delayPanelTime; // Panel delay => pause "several time" after change to black

    private Animator panelAnim;
    
    private void Start()
    {

        panelAnim = panel.GetComponent<Animator>(); // Get the animator component
        StartCoroutine(DelayPanelAnim());

    }
    
    public IEnumerator DelayPanelAnim() // Delay Panel logic
    {
        panel.SetActive(true);
        yield return new WaitForSeconds(delayPanelTime);
        panelAnim.SetBool("isFade",true);


    }
}
