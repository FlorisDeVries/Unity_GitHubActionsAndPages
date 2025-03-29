namespace _Common.Unity
{
    /// <summary>
    /// An enum to keep track of all the currently configure layers inside of the unity editor
    /// </summary>
    public enum UnityLayer
    {
        Default = 0,
        TransparentFX = 1,
        IgnoreRaycast = 2,
        Environment = 3,
        Water = 4,
        UI = 5,
        Player = 6,
        Hostile = 7,
        PlayerProjectile = 8,
        HostileProjectile = 9,
    }
}