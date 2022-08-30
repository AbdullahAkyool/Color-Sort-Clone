using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BlocksManager : MonoSingleton<BlocksManager>
{
    public Camera camera;

    private bool isSwapping = false;
    private bool isBlock1Selected = false;

   [SerializeField] private Transform selectedBlock;
   [SerializeField] internal float blockSelectScaleMultiplier = 1.25F;
    

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit,Mathf.Infinity))
            {
                if (hit.transform.TryGetComponent(out Block block)) //raycastın seçtiği objede Block scripti var mı?
                {
                    if (isBlock1Selected)
                    {
                        //seçilen kart varsa gir
                        //birinci kart seçildiyse ikinci kar için çalışır
                        SwapBlocks(selectedBlock,block.transform,.5F);
                    }
                    else
                    {
                        //seçme işlemi yapılmadıysa gir
                        block.Select();
                        selectedBlock = block.gameObject.transform;
                        isBlock1Selected = true;
                    }
                }
            }
        }
    }
    

    private void ResetSwapSettings() //seçilen, atanan obje sıfırlanır 
    {
        isBlock1Selected = false;
        selectedBlock.GetComponent<Block>().DeSelect();
        selectedBlock = null;

        Debug.Log(LevelGenerator.Instance.CheckColorsSortCondition()); //swap işleminden sonra listlerin aynı olup olmadığı consola yazılıyor
       
    }

    private void SwapBlocks(Transform block1, Transform block2 , float duration)
    {
        StartCoroutine(SwapBlocksCo(block1, block2, duration));
    }

    IEnumerator SwapBlocksCo(Transform block1, Transform block2 , float duration) //swap işlemi
    {
        if(isSwapping) yield break; //swap işlemi başladıysa buga girmemesi için coroututine durdurulur

        isSwapping = true;
        Vector3 block1InitPos = block1.transform.position;
        Vector3 block2InitPos = block2.transform.position;
        
        bool isBlock1Swapped = false;
        bool isBlock2Swapped = false;
        
        block1.DOMove(block2InitPos, duration).OnComplete(() => //kartlar yer değiştirir ve değişim işi tamamlandıktan sonra true döner
        {
            isBlock1Swapped = true;
        });
        block2.DOMove(block1InitPos, duration).OnComplete(() =>
        {
            isBlock2Swapped = true;
        });

        yield return new WaitForSeconds(duration);

        if (isBlock1Swapped && isBlock2Swapped) isSwapping = false;
        
        LevelGenerator.Instance.SwapBlocksOnLogic(block1.GetComponent<Block>(),block2.GetComponent<Block>());
        
        ResetSwapSettings();

    }
}
