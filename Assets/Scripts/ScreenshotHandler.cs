using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenshotHandler : MonoBehaviour
{
    private Camera camera;
    private bool takeScreenshot;

    private void Awake() {
        camera = gameObject.GetComponent<Camera>();
    }

    private void OnPostRender() {
        if(takeScreenshot){
            takeScreenshot = false;
            RenderTexture renderTexture = camera.targetTexture;
            Texture2D renderResult = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false);
            Rect rect = new Rect(0,0, renderTexture.width, renderTexture.height);
            renderResult.ReadPixels(rect, 0,0);

            byte[] byteArray =  renderResult.EncodeToPNG();
            System.IO.File.WriteAllBytes(Application.dataPath + "/pmw-picture" + Time.deltaTime + ".png", byteArray);
            RenderTexture.ReleaseTemporary(renderTexture);
            camera.targetTexture = null;
        }
    }

    public void TakeScreenshot(){
        camera.targetTexture = RenderTexture.GetTemporary(Screen.width, Screen.height, 16);
        takeScreenshot = true;
    }
}
