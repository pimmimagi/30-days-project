using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HeaderGalleryView : MonoBehaviour
{
    [Header("Button")]
    [SerializeField] private Button BackButton;

    [Header("GameObject")]
    [SerializeField] private GameObject GalleryPanel;

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
            MoveToScene(2);
            chatAppPanelPod.ChangeChatState(ChatAppState.SelectChapter);
        });
    }

    public void MoveToScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
}
