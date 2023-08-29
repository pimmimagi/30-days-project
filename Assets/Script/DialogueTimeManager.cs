using System.Collections.Generic;

public static class DialogueTimeManager
{
    private static Dictionary<int, float> dialogue_Times = new Dictionary<int, float>();

    public static void SetDialogueTime(int nodeId, float time)
    {
        if (dialogue_Times.ContainsKey(nodeId))
        {
            dialogue_Times[nodeId] = time;
        }
        else
        {
            dialogue_Times.Add(nodeId, time);
        }
    }

    public static float GetDialogueTime(int nodeId)
    {
        if (dialogue_Times.ContainsKey(nodeId))
        {
            return dialogue_Times[nodeId];
        }
        return 0f; 
    }
}