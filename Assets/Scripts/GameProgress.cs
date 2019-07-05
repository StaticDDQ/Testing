
public static class GameProgress 
{
    private static int progress = 0;
    
    public static void NextProgress()
    {
        progress += 1;
    }

    public static int GetProgress()
    {
        return progress;
    }
}
