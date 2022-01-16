using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //勝敗の結果表示
    public Text txtMyResult, txtOpponentResult;

    public BlockManager blockManager;
    public Transform[] blockTrans;

    public List<BlockManager> blockManagersList = new List<BlockManager>();

    public GameState currentGameState;

    void Start()
    {
        //ボタンを9つ生成してそれぞれのボタンに０～８の番号を割り当てる
        for (int i = 0; i < blockTrans.Length; i++)
        {
            //ブロックを生成
            BlockManager block = Instantiate(blockManager, blockTrans[i]);

            //生成したブロックを順番にリストに追加
            blockManagersList.Add(block);

            block.SetUpButton(this);

            //ブロックに番号を与える
            block.blockNum = i;
        }
    }

    public void OpponentTurn()
    {
        if(currentGameState == GameState.Play)
        {
            while (true)
            {
                //ランダムに書き込むブロックを決める
                int number = Random.Range(0, 9);

                //決まった数字の場所に何も書かれていなかったら
                if (JudgeWriting(blockManagersList[number].symbolNum))
                {
                    //×を書く
                    Write(2, number);

                    break;
                }
            }
        }
       
    }

    //ブロックに〇×を書き込む
    public void Write(int symbol, int blockNum)
    {

        //ブロックの記号の種類を決定（〇か×か）
        blockManagersList[blockNum].symbolNum = symbol;

        if (symbol == 1)
        {
            blockManagersList[blockNum].txtBlock.text = "〇";
        }
        if (symbol == 2)
        {
            blockManagersList[blockNum].txtBlock.text = "×";
        }

        JudgeResult();
    }

    //ブロックに書けるかどうかジャッジ
    public bool JudgeWriting(int number)
    {
        //もし何も記号がなかったらtrueを返す
        if (number == 0)
        {
            return true;
        }

        return false;
    }

    //勝ち負けのジャッジ
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

        if (blockManagersList[0].symbolNum == 1 && blockManagersList[4].symbolNum == 1 && blockManagersList[8].symbolNum == 1)
        {
            currentGameState = GameState.Lose;
        }
        if (blockManagersList[2].symbolNum == 1 && blockManagersList[4].symbolNum == 1 && blockManagersList[6].symbolNum == 1)
        {
            currentGameState = GameState.Lose;
        }

        UpdateResultDisplay();

    }


    public void UpdateResultDisplay()
    {
        if (currentGameState == GameState.Win)
        {
            txtMyResult.text = "勝ち";
            txtOpponentResult.text = "負け";
        }
        if (currentGameState == GameState.Lose)
        {
            txtMyResult.text = "負け";
            txtOpponentResult.text = "勝ち";
        }
    }
}
