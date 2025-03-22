using UnityEngine;

public class PlayerFallDeath : MonoBehaviour
{
    public float deathHeight = -10f;  // ������, ����� ��� �������� ������ (������� �� Y)
    public int maxHP = 5;  // ����������� ������'�
    private int currentHP;  // ������� ������'�

    void Start()
    {
        currentHP = maxHP;  // ����������� ������'�
    }

    void Update()
    {
        CheckFallDeath();  // �������� ����� ����
    }

    // ����� ��� ��������, �� �������� ���� �� ��� �����
    void CheckFallDeath()
    {
        if (transform.position.y < deathHeight)
        {
            Die();  // ��������� ����� �����
        }
    }

    // ����� ����� ���������
    void Die()
    {
        Debug.Log("�������� ����� ����� ������ �� ��� �����.");
        // ���������, �������� ��'���
        gameObject.SetActive(false);  // ��������� ���, �� ��������/���������� ��'���
    }
}
