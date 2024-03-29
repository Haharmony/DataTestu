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

    public void DeleteNode(int data)
    {
        if (root == null)
        {
            return;
        }

        Node result = FindRecursive(root, data);
        Node prev_result = FindPrevRecursive(root, data);

        //CASE 1
        if (data == result.data && result.right == null && result.left == null)
        {
            if (prev_result.right == result)
                prev_result.right = null;

            if (prev_result.left == result)
                prev_result.left = null;

            Debug.Log("CASE 1");
        }

        //CASE 2
        if (data == result.data && prev_result.right == result && (result.right == null || result.left == null))
        {
            Debug.Log("THIS IS THE PREV: " + prev_result.data);
            Debug.Log("CASE 2");

            if (result.right == null)
            {
                prev_result.right = result.left;
                result.left = null;
            }
            else
            {
                prev_result.right = result.right;
                result.right = null;
            }         
        }

        if (data == result.data && prev_result.left == result && (result.right == null || result.left == null))
        {
            Debug.Log("THIS IS THE PREV: " + prev_result.data);
            Debug.Log("CASE 2");
            if (result.right == null)
            {
                prev_result.left = result.left;
                result.left = null;
            }
            else
            {
                prev_result.left = result.right;
                result.right = null;
            }           
        }

        //CASE 3
        if (data == result.data && result.right != null && result.left != null)
        {
            Debug.Log("CASE 3");
            Node minValue = FindMinNode(result.right);
            Node prev_temp = FindPrevRecursive(root, minValue.data);
            result.data = minValue.data;

            if (prev_temp.right == minValue)
            {
                prev_temp.right = null;
            }
            else
            {
                prev_temp.left = null;
            }
            
        }    
    }

    private Node FindMinNode(Node node)
    {
        while(node.left != null)
        {
            node = node.left;
        }

        return node;
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

    public Node FindPrevRecursive(Node current, int data)
    {
        if(current == null || current.right.data == data || current.left.data == data)
        {
            return current;
        }

        if (data < current.data)
        {
            return FindPrevRecursive(current.left, data);
        }
        return FindPrevRecursive(current.right, data);
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

    private void PrintInReverseRecursive(Node current)
    {
        if (current == null)
        {
            return;
        }

        Debug.Log(current.data + ", ");
        PrintInReverseRecursive(current.left);
        PrintInReverseRecursive(current.right);
    }

    private void PrintInPostOrderRecursive(Node current)
    {
        if (current == null)
        {
            return;
        }

        PrintInPostOrderRecursive(current.left);
        PrintInPostOrderRecursive(current.right);
        Debug.Log(current.data + ", ");
    }

    public void PrintInOrder()
    {
        PrintInOrderRecursive(root);
    }

    public void PrintInReverse()
    {
        PrintInReverseRecursive(root);
    }

    public void PrintInPostOrder()
    {
        PrintInPostOrderRecursive(root);
    }
}
