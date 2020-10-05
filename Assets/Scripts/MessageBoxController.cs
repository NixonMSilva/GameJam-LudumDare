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

    public bool destroyOnClose = false;

    private TextMeshProUGUI textMesh;

    private int noMessages;
    private int currentIndex = 0;

    private string currentText;

    public bool fireEventUponClose = false;
    public int eventToFire;

    private GameObject eventController;

    private void Awake ()
    {
        noMessages = messages.Length;
        Initialization();
        if (fireEventUponClose)
        {
            eventController = GameObject.FindGameObjectWithTag("EventController");
        }
    }

    private void Initialization ()
    {
        if (noMessages > 0)
        {
            textMesh = messageBoxText.GetComponent<TextMeshProUGUI>();
            currentText = messages[currentIndex];
            textMesh.text = currentText;
            if (noMessages == 1)
            {
                nextBtn.SetActive(false);
                previousBtn.SetActive(false);
                closeBtn.SetActive(true);
            }
            else
            {
                previousBtn.SetActive(false);
                closeBtn.SetActive(false);
            }
            Time.timeScale = 0f;
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
        if (fireEventUponClose)
        {
            eventController.GetComponent<EventController>().FireEvent(eventToFire);
        }

        if (destroyOnClose)
        {
            Destroy(this.gameObject);
        }
        else
        {
            ResetText();
            gameObject.SetActive(false);
        }
        Time.timeScale = 1f;
    }

    private void ResetText ()
    {
        currentIndex = 0;
        textMesh.text = messages[currentIndex];
        Initialization();
    }

    public void SetEventController (GameObject ec)
    {
        eventController = ec;
    }
}
