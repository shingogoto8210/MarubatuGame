using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //���s�̌��ʕ\��
    public Text txtMyResult, txtOpponentResult;

    public BlockManager blockManager;
    public Transform[] blockTrans;

    public List<BlockManager> blockManagersList = new List<BlockManager>();

    public GameState currentGameState;

    void Start()
    {
        //�{�^����9�������Ă��ꂼ��̃{�^���ɂO�`�W�̔ԍ������蓖�Ă�
        for (int i = 0; i < blockTrans.Length; i++)
        {
            //�u���b�N�𐶐�
            BlockManager block = Instantiate(blockManager, blockTrans[i]);

            //���������u���b�N�����ԂɃ��X�g�ɒǉ�
            blockManagersList.Add(block);

            block.SetUpButton(this);

            //�u���b�N�ɔԍ���^����
            block.blockNum = i;
        }
    }

    public void OpponentTurn()
    {
        if(currentGameState == GameState.Play)
        {
            while (true)
            {
                //�����_���ɏ������ރu���b�N�����߂�
                int number = Random.Range(0, 9);

                //���܂��������̏ꏊ�ɉ���������Ă��Ȃ�������
                if (JudgeWriting(blockManagersList[number].symbolNum))
                {
                    //�~������
                    Write(2, number);

                    break;
                }
            }
        }
       
    }

    //�u���b�N�ɁZ�~����������
    public void Write(int symbol, int blockNum)
    {

        //�u���b�N�̋L���̎�ނ�����i�Z���~���j
        blockManagersList[blockNum].symbolNum = symbol;

        if (symbol == 1)
        {
            blockManagersList[blockNum].txtBlock.text = "�Z";
        }
        if (symbol == 2)
        {
            blockManagersList[blockNum].txtBlock.text = "�~";
        }

        JudgeResult();
    }

    //�u���b�N�ɏ����邩�ǂ����W���b�W
    public bool JudgeWriting(int number)
    {
        //���������L�����Ȃ�������true��Ԃ�
        if (number == 0)
        {
            return true;
        }

        return false;
    }

    //���������̃W���b�W
    public void JudgeResult()
    {
        //�������낤�p�^�[��
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

        //�c�����낤�p�^�[��
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

        //�΂߂����낤�p�^�[��
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
            txtMyResult.text = "����";
            txtOpponentResult.text = "����";
        }
        if (currentGameState == GameState.Lose)
        {
            txtMyResult.text = "����";
            txtOpponentResult.text = "����";
        }
    }
}
