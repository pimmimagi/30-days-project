using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NotificationCellView : MonoBehaviour
{
    public GameObject NotificationPopUp;
    public GameObject NumberOfNotification;
    public TMP_Text NotificationText;
    public Image CharacterImage;
    public TMP_Text CharacterNameText;
    private CharacterPod characterpod;

    public void Bind(CharacterBean data)
    {
        CharacterImage.sprite = data.characterData.ProfileSprite;
        CharacterNameText.text = data.characterData.NameText;
    }

    public void SetActive()
    {
        Invoke("HideShowNotificationPopup", 1);
        Invoke("HideShowNotificationNumber", 1);
        
    }

    IEnumerator RemoveAfterSeconds(int seconds, GameObject obj)
    {
        yield return new WaitForSeconds(seconds);
        obj.SetActive(false);
    }
    void HideShowNotificationPopup()
    {
        if (NotificationPopUp.active)
            NotificationPopUp.SetActive(false);
        else
            NotificationPopUp.SetActive(true);
    }

    void HideShowNotificationNumber()
    {
        if (NumberOfNotification.active)
            NumberOfNotification.SetActive(false);
        else
            NumberOfNotification.SetActive(true);
    }
}

