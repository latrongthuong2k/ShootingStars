public static class PlayerStatus
{
    public static int HP ;
    public static int maxHP = 100;
    public static int atk = 100;
    public static int sp = 0;
    public static float speed = 12f;
    public static bool isJump = false;

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
    }

    public static PlayerModeState playerModeState = PlayerModeState.None;

    public enum ObjModeState
    {
        None,
        Red,
        Yellow,
        Blue,
    }

    public static ObjModeState objModeState = ObjModeState.None;
}