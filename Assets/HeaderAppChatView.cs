using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeaderAppChatView : MonoBehaviour
{
    public Button ImageButton;
    public GameObject FullImage;
    void Start()
    {
        SetupButtonListener();
    }

    private void SetupButtonListener()
    {
        ImageButton.onClick.AddListener(() =>
        {
            FullImage.SetActive(true);
        });
    }
}
