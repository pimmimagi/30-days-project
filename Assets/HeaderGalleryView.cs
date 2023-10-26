using UnityEngine;
using UnityEngine.UI;

public class HeaderGalleryView : MonoBehaviour
{
    [Header("Button")]
    [SerializeField] private Button BackButton;

    [Header("GameObject")]
    [SerializeField] private GameObject GalleryPanel;

    private void Start()
    {
        SetupButtonListener();
    }

    private void SetupButtonListener()
    {
        BackButton.onClick.AddListener(() =>
        {
            GalleryPanel.SetActive(false);
        });
    }
}
