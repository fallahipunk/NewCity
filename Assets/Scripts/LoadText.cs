using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadText : MonoBehaviour
{
    public int textIndex = 0;
    public TextAsset[] texts;
    public TextAsset[] arabicTexts;
    public Text displayText;
    public ArabicText displayTextArabic;
    public GameObject finalCube;
    public GameObject Reticle;
    public GameObject episodeCanvas;

    private void Awake()
    {
        displayText.text = texts[0].text;
        displayTextArabic.Text = arabicTexts[0].text;
    }

    public void ContinueGame()
    {
        Debug.Log("Getting clicked...");
        textIndex++;
        displayText.text = texts[textIndex].text;
        displayTextArabic.Text = arabicTexts[textIndex].text;
        if (textIndex == texts.Length - 1)
        {
            finalCube.SetActive(true);
            gameObject.SetActive(false);
        }
        Reticle.SetActive(true);
        episodeCanvas.SetActive(false);
    }
}
