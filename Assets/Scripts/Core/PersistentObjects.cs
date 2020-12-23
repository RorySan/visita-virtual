using UnityEngine;

namespace VisitaVirtual.Core
{
    public class PersistentObjects : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }
    }

}