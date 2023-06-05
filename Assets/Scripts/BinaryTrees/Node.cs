using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public int data;
    public Node right;
    public Node left;

    public Node (int data)
    {
        this.data = data;
    }

    public Node (int data, Node right, Node left)
    {
        this.data = data;
        this.right = right;
        this.left = left;
    }
}
