using System.Collections.Generic;
using Jnk.TinyContainer;
using UnityEngine;

namespace DefaultNamespace
{
    public class ServiceLocatorObjectInstaller : MonoBehaviour
    {
        [SerializeField]
        private List<Object> objects;

        protected void Awake()
        {
            TinyContainer container = TinyContainer.For(this);

            foreach (Object obj in objects)
                container.Register(obj.GetType(), obj);
        }
    }
}