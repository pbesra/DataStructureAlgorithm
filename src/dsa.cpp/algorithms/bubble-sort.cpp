#include <iostream>
#include <vector>
#include <memory>
#define lli long long int
#define PRIME 1000000009
using namespace std;

void bubbleSort(vector<lli> &arr)
{
    int n = arr.size();
    for (int i = 0; i < n; i++)
    {
        for (int j = i; j < n; j++)
        {
            if (arr[i] > arr[j])
            {
                swap(arr[i], arr[j]);
            }
        }
    }
}

int main()
{
    vector<lli> arr{10, 19, 16, 15, 7, 30, 13};
    bubbleSort(arr);
    for (auto item : arr)
    {
        cout << item << endl;
    }
    return 0;
}