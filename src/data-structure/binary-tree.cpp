#include <iostream>
#include <vector>
#include <memory>
#include <climits>
#define lli long long int
#define PRIME 1000000009
using namespace std;

template <typename T>
class Node
{
public:
    T data;
    Node<T> *left;
    Node<T> *right;
    Node(T _data)
    {
        this->data = _data;
        this->left = nullptr;
        this->right = nullptr;
    }
};

template <typename T>
class BinaryTree
{
private:
    Node<T> *addNode(T data, Node<T> *rootTemp)
    {
        if (rootTemp == nullptr)
        {
            return new Node<T>(data);
            ;
        }
        else if (data < rootTemp->data)
        {
            rootTemp->left = addNode(data, rootTemp->left);
            return rootTemp;
        }
        else if (data >= rootTemp->data)
        {
            rootTemp->right = addNode(data, rootTemp->right);
            return rootTemp;
        }
        return rootTemp;
    }
    void printNodesInorder(Node<T> *head)
    {
        if (head == nullptr)
        {
            return;
        }
        cout << head->data << endl;
        printNodesInorder(head->left);
        printNodesInorder(head->right);
    }
    void printNodesPrerder(Node<T> *head)
    {
        if (head == nullptr)
        {
            return;
        }
        printNodesPrerder(head->left);
        cout << head->data << endl;
        printNodesPrerder(head->right);
    }
    void printNodesPostrder(Node<T> *head)
    {
        if (head == nullptr)
        {
            return;
        }
        printNodesPostrder(head->left);
        printNodesPostrder(head->right);
        cout << head->data << endl;
    }
    int getHeight(Node<T> *rootTemp)
    {
        if (rootTemp == nullptr)
        {
            return -1;
        }
        return 1 + max(getHeight(rootTemp->left), getHeight(rootTemp->right));
    }
    Node<T> *remove(T data, Node<T> *rootTemp)
    {
        if (rootTemp == nullptr)
        {
            return rootTemp;
        }
        else if (data < rootTemp->data)
        {

            rootTemp->left = remove(data, rootTemp->left);

            return rootTemp;
        }
        else if (data > rootTemp->data)
        {

            rootTemp->right = remove(data, rootTemp->right);

            return rootTemp;
        }
        if (rootTemp->left == nullptr)
        {
            Node<T> *node = rootTemp->right;
            delete rootTemp;
            return node;
        }
        else if (rootTemp->right == nullptr)
        {
            Node<T> *node = rootTemp->left;
            delete rootTemp;
            return node;
        }
        else
        {
            Node<T> *node = rootTemp->right;
            while (node->left != nullptr)
            {
                node = node->left;
            }
            rootTemp->data = node->data;
            // call recursive -> node that needs to be deleted and new root

            rootTemp->right = remove(node->data, rootTemp->right);
            return rootTemp;
        }
    }
    Node<T> *reverseTree(Node<T> *rootTemp)
    {
        if (rootTemp == nullptr)
        {
            return rootTemp;
        }
        Node<T> *rootTempLeft = reverseTree(rootTemp->left);
        Node<T> *rootTempRight = reverseTree(rootTemp->right);
        rootTemp->left = rootTempRight;
        rootTemp->right = rootTempLeft;
        return rootTemp;
    }
    int binarySearch(Node<T> *rootTemp, int data)
    {
        if (rootTemp == nullptr)
        {
            return -1;
        }
        if (data == rootTemp->data)
        {
            return 1;
        }
        else if (data < rootTemp->data)
        {
            return binarySearch(rootTemp->left, data);
        }
        return binarySearch(rootTemp->right, data);
    }

public:
    Node<T> *root = nullptr;

    void add(T data)
    {
        this->root = addNode(data, this->root);
    }

    void print(int order = 2)
    {
        switch (order)
        {
        case 1:
            cout << "print preorder " << endl;
            printNodesPrerder(this->root);
            break;
        case 3:
            cout << "print postorder " << endl;
            printNodesPostrder(this->root);
            break;

        default:
            cout << "print inorder " << endl;
            printNodesInorder(this->root);
            break;
        }
    }

    int height()
    {
        return getHeight(this->root);
    }
    void removeNode(T data)
    {
        this->root = remove(data, this->root);
    }
    void reverse()
    {
        this->root = reverseTree(this->root);
    }
    int binarySearchNode(int data)
    {
        return binarySearch(this->root, data);
    }
};

int main()
{
    unique_ptr<BinaryTree<int>> binaryTree = make_unique<BinaryTree<int>>();
    binaryTree->add(100);
    binaryTree->add(50);
    binaryTree->add(500);
    binaryTree->add(25);
    binaryTree->add(75);
    binaryTree->add(250);
    binaryTree->add(1000);
    binaryTree->add(12);
    binaryTree->add(40);
    binaryTree->add(60);
    binaryTree->add(85);
    binaryTree->add(55);
    binaryTree->add(65);
    cout << "remove 50: " << endl;
    binaryTree->removeNode(50);
    // 1-preorder, 2-inorder, 3-postorder
    binaryTree->print(2);
    cout << "height: " << binaryTree->height() << endl;
    int isFound = binaryTree->binarySearchNode(65);
    cout << "is found: " << isFound << endl;
    return 0;
}