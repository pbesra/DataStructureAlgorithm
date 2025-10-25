#include <iostream>
#include <vector>
#include <memory>
#define lli long long int
#define PRIME 1000000009
using namespace std;

int findPivotIndex(vector<lli> &arr, int start, int end)
{
    int pivotIndex = start;
    int pivot = arr[end];
    for (int i = start; i < end; i++)
    {
        if (arr[start] <= pivot)
        {
            swap(arr[start], arr[pivotIndex]);
            pivotIndex++;
        }
        start++;
    }
    swap(arr[pivotIndex], arr[end]);
    return pivotIndex;
}

void quickSort(vector<lli> &arr, int start, int end)
{
    if (start > end)
    {
        return;
    }
    int pivotIndex = findPivotIndex(arr, start, end);
    quickSort(arr, start, pivotIndex - 1);
    quickSort(arr, pivotIndex + 1, end);
}

int main()
{
    vector<lli> arr{1, 10, 8, 20, 5, 13, 18, 8, 25, 7};
    quickSort(arr, 0, arr.size() - 1);
    int n = arr.size();
    for (int i = 0; i < n; i++)
    {
        cout << arr[i] << endl;
    }
    return 0;
}