using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
//[CreateAssetMenu(fileName = "YuME_editorSetupData", menuName = "Yuponic/Utils", order = 1)]
public class YuME_editorData : ScriptableObject
{
	public Texture2D mapEditorHeader;
	public Texture2D tileImporterHeader;
	public Texture2D tileconverterHeader;
    public List<Texture> primaryIconData = new List<Texture>();
    public List<string> primaryIconTooltip = new List<string>();
    public List<Texture> secondaryIconData = new List<Texture>();
    public List<string> secondaryIconTooltip = new List<string>();
    public List<Texture> selectIconData = new List<Texture>();
    public List<string> selectionIconTooltip = new List<string>();
    public List<Texture> layerIconData = new List<Texture>();
    public List<string> layerNames = new List<string>();
    public List<string> layerIconTooltip = new List<string>();
	public Texture2D configButton;
    public float iconWidth = 32f;
	public Color brushCursorColor;
	public Color pickCursorColor;
	public Color eraseCursorColor;
    public float gridHeight = 0;
    public Color gridColorNormal = Color.white;
    public Color gridColorBorder = Color.green;
    public Color gridColorFill = new Color(1, 0, 0, 0.5F);
    public float gridOffset = 0.01f;
}
