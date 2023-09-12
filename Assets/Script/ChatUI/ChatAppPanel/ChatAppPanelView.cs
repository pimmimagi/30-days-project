using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ChatAppPanelView : MonoBehaviour
{
    [Header("ChatApp GameObject")]
    
    [SerializeField] private Button HomeButton;
    [SerializeField] private Button BackButton;

    [Header("ChatAppPanel Pod")]
    [SerializeField] private ChatAppPanelPod chatAppPanelPod;
}
