using UnityEngine;

namespace Core.InputEntity.View
{
    public class BoomRunnerView : MonoBehaviour
    {
        void Update()
        {
            transform.Translate(-5*Time.deltaTime,1*Time.deltaTime,0);
        }
    }
}
