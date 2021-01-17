using System;
using System.Collections;
using System.Collections.Generic;
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