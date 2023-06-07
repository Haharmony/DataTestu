using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    Tree binaryTree = new Tree();

    public void Start()
    {
        binaryTree.Add(2);
        binaryTree.Add(6);
        binaryTree.Add(8);
        binaryTree.Add(1);
    }

    private void Update()
    {
        bool result = binaryTree.Find(6);
        Debug.Log("The value is: " + result);
        binaryTree.PrintInOrder();
    }
}
