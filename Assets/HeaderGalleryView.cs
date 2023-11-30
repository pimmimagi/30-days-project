using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HeaderGalleryView : MonoBehaviour
{
    [Header("Button")]
    [SerializeField] private Button BackButton;
    [SerializeField] private Button BackFullImageButton;

    [Header("GameObject")]
    [SerializeField] private GameObject GalleryPanel;
    [SerializeField] private GameObject FullImagePanel;

    [Header("Pod")]
    private ChatAppPanelPod chatAppPanelPod;

    private void Start()
    {
        chatAppPanelPod = ChatAppPanelPod.Instance;
        SetupButtonListener();
    }

    private void SetupButtonListener()
    {
        BackButton.onClick.AddListener(() =>
        {
            GalleryPanel.SetActive(false);
            MoveToScene(0);
            chatAppPanelPod.ChangeChatState(ChatAppState.SelectChapter);
        });

        BackFullImageButton.onClick.AddListener(() =>
        {
            FullImagePanel.SetActive(false);
        });
    }

    public void MoveToScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
}
