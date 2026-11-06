using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptable Objects/EnemyData")]
public class EnemyData : ScriptableObject
{
    public int maxHealth = 1;
    public float speed = 2f;
    public float size = 1f;
    public int scoreValue = 1;
    public Color color = Color.red;
}
