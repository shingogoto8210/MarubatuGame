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
        //�{�^����9�������Ă��ꂼ��̃{�^���ɂO�`�W�̔ԍ������蓖�Ă�
        for (int i = 0; i < gridCount; i++)
        {
            //�u���b�N�𐶐�
            BlockManager block = Instantiate(blockManager, blockTran);

            //���������u���b�N�����ԂɃ��X�g�ɒǉ�
            blockManagersList.Add(block);

            block.SetUpButton(this);

            //�u���b�N�ɔԍ���^����
            block.blockNum = i;

            blockManagersList[i].ButtonReactiveProperty.DistinctUntilChanged().Where(x => x == true).Subscribe(_ => WriteMaruBatu(block));


        }
    }

    /// <summary>
    /// �������Z����������A�����������Ȃ���Α��肪�~������
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
    /// ����̃^�[��
    /// </summary>
    public void OpponentTurn()
    {
        if(currentGameState == GameState.Play)
        {
            int counter = 0;

            while (true || counter < 10000)
            {
                //�����_���ɏ������ރu���b�N�����߂�
                int number = Random.Range(0, 9);

                //���܂��������̏ꏊ�ɉ���������Ă��Ȃ�������
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
    /// �u���b�N�ɏ����邩�ǂ����W���b�W
    /// </summary>
    /// <param name="number"></param>
    /// <returns></returns>
    public bool JudgeWriting(int number)
    {

        return number == 0 ? true : false;
    }

    /// <summary>
    /// ���������̃W���b�W
    /// </summary>
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
    /// �Z�������������J�E���g����
    /// 5��ڂ̃^�[���Ō����������ĂȂ���Έ��������Ƃ���
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
