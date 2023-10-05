﻿using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class ChatlistView : MonoBehaviour
{
    public ChatCellView ChatlistCellView;
    public SelectChapterView SelectChapterView;
    public HeaderChatUIView headerChatUIView;
    private bool StartFirstTime = true;
    [SerializeField] private CharacterPod characterPod;
    private PlayerPod playerPod;
    private Chapterpod chapterPod;
    public GameObject PopUpProfilePanel;
    private List<GameObject> instantiatedChatCells = new List<GameObject>();
    public GameObject ChatCellPrefab;

    private void Start()
    {
        chapterPod = Chapterpod.Instance;
    }

    public void Init()
    {
        characterPod = CharacterPod.Instance;
        playerPod = PlayerPod.Instance;
        characterPod.LoadCharacterData();
        //UpdateCurrentText();
        
    }
     //TODO Refactor 
 

    public ChatCellView CreateChatCell()
    {
        GameObject newChatCellView = Instantiate(ChatCellPrefab, transform);
        ChatCellView chatCellViewComponent = newChatCellView.GetComponent<ChatCellView>();

        if (chatCellViewComponent != null)
        {
            instantiatedChatCells.Add(newChatCellView);
        }
        else
        {
            Destroy(newChatCellView);
            return null;
        }
        return chatCellViewComponent;
    }

    public void DestroyChatCell()
    {
        foreach (GameObject chatCell in instantiatedChatCells)
        {
            Destroy(chatCell);
        }
        instantiatedChatCells.Clear();
    }


}
    
   



