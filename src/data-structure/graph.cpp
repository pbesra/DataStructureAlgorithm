
/*
This deals with undirected graph.
There are two data structures here:
1.) AdjacencyList
2.) AdjacencyMatrix
*/
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
    vector<vector<EdgeNode *>> edges;

public:
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

class AdjacencyMatrix
{
private:
    vector<vector<EdgeNode *>> edgeMatrix;

public:
    AdjacencyMatrix(int numVertices) : edgeMatrix(numVertices, std::vector<EdgeNode *>(numVertices, nullptr)) {}
    void addEdge(const int src, const int dest)
    {
        edgeMatrix[src][dest] = new EdgeNode(dest);
        edgeMatrix[dest][src] = new EdgeNode(dest);
    }
    void removeEdge(const int src, const int dest)
    {
        edgeMatrix[src][dest] = nullptr;
        edgeMatrix[dest][src] = nullptr;
    }

    void printEdges()
    {
        for (int i = 0; i < edgeMatrix.size(); i++)
        {
            cout << i << "->";
            for (int j = 0; j < edgeMatrix[i].size(); j++)
            {
                if (edgeMatrix[i][j] != nullptr)
                {
                    cout << j << ",";
                }
            }
            cout << endl;
        }
    }
};

int main()
{

    cout << "------ Start AdjacencyList -------" << endl;
    unique_ptr<AdjacencyList> list = make_unique<AdjacencyList>(4);
    list->addEdge(0, 1);
    list->addEdge(1, 2);
    list->addEdge(2, 0);
    list->addEdge(3, 0);
    list->addEdge(3, 1);
    list->removeEdge(3, 1);
    list->printAllEdges();

    cout << "------ Start AdjacencyMatrix -------" << endl;
    unique_ptr<AdjacencyMatrix> matrix = make_unique<AdjacencyMatrix>(4);
    matrix->addEdge(0, 1);
    matrix->addEdge(0, 2);
    matrix->addEdge(0, 3);
    matrix->addEdge(2, 3);
    matrix->removeEdge(0, 1);
    matrix->printEdges();
    return 0;
}