using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class GameManager : MonoBehaviour
{

    public BlockManager blockManager;

    public Transform blockTran;

    public List<BlockManager> blockManagersList = new List<BlockManager>();

    public GameState currentGameState;

    private int gridCount = 9;

    public int writeCount;

    [SerializeField]
    private UIManager uiManager;

    void Start()
    {
        //ボタンを9つ生成してそれぞれのボタンに０～８の番号を割り当てる
        for (int i = 0; i < gridCount; i++)
        {
            //ブロックを生成
            BlockManager block = Instantiate(blockManager, blockTran);

            //生成したブロックを順番にリストに追加
            blockManagersList.Add(block);

            block.SetUpButton(this);

            //ブロックに番号を与える
            block.blockNum = i;

            blockManagersList[i].ButtonReactiveProperty.DistinctUntilChanged().Where(x => x == true).Subscribe(_ => WriteMaruBatu(block));


        }
    }

    /// <summary>
    /// 自分が〇を書いた後、決着が着かなければ相手が×を書く
    /// </summary>
    /// <param name="blockManager"></param>
    private void WriteMaruBatu(BlockManager blockManager)
    {

        if (JudgeWriting(blockManager.symbolNum) && currentGameState == GameState.Play)
        {

            uiManager.UpdateGrid(1, blockManager.blockNum);

            JudgeResult();

            if (AddWriteCount())
            {
                return;
            }

            OpponentTurn();
        }
    }

    /// <summary>
    /// 相手のターン
    /// </summary>
    public void OpponentTurn()
    {
        if(currentGameState == GameState.Play)
        {
            int counter = 0;

            while (true || counter < 10000)
            {
                //ランダムに書き込むブロックを決める
                int number = Random.Range(0, 9);

                //決まった数字の場所に何も書かれていなかったら
                if (JudgeWriting(blockManagersList[number].symbolNum))
                {
                    
                    uiManager.UpdateGrid(2, number);
                    JudgeResult();

                    break;
                }

                counter++;
                
            }
        }
       
    }

    /// <summary>
    /// ブロックに書けるかどうかジャッジ
    /// </summary>
    /// <param name="number"></param>
    /// <returns></returns>
    public bool JudgeWriting(int number)
    {

        return number == 0 ? true : false;
    }

    /// <summary>
    /// 勝ち負けのジャッジ
    /// </summary>
    public void JudgeResult()
    {
        //横がそろうパターン
        if (blockManagersList[0].symbolNum == 1 && blockManagersList[1].symbolNum == 1 && blockManagersList[2].symbolNum == 1)
        {
            currentGameState = GameState.Win;
        }
        if (blockManagersList[3].symbolNum == 1 && blockManagersList[4].symbolNum == 1 && blockManagersList[5].symbolNum == 1)
        {
            currentGameState = GameState.Win;
        }
        if (blockManagersList[6].symbolNum == 1 && blockManagersList[7].symbolNum == 1 && blockManagersList[8].symbolNum == 1)
        {
            currentGameState = GameState.Win;
        }

        if (blockManagersList[0].symbolNum == 2 && blockManagersList[1].symbolNum == 2 && blockManagersList[2].symbolNum == 2)
        {
            currentGameState = GameState.Lose;

        }
        if (blockManagersList[3].symbolNum == 2 && blockManagersList[4].symbolNum == 2 && blockManagersList[5].symbolNum == 2)
        {
            currentGameState = GameState.Lose;
        }
        if (blockManagersList[6].symbolNum == 2 && blockManagersList[7].symbolNum == 2 && blockManagersList[8].symbolNum == 2)
        {
            currentGameState = GameState.Lose;
        }

        //縦がそろうパターン
        if (blockManagersList[0].symbolNum == 1 && blockManagersList[3].symbolNum == 1 && blockManagersList[6].symbolNum == 1)
        {
            currentGameState = GameState.Win;
        }
        if (blockManagersList[1].symbolNum == 1 && blockManagersList[4].symbolNum == 1 && blockManagersList[7].symbolNum == 1)
        {
            currentGameState = GameState.Win;
        }
        if (blockManagersList[2].symbolNum == 1 && blockManagersList[5].symbolNum == 1 && blockManagersList[8].symbolNum == 1)
        {
            currentGameState = GameState.Win;
        }

        if (blockManagersList[0].symbolNum == 2 && blockManagersList[3].symbolNum == 2 && blockManagersList[6].symbolNum == 2)
        {
            currentGameState = GameState.Lose;

        }
        if (blockManagersList[1].symbolNum == 2 && blockManagersList[4].symbolNum == 2 && blockManagersList[7].symbolNum == 2)
        {
            currentGameState = GameState.Lose;
        }
        if (blockManagersList[2].symbolNum == 2 && blockManagersList[5].symbolNum == 2 && blockManagersList[8].symbolNum == 2)
        {
            currentGameState = GameState.Lose;
        }

        //斜めがそろうパターン
        if (blockManagersList[0].symbolNum == 1 && blockManagersList[4].symbolNum == 1 && blockManagersList[8].symbolNum == 1)
        {
            currentGameState = GameState.Win;
        }
        if (blockManagersList[2].symbolNum == 1 && blockManagersList[4].symbolNum == 1 && blockManagersList[6].symbolNum == 1)
        {
            currentGameState = GameState.Win;
        }

        if (blockManagersList[0].symbolNum == 2 && blockManagersList[4].symbolNum == 2 && blockManagersList[8].symbolNum == 2)
        {
            currentGameState = GameState.Lose;
        }
        if (blockManagersList[2].symbolNum == 2 && blockManagersList[4].symbolNum == 2 && blockManagersList[6].symbolNum == 2)
        {
            currentGameState = GameState.Lose;
        }

        uiManager.UpdateResultDisplay();

    }

    /// <summary>
    /// 〇を書いた数をカウントする
    /// 5回目のターンで決着が着いてなければ引き分けとする
    /// </summary>
    /// <returns></returns>
    public bool AddWriteCount()
    {
        writeCount++;

        if (writeCount > 4)
        {
            uiManager.JudgeDraw();

            return true;
        }

        return false;
    }
}
