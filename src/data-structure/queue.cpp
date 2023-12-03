#include <iostream>
#include <vector>
#include <memory>
#include<cassert>
#define lli long long int
#define PRIME 1000000009
using namespace std;

template<typename T>
class Node{
    public:
        T data;
        Node* next;
        int size=0;
        Node(T data){
            this->data = data;
            this->next = nullptr;
            
        }
};
template<typename T>
class Queue{
    public:
        Node<T>* head=nullptr;
        Node<T>* tail=nullptr;
        int queueSize=0;
        Node<T>* getNode(T data){
            this->queueSize++;
            return new Node<T>(data);
        }
        void removeNode(){
            assert(this->head!=nullptr);
            assert(this->tail!=nullptr);
            this->queueSize--;
            this->tail=nullptr;
        }
        void push(T data){
            Node<T>* node=getNode(data);
            if(this->head==nullptr){
                this->head=node;
                this->tail=node;
                return;
            }
            this->tail->next=node;
            this->tail=node;
        }
        void pop(){
            removeNode();
        }
        T peek(){
            assert(this->head!=nullptr);
            return this->head->data;
        }
        void printNodes(){
            Node<T>* node=this->head;
            while(node!=nullptr){
                cout << node->data << endl;
                node=node->next;
            }
        }
        int size(){
            return this->queueSize;
        }
        
};

int main()
{
    unique_ptr<Queue<int>> queue=make_unique<Queue<int>>();
    queue->push(10);
    queue->push(18);
    queue->push(17);
    queue->push(15);
    queue->push(87);
    queue->push(100);
    queue->push(191);
    queue->push(101);
    queue->pop();
    queue->pop();
    cout << "print all nodes: "<< endl;
    queue->printNodes();
    cout << "queue size: "<<  queue->size() << endl;;
    cout << "queue peek: "<<  queue->peek() << endl;
    return 0;
}