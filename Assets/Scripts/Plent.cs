using UnityEngine;

public class PlentAI : MonoBehaviour
{
    public Transform blueWizard;
    public float attackRange = 2f; // ĳ������ �����
    private bool isActive = false;

    void Update()
    {
        float distance = Vector3.Distance(transform.position, blueWizard.position);

        if (distance <= attackRange)
        {
            isActive = true;
            AttackBlueWizard();
        }
        else
        {
            isActive = false;
        }
    }

    void AttackBlueWizard()
    {
        if (isActive)
        {
            Debug.Log("Plent ����� BlueWizard!");
            // ����� ������ ����� �����
        }
    }
}
