using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _enemyPrefab;//������ �������� ��������
    private GameObject _enemy ;
    int enemycol = 0;
    private void Update()
    {
        //������ ������ �����, ���� ��� ���
        //��� ����� ������������ ����������� ������ �� �����
        if (_enemy == null)
        {
            while ( enemycol < 3)
            {
                int randEnemy = Random.Range(0, _enemyPrefab.Length);//�������� �������� �����
                _enemy = Instantiate(_enemyPrefab[randEnemy]) as GameObject;//������ ����� ��� ������� ������
                _enemy.transform.position = new Vector3(Random.Range(-24, 24), 3, Random.Range(-24, 24));//����� ������� ���������
                float angle = Random.Range(0, 360);
                _enemy.transform.Rotate(0, angle, 0);//������������
                enemycol++;
            }
            enemycol = 0;
        }
    }
}
