using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockManager : MonoBehaviour
{
    public int blockNum;

    public Text txtBlock;

    private GameManager gameManager;

    //0�͂Ȃ��A1�́Z�A2�́~
    public int symbolNum;

    //�{�^���̏����ݒ�
    public void SetUpButton(GameManager gameManager)
    {
        this.gameManager = gameManager;

        txtBlock.text = "";

    }

    //�����̃^�[��
    public void OnClickMyTurn()
    {
        //���̃u���b�N�ɉ���������Ă��Ȃ��Ƃ�
        if (gameManager.JudgeWriting(symbolNum) && gameManager.currentGameState == GameState.Play)
        {
            //�u���b�N�ɁZ������
            gameManager.Write(1,blockNum);

            //����̃^�[��
            gameManager.OpponentTurn();
        }
    }
}
