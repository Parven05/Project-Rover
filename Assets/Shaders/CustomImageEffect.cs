using UnityEngine;

[ExecuteInEditMode]
public class CustomImageEffect : MonoBehaviour {

    public Material material;

    void Start() {
        // Get the camera component attached to this object
        Camera cam = GetComponent<Camera>();

        // If the camera exists
        if (cam != null) {
            // Set the camera's depth texture mode to DepthNormals
            cam.depthTextureMode = DepthTextureMode.DepthNormals;
        } else {
            // If there's no camera, print a warning
            Debug.LogWarning("No camera found attached to this object.");
        }
    }

    void OnRenderImage(RenderTexture src, RenderTexture dest) {
        Graphics.Blit(src, dest, material);
    }
}
