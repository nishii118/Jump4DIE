using UnityEngine;

[CreateAssetMenu(fileName = "TileSO", menuName = "ScriptableObjects/Tile")]
public class TileSO : ScriptableObject
{
    public Vector3 positionOffset;  
    public int tileIndex;  
    public int scoreValue;  
}

