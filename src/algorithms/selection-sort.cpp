#include <iostream>
#include <vector>
#include <memory>
#define lli long long int
#define PRIME 1000000009
using namespace std;

void selectionSort(vector<lli> &arr)
{
    int n = arr.size();
    for (int i = 0; i < n - 1; i++)
    {
        int minIndex = i;
        for (int j = i + 1; j < n; j++)
        {
            if (arr[j] < arr[minIndex])
            {
                minIndex = j;
            }
        }
        swap(arr[i], arr[minIndex]);
    }
}
int main()
{
    vector<lli> arr{10, 4, 19, 15, 18, 13, 5, 8};
    selectionSort(arr);
    for (auto item : arr)
    {
        cout << item << endl;
    }
    return 0;
}