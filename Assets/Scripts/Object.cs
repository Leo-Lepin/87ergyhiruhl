using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Object : MonoBehaviour
{
    //�������� �������, ������� ���� � ��������
    public Image image;
    public TMP_Text name;
    public TMP_Text description; //��������
    public int cost;
    public GameObject objPrefab;
    public int x; //��� ���������� �� ����, ����������� �������
    public int y;
}
