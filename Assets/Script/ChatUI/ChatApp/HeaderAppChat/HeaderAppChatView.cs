using UnityEngine;
using UnityEngine.UI;

public class HeaderAppChatView : MonoBehaviour
{
    [Header("Button")]
    [SerializeField] private Button ImageButton;

    [Header("GameObject")]
    [SerializeField] private GameObject FullImage;

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
