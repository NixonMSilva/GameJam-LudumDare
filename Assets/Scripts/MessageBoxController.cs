using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MessageBoxController : MonoBehaviour
{
    [TextArea]
    public string[] messages;

    public GameObject messageBoxText;

    public GameObject previousBtn, nextBtn, closeBtn;

    private TextMeshProUGUI textMesh;

    private int noMessages;
    private int currentIndex = 0;

    private string currentText;

    private void Awake ()
    {
        noMessages = messages.Length;
        if (noMessages > 0)
        {
            textMesh = messageBoxText.GetComponent<TextMeshProUGUI>();
            /* foreach (string txt in messages)
            {
                Debug.Log(txt);
            } */
            currentText = messages[currentIndex];
            textMesh.text = currentText;
            previousBtn.SetActive(false);
            closeBtn.SetActive(false);
        }
    }

    public void NextMessage ()
    {
        if (currentIndex < (noMessages - 1))
        {
            currentIndex++;
            textMesh.text = messages[currentIndex];
            if (currentIndex == (noMessages - 1))
            {
                nextBtn.SetActive(false);
                closeBtn.SetActive(true);
            }
            if (currentIndex > 0)
            {
                previousBtn.SetActive(true);
            }
        }
    }

    public void PreviousMessage ()
    {
        if (currentIndex > 0)
        {
            currentIndex--;
            textMesh.text = messages[currentIndex];
            if (currentIndex == 0)
            {
                previousBtn.SetActive(false);
            }
            if (currentIndex < (noMessages - 1))
            {
                nextBtn.SetActive(true);
                closeBtn.SetActive(false);
            }
        }
    }

    public void CloseText ()
    {
        Destroy(this.gameObject);
    }
}
