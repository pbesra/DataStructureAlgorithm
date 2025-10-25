#include <iostream>
#include <vector>
#include <memory>
#define lli long long int
#define PRIME 1000000009
using namespace std;

void insertionSort(vector<lli> &arr)
{
    int n = arr.size();

    for (int i = 1; i < n; i++)
    {
        int j = i;
        int value = arr[i];
        while (j > 0 && arr[j - 1] > value)
        {
            arr[j] = arr[j - 1];
            j--;
        }
        arr[j] = value;
    }
}

int main()
{
    vector<lli> arr{19, 10, 8, 17, 10, 6, 2, 9, 16};
    insertionSort(arr);
    for (auto item : arr)
    {
        cout << item << endl;
    }
    return 0;
}