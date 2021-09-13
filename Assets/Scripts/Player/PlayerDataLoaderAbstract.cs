using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PingPong.Player
{
    public abstract class PlayerDataLoaderAbstract<T> : ScriptableObject
    {
        public abstract T PlayerData { get; protected set; }  

        public abstract void SaveData();
        public abstract void LoadData();              
    }
}