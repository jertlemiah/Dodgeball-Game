using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New LevelData", menuName = "LevelData", order = 1)]
public class LevelDataSO : ScriptableObject
{
    [SerializeField] public SceneIndex sceneIndex;
    [SerializeField] public Color panelColor = Color.blue;
    [SerializeField] public Sprite panelImage;
}
