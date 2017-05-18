using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Coroutines;
using RED.Entities;
using UniRx;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RED.Levels
{
    public class SceneAttribute : PropertyAttribute
    {
    }

    [CustomPropertyDrawer(typeof(SceneAttribute))]
    public class SceneDrawer : PropertyDrawer
    {

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {

            if (property.propertyType == SerializedPropertyType.String)
            {
                var sceneObject = GetSceneObject(property.stringValue);
                var scene = EditorGUI.ObjectField(position, label, sceneObject, typeof(SceneAsset), true);
                if (scene == null)
                {
                    property.stringValue = "";
                }
                else if (scene.name != property.stringValue)
                {
                    var sceneObj = GetSceneObject(scene.name);
                    if (sceneObj == null)
                    {
                        Debug.LogWarning("The scene " + scene.name + " cannot be used. To use this scene add it to the build settings for the project");
                    }
                    else
                    {
                        property.stringValue = scene.name;
                    }
                }
            }
            else
                EditorGUI.LabelField(position, label.text, "Use [Scene] with strings.");
        }
        protected SceneAsset GetSceneObject(string sceneObjectName)
        {
            if (string.IsNullOrEmpty(sceneObjectName))
            {
                return null;
            }

            foreach (var editorScene in EditorBuildSettings.scenes)
            {
                if (editorScene.path.IndexOf(sceneObjectName) != -1)
                {
                    return AssetDatabase.LoadAssetAtPath(editorScene.path, typeof(SceneAsset)) as SceneAsset;
                }
            }
            Debug.LogWarning("Scene [" + sceneObjectName + "] cannot be used. Add this scene to the 'Scenes in the Build' in build settings.");
            return null;
        }
    }

    public class Level : MonoBehaviour
    {
        public string Name;
        public Category Category;

        [Scene]
        public string Scene;

        public Point[] Points
        {
            get;
            private set;
        }

        private LevelController levelController;

        public IEnumerator Load()
        {
            yield return SceneManager.LoadSceneAsync(this.Scene, LoadSceneMode.Additive);
            this.levelController = GameObject.FindObjectOfType<LevelController>();
            this.Points = GameObject.FindObjectsOfType<Point>();
            yield return this.levelController.Show();

            this.Finished = Observable.FromCoroutine(() => this.levelController.Monitoring());
            this.Finished.Subscribe();
        }

        public IObservable<Unit> Finished
        {
            get;
            private set;
        }

        public IEnumerator Unload()
        {
            yield return this.levelController.Hide();
            yield return SceneManager.UnloadSceneAsync(this.Scene);
        }
    }
}
