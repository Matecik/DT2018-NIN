using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    Color color = Color.black;
    public Color targetColor = Color.white;
    public float changeRate = 0.1f;

    public bool crazyMode = false;
    float crazyHue = 0;
    public float crazySpeed = 0.01f;

    public void PlayGame () {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        SceneManager.LoadSceneAsync("Level1");
    }

    public void EndGame() {
        Application.Quit();
    }

    private void Update()
    {
        Camera cam = Camera.main;
        cam.backgroundColor = color;
        if (crazyMode) {
            color = Color.HSVToRGB(crazyHue, 1, 1);
            crazyHue += crazySpeed;
            if (crazyHue > 1) {
                crazyHue = 0;
            }
        } else {
            color = Color.Lerp(color, targetColor, changeRate * Time.deltaTime);
        }
    }
}
