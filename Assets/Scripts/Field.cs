using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    const int SIZE = 10; // ������ ����

    // ����
    GameObject[][] coordCoin = new GameObject[SIZE][];
    int[][] countCoin = new int[SIZE][];
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private Transform coinField;

    // �������
    GameObject[][] coordNet = new GameObject[SIZE][];
    [SerializeField] private GameObject cubePrefab;
    [SerializeField] private Material[] materials;
    [SerializeField] private Transform cubeField;

    // ���������� ����� �������
    int GetLevel(int x, int y)
    {
        return Mathf.Min(Mathf.Min(x, SIZE - x - 1), Mathf.Min(y, SIZE - y - 1));
    }

    // ���������� ����� ������� ������ �� �����������
    public GameObject getObject(int x, int y)
    {
        return coordNet[x][y];
    }

    // ��������� �������� ������ ��� �������� �� � �����������
    Material GetMaterial(int x,int y)
    {
        int matInd = GetLevel(x, y);
        return materials[matInd];

    }

    // ������������� �������� ������ �� � �����������
    public void setColor(int x, int y, Material mat)
    {
        getObject(x, y).GetComponent<Renderer>().material = mat;
    }

    // ��������� ���������� ����� � ������ �� �����������
    int HowManyCoin(int x, int y)
    {
        return countCoin[x][y];
    }

    // ���������� ���������� ����� � ������, ������� ������ �� ������
    int TakeCoin(int x, int y)
    {
        int count = HowManyCoin(x, y);
        countCoin[x][y] = 0;
        Destroy(coordCoin[x][y]);
        return count;
    }

    // �������� ���� � ���������� ���������
    void Start()
    {
        // �������� ����
        for (int i = 0; i < SIZE; i++) 
        {
            coordNet[i] = new GameObject[SIZE];
            for (int j = 0; j < SIZE; j++)
            {
                GameObject cube = Instantiate(cubePrefab, new Vector3(i, 0, j), Quaternion.identity, cubeField);
                coordNet[i][j] = cube;
                Material mat = GetMaterial(i, j);
                setColor(i, j, mat);
            }
        }

        // �������� �������
        for (int i = 0; i < SIZE; i++)
        {
            coordCoin[i] = new GameObject[SIZE];
            countCoin[i] = new int[SIZE];
            for (int j = 0; j < SIZE; j++)
            {
                if((i == 0 && j == 0) || (i == SIZE - 1 && j == 0) || 
                    (i == 0 && j == SIZE - 1) || (i == SIZE - 1 && j == SIZE - 1) ||
                    GetLevel(i, j) == 4)
                {
                    countCoin[i][j] = 0;
                    continue;
                }
                coordCoin[i][j] = Instantiate(coinPrefab, new Vector3(i, 1f, j), Quaternion.Euler(new Vector3(-60, 30, 0)), coinField);
                countCoin[i][j] = GetLevel(i, j);
            }
        }
    }

}
