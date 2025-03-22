using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public int maxHP = 3; // ����������� ������'� ������
    private int currentHP;

    void Start()
    {
        currentHP = maxHP; // ���������� ������� ������'� �� ��� �������������
        Debug.Log("����� �� " + currentHP + " HP");
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage; // ³������ ����� �� ��������� ������'�
        Debug.Log("����� ������� " + damage + " �����. ����������: " + currentHP + " HP");

        if (currentHP <= 0)
        {
            Die(); // ����� ������, ���� ������'� ����� ��� ���� ����
        }
    }

    void Die()
    {
        Debug.Log("����� �����!");
        // ����� ������ �������, ������ ��� �������� ��'����
        Destroy(gameObject); // ������� ��'��� ������
    }
}
