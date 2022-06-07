using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // I start to reuse scenes at level 4 which is why the manager starts here.
    // All properties should default to false, unless debugging

    // Shares scene with Level 2 (outside)
    public static bool isLevelFour = false;

    // Shares scene with Level 1 (players house)
    public static bool isLevelFive = false;

    // Shares scene with MovieTheatre
    public static bool isLevelSix = false;
}
