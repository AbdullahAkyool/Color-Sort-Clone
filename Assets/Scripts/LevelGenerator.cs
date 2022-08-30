using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Dreamteck.Splines.Primitives;
using UnityEngine;

public class LevelGenerator : MonoSingleton<LevelGenerator>
{
    public LevelData _levelData;
    public GameObject BlockPrefab;

    [SerializeField] private List<Color> spawnedBlocksColors = new List<Color>(); //spawnlanan kartların renklerinin listesi
    private void Start()
    {
        CreateBlocks();
    }

    public void CreateBlocks()
    {
        Vector3 SpawnPos = new Vector3(0, 0, 0);
        for (int i = 0; i < _levelData.BlockCountOfFirstLine + _levelData.BlockCountOfSecondLine; i++)
        {
            if (i == _levelData.BlockCountOfFirstLine) //ilk sıra spawnlandıysa ikinci sıraya geçilir
            {
                SpawnPos.x = 3;
                SpawnPos.z = 0;
                SpawnPos.y = 0;
            }
            GameObject _block= Instantiate(BlockPrefab, SpawnPos,Quaternion.Euler(90,0,0));
            _block.GetComponent<MeshRenderer>().material.color = _levelData.BlockColors[i];
            _block.GetComponent<Block>().blockIndex = i;
            spawnedBlocksColors.Add(_block.GetComponent<MeshRenderer>().material.color);
            SpawnPos.z -= 2;
            SpawnPos.y += .5f;
        }
    }

    public void SwapBlocksOnLogic(Block block1, Block block2) //swap işleminin ardından liste içerisinde kartların renk ve indexlerinin değişmesi
    {
        Color temp = spawnedBlocksColors[block2.blockIndex];
        spawnedBlocksColors[block2.blockIndex] = spawnedBlocksColors[block1.blockIndex];
        spawnedBlocksColors[block1.blockIndex] = temp;

        int tempIndex = block2.blockIndex;
        block2.blockIndex = block1.blockIndex;
        block1.blockIndex = tempIndex;
    }
    
    public bool CheckColorsSortCondition()  //oyuncunun yaptığı yeni liste correct list ile aynı ise true değilse false çevirir
    {
        for (int i = 0; i < _levelData.CorrectList.Count; i++)
        {
            if (ColorUtility.ToHtmlStringRGB(_levelData.CorrectList[i]) != ColorUtility.ToHtmlStringRGB(spawnedBlocksColors[i]))
            {
                return false;
            }
        }

        return true;
    }
}
