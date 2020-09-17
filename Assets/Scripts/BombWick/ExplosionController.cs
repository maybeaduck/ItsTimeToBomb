using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ExplosionController : MonoBehaviour
{
    public float shakeDuration = 1.0f;
    public float shakePower = 1.0f;
    public int id;

    [SerializeField] private GameObject _explosionCore;
    [SerializeField] private GameObject _shardObject;
    [SerializeField] private GameObject _bombObject;
    private void OnEnable() {
        GameEventsManager.Instance.EventExplosion += OnExsplosion;
    }
    private void OnDisable() {
        GameEventsManager.Instance.EventExplosion -= OnExsplosion;
    }
    
    private void OnExsplosion(int id){
        if(id == this.id){
            CameraShake.Shake(shakeDuration,shakePower);
            _shardObject.SetActive(true);
            StartCoroutine(ClearExsplosion());
            _bombObject.SetActive(false);
            

        }
    }
    private IEnumerator ClearExsplosion(){
        yield return new WaitForSeconds(3.0f);
        _shardObject.SetActive(false);
        yield return new WaitForSeconds(2.0f);
        if(GameController.Instance._OnGameOver == false){
            GameEventsManager.Instance._EventLevelLoader(id,SceneManager.GetActiveScene().name);
        }
    }
    
        
}
