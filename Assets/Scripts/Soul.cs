using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soul : MonoBehaviour
{
    [SerializeField]private SoulsType soulsType;
    Transform storePosition;

    Sequence levitation;
    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpDuration;

    public void SetType(SoulsType type)
    {
        soulsType = type;
    }

    public SoulsType GetTypeOfSoul()
    {
        return soulsType;
    }

    public void LevitateSoul(float maxLevitateDistance, float minLevitateDistance)
    {
        float rnd = Random.Range(0.9f, 1.2f);
        levitation = DOTween.Sequence();
        levitation.Append(transform.DOMoveY(maxLevitateDistance, rnd))
         .Append(transform.DOMoveY(minLevitateDistance, rnd));
        levitation.SetLoops(-1, LoopType.Yoyo); 

    }
    public void SetStorePosition(Transform position)
    {
        storePosition = position;
        
    }

    public void DragSoul(Ray ray)
    {
        Vector3 rayPoint = ray.GetPoint(Vector3.Distance(transform.position, Camera.main.transform.position));
        transform.position = new Vector3(rayPoint.x, rayPoint.y, transform.position.z);
    }
    public void PushSoul(GameObject destin, int _countSteepMagnet, float _steep, AnimationCurve _changeY, float _timeInStee)
    {
        levitation.Kill();
        StartCoroutine(MoveSoul (destin, _countSteepMagnet, _steep, _changeY, _timeInStee));
    }

    private IEnumerator MoveSoul(GameObject destin, int _countSteepMagnet, float _steep, AnimationCurve _changeY, float _timeInSteep)
    {
        for (int i = 0; i <= _countSteepMagnet; i++)
        {

            Vector3 pos = Vector3.Lerp(transform.position, destin.transform.position, i * _steep);
            pos.y += _changeY.Evaluate(i * _steep);
            transform.position = pos;

            transform.rotation = Quaternion.Lerp(transform.rotation, destin.transform.rotation, i * _steep);


            yield return new WaitForSeconds(_timeInSteep);

        }
        transform.parent = destin.transform;
        transform.position = destin.transform.position;
        transform.rotation = destin.transform.rotation;
        gameObject.SetActive(false);
    }

    public void ReturnSoulToMage()
    {
       
       transform.DOJump(storePosition.position, jumpForce, 1, jumpDuration);

    }
}
