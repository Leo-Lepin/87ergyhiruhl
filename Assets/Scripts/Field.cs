using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    [SerializeField] private GameObject confObj;
    private const int SIZE = Config.SIZE;// ������ ����
    private Material[] materials;
    Cell[][] coordNet = new Cell[SIZE][];

    [SerializeField] private GameObject cubePrefab;
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private Transform cubeField;
    [SerializeField] private Transform coinField;

    // ���������� ����� �������
    public int getLevel(int x, int y)
    {
        return Mathf.Min(Mathf.Min(x, SIZE - x - 1), Mathf.Min(y, SIZE - y - 1));
    }

    // ���������� ����� ������� ������ �� �����������
    public Cell getObject(int x, int y)
    {
        return coordNet[x][y];
    }

    // ������������� �������� ������ �� � �����������
    public void setMaterial(int x, int y, Material mat)
    {
        getObject(x, y).setMaterial(mat);
    }

    // ��������� ���������� ����� � ������ �� �����������
    public int getCoinsCount(int x, int y)
    {
        return getObject(x, y).CountCoin;
    }
    //������� ����
    public void deleteCoin(int x, int y, int cost)
    {
        int count = getCoinsCount(x, y);
        if (count >= cost) setCoinCount(x, y, count - cost);
    }
    public void setCoinCount(int x, int y, int count)
    {
        getObject(x, y).CountCoin = count;
    }


    //�������� �� ������

    //�������� ������� � ����������� ������� ������� ����
    public Dictionary<string, int> getDict(int x, int y)
    {
        return getObject(x, y).Elements;
    }

    //���������� ���������� ��������� � ������
    public int countElements(int x, int y, string type)
    {
        if (getDict(x, y).ContainsKey(type))
        {
            getDict(x, y).TryGetValue(type, out int count);
            return count;
        }
        return -1;

    }

    //�������� ������� �� ������
    public void addElementToCell(int x, int y, GameObject obj, Transform parent, int high)
    {
        if (countElements(x, y, obj.tag) > 0)
        {
            getDict(x, y)[obj.tag]++;
        }
        else getDict(x, y).Add(obj.tag, 1);
        Instantiate(obj, new Vector3(x, high, y), Quaternion.identity, parent);
    }

    //������� ������� � ������
    public void deleteElementFromCell(int x, int y, string type)
    {
        int count = countElements(x, y, type);
        getObject(x, y).Elements.Add(type, count--);
        Destroy(GameObject.FindGameObjectWithTag(type));
    }

    // �������� ����
    void fieldSpawn()
    {
        for (int i = 0; i < SIZE; i++)
        {
            coordNet[i] = new Cell[SIZE];
            for (int j = 0; j < SIZE; j++)
            {
                GameObject cube = Instantiate(cubePrefab, new Vector3(i, 0, j), Quaternion.identity, cubeField);
                coordNet[i][j] = cube.GetComponent<Cell>();
                setMaterial(i, j, materials[getLevel(i, j)]);
            }
        }
    }

    // �������� �������
    void coinsSpawn()
    {
        for (int i = 0; i < SIZE; i++)
        {
            for (int j = 0; j < SIZE; j++)
            {
                if ((i == 0 && j == 0) || (i == SIZE - 1 && j == 0) ||
                    (i == 0 && j == SIZE - 1) || (i == SIZE - 1 && j == SIZE - 1) ||
                    getLevel(i, j) == 4)
                {
                    setCoinCount(i, j, 0);
                    continue;
                }
                addElementToCell(i, j, coinPrefab, coinField, 1);
                setCoinCount(i, j, getLevel(i, j));
            }
        }
    }

    // �������� ���� � ���������� ���������
    void Start()
    {
        materials = confObj.GetComponent<Config>().materials;
        fieldSpawn();
        coinsSpawn();
    }

}
