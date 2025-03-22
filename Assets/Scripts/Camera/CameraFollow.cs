using UnityEngine;

public class CameraFollowX : MonoBehaviour
{
    public Transform target;  // ��������
    public float smoothSpeed = 0.125f;  // �������� ���������
    public float offsetX = 5f;  // ³������ �� ��������� �� X

    void LateUpdate()
    {
        if (target == null) return;

        // �������� ������� ������� ������
        Vector3 currentPosition = transform.position;

        // ���� �������� X ��� ������ (� ������� ���������)
        float targetX = Mathf.Lerp(currentPosition.x, target.position.x + offsetX, smoothSpeed);

        // ���������� ���� �������, ��� �������� Y �� Z ���������
        transform.position = new Vector3(targetX, currentPosition.y, currentPosition.z);
    }
}
