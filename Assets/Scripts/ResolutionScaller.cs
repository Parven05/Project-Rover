using UnityEngine;

public class ResolutionScaller : MonoBehaviour
{
    [SerializeField] [Range(0,1)] private float resolutionScale;
    [SerializeField] private Vector2 minResolution;
    [SerializeField] private Vector2 maxResolution;

    [SerializeField] private Vector2 currentResolution;

    void Start()
    {
        Resolution[] resolutions = Screen.resolutions;

        foreach (Resolution resolution in resolutions)
        {
            Debug.Log($"{resolution.width} X {resolution.height} RefreshRate {resolution.refreshRateRatio}");
        }

        //minResolution = new Vector2(resolutions[0].width, resolutions[0].height);
        minResolution = new Vector2(resolutions[(resolutions.Length / 2) - 1].width, resolutions[(resolutions.Length / 2) - 1].height);
        maxResolution = new Vector2(resolutions[^1].width, resolutions[^1].height);

        SetResolution();
    }


    void SetResolution()
    {
        int width = Mathf.RoundToInt(Mathf.Lerp(minResolution.x, maxResolution.x, resolutionScale));
        int height = Mathf.RoundToInt(Mathf.Lerp(minResolution.y, maxResolution.y, resolutionScale));

        Screen.SetResolution(width, height, FullScreenMode.ExclusiveFullScreen);

        currentResolution = new Vector2(width, height);
    }
}
