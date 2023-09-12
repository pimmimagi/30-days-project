using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfileImageView : MonoBehaviour
{

    public Button BackButton;
    public GameObject FullImage;
    void Start()
    {
        SetupButtonListener();
    }

    private void SetupButtonListener()
    {
        BackButton.onClick.AddListener(() =>
        {
            FullImage.SetActive(false);
        });
    }
}
