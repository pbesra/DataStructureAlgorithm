#include <iostream>
#include <vector>
#include <memory>
#define lli long long int
using namespace std;

class PriorityQueue
{
public:
    vector<lli> arr;
    int n;
    PriorityQueue(vector<lli> &arr, int n)
    {
        this->arr = arr;
        this->n = n;
    }
    void makeMinPriorityQueue(vector<lli> &arr, int n, int i)
    {
        int left = 2 * i + 1;
        int right = 2 * i + 2;
        int root = i;
        if (left < n && arr[left] < arr[root])
        {
            root = left;
        }
        if (right < n && arr[right] < arr[root])
        {
            root = right;
        }
        if (root != i)
        {
            // swap root and i
            swap(arr[root], arr[i]);
            makeMinPriorityQueue(arr, n, root);
        }
    }
    void makeMaxPriorityQueue(vector<lli> &arr, int n, int i)
    {
        int left = 2 * i + 1;
        int right = 2 * i + 2;
        int root = i;
        if (left < n && arr[left] > arr[root])
        {
            root = left;
        }
        if (right < n && arr[right] > arr[root])
        {
            root = right;
        }
        if (root != i)
        {
            // swap root and i
            swap(arr[root], arr[i]);
            makeMinPriorityQueue(arr, n, root);
        }
    }

    void priorityQueue()
    {
        for (int i = this->n / 2 - 1; i >= 0; i--)
        {
            makeMinPriorityQueue(this->arr, this->n, i);
        }
    }

    // get top item from priority queue
    lli peek()
    {
        return this->arr[0];
    }
    void enqueue(lli item)
    {
        this->arr.push_back(item);
        priorityQueue();
    }
    void dequeue()
    {
        this->arr.pop_back();
    }
    void deleteNodeAtIndex(int index)
    {
        if (index < 0 || index >= this->arr.size())
        {
            cout << "ERROR: Invalid index" << endl;
            return;
        }
        this->arr.erase(this->arr.begin() + index);
    }
};

int main()
{

    // initial items in the vector
    vector<lli> arr{16, 20, 28, 12, 6, 10, 15, 2, 7};
    int n = arr.size();

    // make auto memory management
    unique_ptr<PriorityQueue> priorityQueue = make_unique<PriorityQueue>(arr, n);
    priorityQueue->priorityQueue();

    cout << "size: " << priorityQueue->arr.size() << endl;

    int size = priorityQueue->arr.size();

    priorityQueue->enqueue(13);

    // print queue after making priority queue
    for (int i = 0; i < size; i++)
    {
        cout << priorityQueue->arr[i] << endl;
    }
    cout << "peek: " << priorityQueue->peek() << endl;

    return 0;
}