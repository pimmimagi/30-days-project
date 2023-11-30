using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HistoryCallHeaderView : MonoBehaviour
{
    [Header("Button")]
    [SerializeField] private Button BackButton;

    [Header("GameObject")]
    [SerializeField] private GameObject HistoryCallPanel;

    private void Start()
    {
        SetupButtonListener();
    }

    private void SetupButtonListener()
    {
        BackButton.onClick.AddListener(() =>
        {
            MoveToScene(0);
        });
    }

    public void MoveToScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
}
