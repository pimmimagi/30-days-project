using UnityEngine;
using UnityEngine.UI;

public class ProfileImageView : MonoBehaviour
{
    [Header("Button")]
    [SerializeField] private Button BackButton;

    [Header("GameObject")]
    [SerializeField] private GameObject FullImage;

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
