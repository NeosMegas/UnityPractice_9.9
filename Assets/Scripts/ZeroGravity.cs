using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeroGravity : MonoBehaviour
{

    /// <summary>
    /// ���������, ��� �� �������� � ����� �� ������, ���� ����� ��������� ����������
    /// </summary>
    private void Start()
    {
        foreach (Collider collider in Physics.OverlapBox(transform.position, Vector3.one, Quaternion.identity, 0, QueryTriggerInteraction.Collide))
        {
            if (collider.attachedRigidbody != null)
                collider.attachedRigidbody.useGravity = false;
        }
    }

    /// <summary>
    /// ��� ����� � ����� ��������� ����������
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody != null)
            other.attachedRigidbody.useGravity = false;
    }

    /// <summary>
    /// ��� ������ �� ����� �������� ����������
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        if (other.attachedRigidbody != null)
            other.attachedRigidbody.useGravity = true;
    }
}
