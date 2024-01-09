#include <iostream>
#include <vector>
#include <memory>
#include <algorithm>
#define lli long long int
#define PRIME 1000000009
using namespace std;

int getIndex(vector<int> &numbers, int startIndex, int endIndex, int data)
{
    if (startIndex > endIndex)
    {
        return -1;
    }

    int mid = (startIndex + endIndex) / 2;
    if (numbers[mid] == data)
    {
        return mid;
    }
    else if (data < numbers[mid])
    {
        return getIndex(numbers, startIndex, mid - 1, data);
    }
    return getIndex(numbers, mid + 1, endIndex, data);
}

int binarySearch(vector<int> &numbers, int data)
{
    sort(numbers.begin(), numbers.end());
    return getIndex(numbers, 0, numbers.size() - 1, data);
}

int main()
{

    vector<int> numbers{10, 18, 16, 16, 1, 7, 5, 8, 18, 40, 21, 34};
    int data = 48;
    int index = binarySearch(numbers, data);
    cout << "index: " << index << endl;
    cout << numbers[index] << endl;
    return 0;
}