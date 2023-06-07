using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree
{
    public Node root;

    public Tree()
    {
        root = null;
    }

    public void Add(int data)
    {
        root = AddRecursive(root, data);
    }

    public Node AddRecursive(Node current, int data)
    {
        if(current == null)
        {
            return new Node(data);
        }
        if(data < current.data)
        {
            current.left = AddRecursive(current.left, data);
        }
        else if (data > current.data)
        {
            current.right = AddRecursive(current.right, data);
        }

        return current;
    }

    public bool Find(int data)
    {
        Node result = FindRecursive(root, data);
        return result != null;
    }

    public Node FindRecursive(Node current, int data)
    {
        if(current == null || data == current.data)
        {
            return current;
        }
        if(data < current.data)
        {
            return FindRecursive(current.left, data);
        }

        return FindRecursive(current.right, data);
    }

    private void PrintInOrderRecursive(Node current)
    {
        if(current == null)
        {
            return;
        }

        PrintInOrderRecursive(current.left);
        Debug.Log(current.data + ", ");
        PrintInOrderRecursive(current.right);
    }
    public void PrintInOrder()
    {
        PrintInOrderRecursive(root);
    }

    public void PrintInReverse()
    {

    }
}
