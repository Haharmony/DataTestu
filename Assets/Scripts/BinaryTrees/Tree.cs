using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public Node root;

    public Tree()
    {
        root = null;
    }

    public void Add(int data)
    {
        Node node = new Node(data);

        if(root == null)
        {
            root = node;
            return;
        }

        Node tmp = root;
        while (tmp != null)
        {          
            if(data < tmp.data)
            {
                
                tmp.left = node;
                
            }
            else
            {
                tmp.right = node;
                
            }
            
        }
    }
}
