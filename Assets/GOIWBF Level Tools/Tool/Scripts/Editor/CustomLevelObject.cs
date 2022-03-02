using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "CustomLevel", menuName = "Custom Level", order = 1)]
public class CustomLevelObject : ScriptableObject
{
    [Header("Metadata")]
    public string LevelName;
    public string Author;
    [TextArea(3, 5)]
    public string Description;

    [Header("Thumbnail")]
    public Texture2D Thumbnail;

    [Header("Scene")]
    public SceneAsset LevelScene;
}
