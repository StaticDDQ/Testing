using UnityEngine;

public static class GameProgress 
{
    private static Vector3 pos;
    private static Vector3 rot;
    private static bool clearStage = false;

    private static int progress = 0;
    
    public static void NextProgress()
    {
        progress += 1;
    }

    public static int GetProgress()
    {
        return progress;
    }

    public static void SetPos(Vector3 newPos)
    {
        pos = newPos;
    }

    public static void SetRot(Vector3 newRot)
    {
        rot = newRot;
    }

    public static Vector3 GetPos()
    {
        return pos;
    }

    public static Vector3 GetRot()
    {
        return rot;
    }

    public static void ClearedStage(bool hasCleared)
    {
        clearStage = hasCleared;
    }

    public static bool GetClearState()
    {
        return clearStage;
    }
}
