namespace UnityEngine
{
    public class Debug
    {
        public static void LogWarning(string msg) { }
        public static void LogError(string msg) { }
    }

    public static class Mathf
    {
        public static int Abs(int value) => System.Math.Abs(value);
        public static float Abs(float value) => System.Math.Abs(value);
        public static int Clamp(int value, int min, int max) => System.Math.Max(min, System.Math.Min(max, value));
        public static float Clamp(float value, float min, float max) => System.Math.Max(min, System.Math.Min(max, value));
        public static float Clamp01(float value) => Clamp(value, 0f, 1f);
        public static int Min(int a, int b) => System.Math.Min(a, b);
        public static int Max(int a, int b) => System.Math.Max(a, b);
    }

    public static class Random
    {
        private static readonly System.Random _rng = new System.Random();
        public static int Range(int min, int max) => _rng.Next(min, max);
        public static float Range(float min, float max) => (float)(_rng.NextDouble() * (max - min) + min);
    }

    public struct Vector2
    {
        public float x, y;
        public Vector2(float x, float y) { this.x = x; this.y = y; }
    }

    public struct Vector2Int
    {
        public int x, y;
        public Vector2Int(int x, int y) { this.x = x; this.y = y; }
        public static Vector2Int up    => new Vector2Int( 0,  1);
        public static Vector2Int down  => new Vector2Int( 0, -1);
        public static Vector2Int left  => new Vector2Int(-1,  0);
        public static Vector2Int right => new Vector2Int( 1,  0);
        public static Vector2Int zero  => new Vector2Int( 0,  0);
        public static Vector2Int operator +(Vector2Int a, Vector2Int b) => new Vector2Int(a.x + b.x, a.y + b.y);
        public override bool Equals(object obj) => obj is Vector2Int v && v.x == x && v.y == y;
        public override int GetHashCode() => x * 397 ^ y;
    }

    // UPDATED: Added CompareTag
    public class GameObject 
    { 
        public bool CompareTag(string tag) => false;
    }

    // UPDATED: Added CreateInstance<T>
    public class ScriptableObject 
    { 
        public static T CreateInstance<T>() where T : ScriptableObject, new() => new T();
    }

    public class MonoBehaviour { }

    public class SerializeField : System.Attribute { }
    public class CreateAssetMenu : System.Attribute
    {
        public string fileName;
        public string menuName;
    }
    
    public class RangeAttribute : System.Attribute
    {
        public RangeAttribute(float min, float max) { }
        public RangeAttribute(int min, int max) { }
    }

    public class Sprite { }
}

// Game-specific stubs
public enum CellType { Grass, Stone, Dirt }
public enum BackgroundType { None, Stone, Dirt }

public class GridCell
{
    public CellType foreground;
    public BackgroundType background;
}

public class LayerDefinition
{
    public int minY;
    public int maxY;
    public int borderReliefAmplitude;
    public CellType baseBlock;
    public BackgroundType baseBackground;
    public System.Collections.Generic.List<DepositDefinition> deposits;
}

public class DepositDefinition
{
    public int depositsPerLayer;
    public int minBackgroundSize;
    public int maxBackgroundSize;
    public int minForegroundSize;
    public int maxForegroundSize;
    public BackgroundType bgType;
    public CellType oreType;
}

// ==========================================
// UPDATED GAME-SPECIFIC STUBS
// ==========================================

public class BlockTypeData 
{ 
    public int MaxHp;
    public int MinDamage;
    // Returns a list of DropChance (which is compiled in your csproj)
    public System.Collections.Generic.List<DropChance> GetDropTable() => null; 
}

public class Drill : UnityEngine.ScriptableObject 
{ 
    public void SetBasic() {}
    public float Speed;
}

public class FuelTank : UnityEngine.ScriptableObject 
{ 
    public void SetBasic() {}
    public float Capacity;
}

public class Engine : UnityEngine.ScriptableObject 
{ 
    public void SetBasic() {}
    public float Speed;
    public float Power;
}

public class PlayerManager : UnityEngine.MonoBehaviour
{
    public static PlayerManager Instance;
    public UnityEngine.GameObject EquippedItem;
}