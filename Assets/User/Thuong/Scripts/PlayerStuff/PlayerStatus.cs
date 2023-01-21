public static class PlayerStatus
{
    public static int HP ;
    public static int maxHP = 100;
    public static int atk = 100;
    public static int sp = 0;
    public static float speed = 12f;
    public static bool isJump = false;
    // Score
    public static int ScoreRed = 0;
    public static int ScoreYellow = 0;
    public static int ScoreBlue = 0;
    public static int ScoreGreen = 0;

    public enum PlayerMoveState
    {
        None,
        Idle,
        Dash,
        Attack,
        Jump,
        Dodge,
    }

    public static PlayerMoveState playerMoveState = PlayerMoveState.None;

    public enum PlayerModeState
    {
        None,
        Red,
        Yellow,
        Blue,
        Green,
    }

    public static PlayerModeState playerModeState = PlayerModeState.None;

    public enum ObjModeState
    {
        None,
        Red,
        Yellow,
        Blue,
        Green,
        FastStar,
    }
    public static ObjModeState objModeState = ObjModeState.None;
}