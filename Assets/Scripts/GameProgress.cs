using UnityEngine;

public static class GameProgress 
{
    private static Vector3 pos = Vector3.zero;
    private static float rot = 0;
    private static bool clearStage = false;

    private static int progress = 0;
    private static bool paused = false;
    
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

    public static void SetRot(float newRot)
    {
        rot = newRot;
    }

    public static Vector3 GetPos()
    {
        return pos;
    }

    public static float GetRot()
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

    public static void SetPaused(bool isPaused)
    {
        paused = isPaused;
    }
    
    public static bool GetPaused()
    {
        return paused;
    }
}
