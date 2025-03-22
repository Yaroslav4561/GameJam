using UnityEngine;
using UnityEngine.SceneManagement; // ��� ������ � ������������� �����

public class CharacterHP : MonoBehaviour
{
    public int maxHP = 5;
    private int currentHP;

    public float deathHeight = -10f; // ���� ������, ����� ����� �������� ������

    void Start()
    {
        currentHP = maxHP;
        Debug.Log("�������� �� " + currentHP + " HP");
    }

    void Update()
    {
        // ����������, �� �������� ����� �� ��� �����
        CheckFallDeath();
    }

    // ����� ��� ��������� �����
    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        Debug.Log("�������� ������� " + damage + " �����. ����������: " + currentHP + " HP");

        if (currentHP <= 0)
        {
            Die();
        }
    }

    // ����� ��� �������� ������ �� ��� �����
    void CheckFallDeath()
    {
        if (transform.position.y < deathHeight)
        {
            Die(); // �������� ������ ��� ����� �� ���
        }
    }

    // ����� ����� ���������
    void Die()
    {
        Debug.Log("�������� �����!");

        // ����������� ����� ���� ���� �����
        SceneManager.LoadScene("Menu"); // ������ "Menu" �� ����� ��'� ���� ����� ����
    }
}
