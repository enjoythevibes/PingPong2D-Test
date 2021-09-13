using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace PingPong.Player
{
    [CreateAssetMenu(fileName = "PlayerDataLoader", menuName = "Data/Player/PlayerDataLoader", order = 0)]
    public class PlayerDataLoader : PlayerDataLoaderAbstract<PlayerData>
    {
        [SerializeField] private string _fileName = "save.data";
        [SerializeField] private string _fileRelativePath = "data/";

        [System.NonSerialized] private bool _init = false;
        [System.NonSerialized] private PlayerData _playerData;

        public override PlayerData PlayerData
        {
            get
            {
                if (_init == false)
                {
                    _init = true;
                    LoadData();
                    return _playerData;
                }
                else
                {
                    return _playerData;
                }
            }
            protected set
            {
                _playerData = value;
            }
        }

        private string GetFullPath()
        {
            var finalPath = GetRelativePath() + _fileName;
            return finalPath;
        }

        private string GetRelativePath()
        {
            var relativePath = default(string);
#if !UNITY_EDITOR && UNITY_STANDALONE
            relativePath = Application.dataPath + "/" + _fileRelativePath;
#endif
#if UNITY_ANDROID
            relativePath = Application.persistentDataPath + "/" + _fileRelativePath;
#endif
#if UNITY_EDITOR
            relativePath = _fileRelativePath;
#endif
            return relativePath;
        }

        public override void SaveData()
        {
            if (!Directory.Exists(GetRelativePath()))
                Directory.CreateDirectory(GetRelativePath());
            File.WriteAllBytes(GetFullPath(), GetBytesData(PlayerData));
        }

        public override void LoadData()
        {
            var fileFullPath = GetFullPath();
            if (File.Exists(fileFullPath))
            {
                var bytes = File.ReadAllBytes(fileFullPath);
                PlayerData = ReadFromBytes(bytes);
            }
            else
            {
                PlayerData = new PlayerData();
                PlayerData.SetDefault();
                SaveData();
            }
        }

        private byte[] GetBytesData(PlayerData playerData)
        {
            var bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, playerData);
                return ms.ToArray();
            }
        }

        private PlayerData ReadFromBytes(byte[] bytes)
        {
            var bf = new BinaryFormatter();
            using (var ms = new MemoryStream(bytes))
            {
                var playerData = bf.Deserialize(ms) as PlayerData;
                return playerData;
            }
        }
    }
}