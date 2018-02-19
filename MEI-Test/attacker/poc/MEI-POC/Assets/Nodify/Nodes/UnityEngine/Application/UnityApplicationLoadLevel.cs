#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using Nodify.Runtime;

namespace Nodify.Runtime.Nodes
{
	[CreateMenu("Unity/Application/Load Level", "Application.LoadLevel" )]
	public class UnityApplicationLoadLevel : Node 
	{
        public enum LoadLevelType
        {
            LoadLevel,
            LoadLevelAdditive,
            LoadLevelAsync,
            LoadLevelAdditiveAsync
        }
        public enum LoadByType
        {
            Name,
            Id,
            Next,
            Back,
            Current
        }

        [Expose]
        public string levelName;
        [Expose][HideInInspector]
        public int levelId;

        [Expose]
        public LoadLevelType loadLevelType = LoadLevelType.LoadLevel;
        [Expose]
        public LoadByType loadByType = LoadByType.Name;

        private int GetLevelId(LoadByType type)
        {
            switch (type)
            {
                case LoadByType.Id:
                    return levelId;
                case LoadByType.Current:
                    return SceneManager.GetActiveScene().buildIndex;
                case LoadByType.Back:
                    return Mathf.Max(SceneManager.GetActiveScene().buildIndex - 1, 0);
                case LoadByType.Next:
                    return SceneManager.GetActiveScene().buildIndex + 1;
            }

            return 0;
        }

		protected override void OnExecute()
		{
            switch (loadLevelType)
            {
                case LoadLevelType.LoadLevel:
                    if (loadByType == LoadByType.Name) { SceneManager.LoadScene(levelName); } else { SceneManager.LoadScene(GetLevelId(loadByType)); }
                    break;
                case LoadLevelType.LoadLevelAdditive:
                    if (loadByType == LoadByType.Name) { SceneManager.LoadScene(levelName, LoadSceneMode.Additive); } else { SceneManager.LoadScene(GetLevelId(loadByType)); }
                    break;
                case LoadLevelType.LoadLevelAsync:
                    if (loadByType == LoadByType.Name) { SceneManager.LoadSceneAsync(levelName); } else { SceneManager.LoadScene(GetLevelId(loadByType)); }
                    break;
                case LoadLevelType.LoadLevelAdditiveAsync:
                    if (loadByType == LoadByType.Name) { SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive); } else { SceneManager.LoadSceneAsync(GetLevelId(loadByType), LoadSceneMode.Additive); }
                    break;
            }

			base.OnExecute();
		}

        #if UNITY_EDITOR
        public override void OnCustomInspectorGUI()
        {
            if (loadByType == LoadByType.Name) levelName = EditorGUILayout.TextField("Level Name", levelName); 
            if (loadByType == LoadByType.Id) levelId = EditorGUILayout.IntField("Level Name", levelId); 
        }
        #endif
	}
}
