using UnityEngine;

[CreateAssetMenu(fileName ="MinaralDataSO",menuName ="ScriptableObject/Mineral")]
public class MineralDataSO : ScriptableObject
{
    [Header("Mineral Descriptions")]
    public string mineralName;
    public string mineralChallenge;
    public string mineralLore;

    [Header("Mineral Characteristic")]
    public MineralColor mineralColor;
    public MineralWeight mineralWeight;
    public MineralSize mineralSize;

    [Header("Mineral References")]
    public Sprite mineralSprite;
    public GameObject mineralPrefab;
    public ParticleSystem mineralPickParticle;

    public enum MineralWeight { Less, Medium, Heavy };
    public enum MineralSize { Small, Medium, Large };
    public enum MineralColor { BlackIronOre, TranparentGoldOre, BrownOre, WhiteOre, FigureJInRef };
}
