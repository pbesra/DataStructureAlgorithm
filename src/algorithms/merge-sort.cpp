#include <iostream>
#include <vector>
#include <memory>
#define lli long long int
#define PRIME 10000000009
using namespace std;

void merge(vector<lli> left, vector<lli> right, vector<lli> &arr)
{
    int nLeft = left.size();
    int nRight = right.size();
    int i = 0;
    int j = 0;
    int k = 0;
    while (i < nLeft && j < nRight)
    {
        if (left[i] < right[j])
        {
            arr[k] = left[i];

            i++;
        }
        else
        {
            arr[k] = right[j];
            j++;
        }
        k++;
    }
    while (i < nLeft)
    {
        arr[k] = left[i];
        i++;
        k++;
    }
    while (j < nRight)
    {
        arr[k] = right[j];
        j++;
        k++;
    }
}

void mergeSort(vector<lli> &arr, int n)
{

    if (n < 2)
    {
        return;
    }
    vector<lli> left;
    vector<lli> right;
    int mid = (n) / 2;
    for (int i = 0; i < mid; i++)
    {
        left.push_back(arr[i]);
    }
    for (int i = mid; i < n; i++)
    {
        right.push_back(arr[i]);
    }
    mergeSort(left, left.size());
    mergeSort(right, right.size());
    merge(left, right, arr);
}

int main()
{
    vector<lli> arr{10, 45, 12, 18, 17, 23, 6};
    mergeSort(arr, arr.size());
    for (auto item : arr)
    {
        cout << item << endl;
    }
    return 0;
}