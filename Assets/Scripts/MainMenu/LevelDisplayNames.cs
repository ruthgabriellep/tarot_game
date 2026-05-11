
public static class LevelDisplayNames
{
    public static string GetDisplayName(string sceneName)
    {
        switch (sceneName)
        {
            case "Main_Menu":
                return "-";
                
            case "The_Forest":
                return "The Woods";

            case "Magician_Level_1":
                return "The Magician's Tower";
            
            case "WindowInspect":
                return "The Magician's Tower";
            
            case "TapestryInspect":
                return "The Magician's Tower";
            
            case "Coast_Transition_Level":
                return "The Magician's Tower";
            
            case "Coast_Puzzle_Level":
                return "The Beach";
            
            case "HighPriestess_Level_1":
                return "The High Priestess' Temple";

            default:
                return sceneName;
        }
    }
}
