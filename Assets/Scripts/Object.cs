using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Object : MonoBehaviour
{
    //�������� �������, ������� ���� � ��������
    public Image Image;
    public TMP_Text Name;
    public TMP_Text Description; //��������
    public int Cost;
    public GameObject ObjPrefab;
    public int x; //��� ���������� �� ����, ����������� �������
    public int y;
}
