using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[CreateAssetMenu(fileName = "Level Data", menuName = "Create Data", order = 0)]
public class LevelData : ScriptableObject
{
    public int BlockCountOfFirstLine;
    public int BlockCountOfSecondLine;

    public List<Color> BlockColors;
    public List<Color> CorrectList;
}
