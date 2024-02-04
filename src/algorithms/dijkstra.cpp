
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
#include <map>
#include <limits>

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
    EdgeNode(int dest, int weight)
    {
        this->dest = dest;
        this->weight = weight;
        this->next = nullptr;
    }
};

class AdjacencyList
{
private:
    vector<vector<EdgeNode *>> edges;
    int _numVertices;

public:
    AdjacencyList(int numVertices) : edges(numVertices)
    {
        this->_numVertices = numVertices;
    }
    void addEdge(const int src, const int dest)
    {
        edges[src].push_back(new EdgeNode(dest));
        edges[dest].push_back(new EdgeNode(src));
    }
    void addEdge(const int src, const int dest, int weight)
    {
        edges[src].push_back(new EdgeNode(dest, weight));
        edges[dest].push_back(new EdgeNode(src, weight));
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
    int findMinVertex(map<int, int> &distance, map<int, bool> &visited)
    {
        int minDist=INT32_MAX;
        int minVertex=-1;
        for(int i=0;i<_numVertices;i++){
            if(!visited[i] && distance[i]<minDist){
                minDist=distance[i];
                minVertex=i;
            }
        }
        return minVertex;
    }

    void findPath(int src, int dest, map<int, bool> &visited, map<int, int> &distance, map<int, int> &minPath)
    {

        for (int i = 0; i < _numVertices; i++)
        {
            int minVertex = findMinVertex(distance, visited);
            visited[minVertex] = true;
            auto adjacencyVertices = this->edges[minVertex];
            for (auto node : adjacencyVertices)
            {
                int v = node->dest;
                int vw = node->weight;
                if (!visited[v] && distance[minVertex] + vw < distance[v])
                {
                    distance[v] = distance[minVertex] + vw;
                    minPath[v] = minVertex;
                }
            }
        }
    }
    void printMinPath(int source, int dist, map<int, int> &minPath){
        cout << source << "";
        if(minPath[source]==source){
            return;
        }
        printMinPath(source, minPath[dist], minPath);
    }
    void findShortestPath(int src, int dest)
    {
        map<int, bool> visited;
        map<int, int> distance;
        map<int, int> minPath;
        for (int i = 0; i < this->_numVertices; i++)
        {
            visited[i] = false;
            distance[i] = INT32_MAX;
        }
        distance[src] = 0;
        minPath[0]=0;
        findPath(src, dest, visited, distance, minPath);
        for(auto dist: distance){
            cout << dist.first << " " << dist.second << endl;
        }
        cout << "min path: " << endl;
        

    }
};

int main()
{

    cout << "------ Start AdjacencyList -------" << endl;
    unique_ptr<AdjacencyList> list = make_unique<AdjacencyList>(6);
    list->addEdge(0, 1, 3);
    list->addEdge(1, 2, 3);
    list->addEdge(2, 0, 4);
    list->addEdge(3, 0, 1);
    list->addEdge(3, 1, 5);
    list->addEdge(4, 2, 5);
    list->addEdge(4, 1, 1);
    list->addEdge(5, 3, 1);
    list->addEdge(5, 4, 2);

    //list->printAllEdges();
    list->findShortestPath(0, 4);

    return 0;
}