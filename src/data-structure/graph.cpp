#include <iostream>
#include <vector>
#include <memory>
#include <algorithm>
#define lli long long int
#define PRIME 1000000009
using namespace std;

class EdgeNode
{
public:
    int dest;
    int weight;
    EdgeNode *next;
    // other edge attributes

    EdgeNode(int dest)
    {
        this->dest = dest;
        this->next = nullptr;
    }
};

class AdjacencyList
{
private:
public:
    vector<vector<EdgeNode *>> edges;
    AdjacencyList(int numVertices) : edges(numVertices)
    {
    }
    void addEdge(const int src, const int dest)
    {
        edges[src].push_back(new EdgeNode(dest));
        edges[dest].push_back(new EdgeNode(src));
    }
    void removeEdge(const int src, const int dest)
    {
        vector<EdgeNode *>::iterator iter = edges[src].begin();
        while (iter != edges[src].end())
        {
            auto tempDest = *iter;
            if (tempDest->dest == dest)
            {
                break;
            }
            ++iter;
        }
        edges[src].erase(iter);
    }
    void printAllEdges()
    {
        for (int i = 0; i < edges.size(); i++)
        {
            cout << i << "->";
            for (int j = 0; j < edges[i].size(); j++)
            {
                cout << edges[i][j]->dest << ",";
            }
            cout << endl;
        }
    }
};

int main()
{

    unique_ptr<AdjacencyList> list = make_unique<AdjacencyList>(4);
    list->addEdge(0, 1);
    list->addEdge(1, 2);
    list->addEdge(2, 0);
    list->addEdge(3, 0);
    list->addEdge(3, 1);
    list->removeEdge(3, 1);
    list->printAllEdges();
    return 0;
}