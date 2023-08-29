using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System.Linq;


public class BackgroundConversationPod : MonoBehaviour
{
    public ReactiveProperty<BackgroundConversationState> backgroundConversationState = new ReactiveProperty<BackgroundConversationState>(BackgroundConversationState.Mansion_Day);
    public ReactiveProperty<int> currentScore = new ReactiveProperty<int>(0);

    public List<BackgroundConversationScriptableObject> backgroundConversaionBeanList;



    public void ChangeBackgroundConversationState(BackgroundConversationState newState)
    {
        backgroundConversationState.Value = newState;
    }

    public void ChangeScore(int score)
    {
        currentScore.Value = score;
    }
}
