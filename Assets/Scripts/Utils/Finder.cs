using UnityEngine;
using System;
using System.Collections.Generic;

public class Finder : MonoBehaviour {
    public T FindByName<T>(string name) where T : UnityEngine.Object {
        T entity = GameObject.Find(name)?.GetComponent<T>();
        if (entity == null) {
            throw new Exception($"Could not find element by name: {name}!");
        }
        return entity;
    }
    
    public List<GameObject> FindAllChildren(Transform parent) {
        List<GameObject> children = new List<GameObject>();
        foreach (Transform child in parent) {
            children.Add(child.gameObject);
        }
        return children;
    }

    // I am here
    public GameObject FindChildByName(Transform parent, string name) {
        GameObject childByName = null;
        foreach (Transform child in parent) {
            if (child.gameObject.name == name) {
                childByName = child.gameObject;
            }
        }
        if (childByName == null) {
            throw new Exception("Not found child by name!");
        }
        return childByName;
    }

    public T FindParentByName<T>(GameObject child, string name) where T : Component {
        if (child == null) {
            throw new Exception("Child is null!");
        }
        Transform currentParent = child.transform.parent;
        if (currentParent == null) {
            throw new Exception($"Parent with name '{name}' not found!");
        }
        if (currentParent.name == name) {
            T component = currentParent.GetComponent<T>();
            if (component == null) {
                throw new Exception($"Parent '{name}' found, but doesn't have component of type {typeof(T).Name}!");
            }
            return component;
        }
        return FindParentByName<T>(currentParent.gameObject, name);
    }
}
