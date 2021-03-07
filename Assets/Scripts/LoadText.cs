using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadText : MonoBehaviour
{
    public int textIndex = 0;
    public TextAsset[] texts;
    public Text displayText;
    public GameObject finalCube;
    public GameObject Reticle;
    public GameObject episodeCanvas;

    private void Awake()
    {
        displayText.text = texts[0].text;
    }

    public void ContinueGame()
    {
        textIndex++;
        displayText.text = texts[textIndex].text;
        if (textIndex == texts.Length - 1)
        {
            finalCube.SetActive(true);
            gameObject.SetActive(false);
        }
        Reticle.SetActive(true);
        episodeCanvas.SetActive(false);
    }
}
