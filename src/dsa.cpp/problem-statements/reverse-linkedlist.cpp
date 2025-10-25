#include <iostream>
#include <vector>
#include <memory>
#include <cassert>
#define lli long long int
#define PRIME 1000000009
using namespace std;

template <typename T>
class Node
{
public:
    T data;
    Node *next;
    int size = 0;
    Node(T data)
    {
        this->data = data;
        this->next = nullptr;
    }
};
template <typename T>
class Stack
{
public:
    Node<T> *head = nullptr;
    int stackSize = 0;
    Node<T> *getNode(T data)
    {
        this->stackSize++;
        return new Node<T>(data);
    }
    void removeNode()
    {
        assert(this->head != nullptr);
        this->stackSize--;
        this->head = this->head->next;
    }
    void push(T data)
    {
        Node<T> *node = getNode(data);
        node->next = this->head;
        this->head = node;
    }
    void pop()
    {
        assert(this->head != nullptr);
        removeNode();
    }
    T peek()
    {
        assert(this->head != nullptr);
        return this->head->data;
    }
    void printNodes()
    {
        Node<T> *node = this->head;
        while (node != nullptr)
        {
            cout << node->data << endl;
            node = node->next;
        }
    }
    int size()
    {
        return this->stackSize;
    }
    Node<T> *reverseLinkedList(Node<T> *nodeRoot)
    {
        Node<T> *currNode = nodeRoot;
        Node<T> *prevNode = nullptr;

        while (currNode != nullptr)
        {

            Node<T> *nextNode = currNode->next;
            currNode->next = prevNode;
            prevNode = currNode;
            currNode = nextNode;
        }
        return prevNode;
    }
    void printNodes(Node<T> *nodeRoot)
    {
        while (nodeRoot != nullptr)
        {
            cout << nodeRoot->data << endl;
            nodeRoot = nodeRoot->next;
        }
    }
};

int main()
{
    unique_ptr<Stack<int>> stack = make_unique<Stack<int>>();
    stack->push(10);
    stack->push(18);
    stack->push(17);
    stack->push(15);
    stack->push(87);
    stack->push(100);
    stack->push(191);
    stack->push(101);
    auto *nodeRoot = stack->reverseLinkedList(stack->head);

    stack->printNodes(nodeRoot);
    return 0;
}