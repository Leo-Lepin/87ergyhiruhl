using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Storage : MonoBehaviour
{
    protected const int Size = Config.SIZE;// ������ ����
    //��������� ������ � ������� ��������� ��������
<<<<<<< Updated upstream

    public static bool isMove; //������� ������ ��� ���
    public static int[][] is�licked; //������� �� ������ [x][y]
    public Object[] objects;
    public static List<Object> inventory; //������� ��� ������
    
=======
    public bool IsMove = true; //������� ������ ��� ���
    public bool[,] Is�licked = new bool[Size, Size]; //������� �� ������ [x][y]
    public Object[] Objects;
    public static List<Object> Inventory; //������� ��� ������
>>>>>>> Stashed changes

    private void Start()
    {
        for(int i = 0; i < Size; i++) 
        { 
            for(int j = 0; j < Size; j++)
            {
                Is�licked[i, j] = false;
            }
        }
    }
}
