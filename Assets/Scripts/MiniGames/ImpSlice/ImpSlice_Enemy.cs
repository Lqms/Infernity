using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ImpSlice_Enemy : MonoBehaviour
{
    private Coroutine _coroutine;

    public event UnityAction Deactivated;
    Vector3 _baseSize;

    private void Start()
    {
        _baseSize = gameObject.transform.localScale;
    }

    public void Init(Vector3 position)
    {
        transform.localScale = _baseSize;
        transform.position = position;
        gameObject.GetComponent<BoxCollider>().isTrigger = false;
        _coroutine = StartCoroutine(ObjectIncrease());
    }

    // при ините отключить триггер на коллайдере, а затем запустить корутину, которая через рандом кол-во сек
    // будет увеличивать размер объекта до х4, а в начале этого увелчения включит триггер на коллайдере

    private IEnumerator ObjectIncrease()
    {
        float increaseTime = Random.Range(2f, 6f);
        yield return new WaitForSeconds(increaseTime);
        gameObject.GetComponent<BoxCollider>().isTrigger = true;
        _baseSize = gameObject.transform.localScale;

        while (gameObject.transform.localScale != _baseSize * 4)
        {
            yield return new WaitForSeconds(0.05f);
            gameObject.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
        }

        print("Not cutted");
        Deactivated?.Invoke();
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ImpSlice_Pointer pointer))
        {
            print("Cutted!");

            StopCoroutine(_coroutine);
            Deactivated?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
