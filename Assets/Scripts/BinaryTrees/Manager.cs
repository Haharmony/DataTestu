using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    Tree binaryTree = new Tree();

    public void Start()
    {

    }

    private void Update()
    {
        //bool result = binaryTree.Find(6);
        //Debug.Log("The value is: " + result);
    }

    public void AddNodes()
    {
        binaryTree.Add(2);
        binaryTree.Add(6);
        binaryTree.Add(8);
        binaryTree.Add(1);
        binaryTree.Add(3);
        binaryTree.Add(5);
        binaryTree.Add(10);
        binaryTree.Add(7);
    }

    public void DeleteNode()
    {
        binaryTree.DeleteNode(8);
    }

    public void PrintNodes()
    {
        binaryTree.PrintInPostOrder();
    }
}
