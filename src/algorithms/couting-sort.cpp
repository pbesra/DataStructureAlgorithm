#include <iostream>
#include <vector>
#include <memory>
#define lli long long int
#define PRIME 1000000009
using namespace std;

int findMax(vector<int> &arr){
    int max=arr[0];
    for(auto i: arr){
        if(i>max){
            max=i;
        }
    }
    return max;
}
void countingSort(vector<int>& arr, vector<int>& result){
    int maxNum=findMax(arr);
    vector<int>countArr(maxNum+1, 0);
    for(int i=0;i<arr.size();i++){
        countArr[arr[i]]++;
    }
    for(int i=1;i<countArr.size();i++){
        countArr[i]=countArr[i]+countArr[i-1];
    }
    for(int i=0;i<arr.size();i++){
        result[countArr[arr[i]]]=arr[i];
        countArr[arr[i]]--;
    }
}
int main()
{
    vector<int> arr{5, 2, 1, 2, 3, 1, 2, 4, 1, 2, 5};
    vector<int> result(arr.size(), -1);
    countingSort(arr, result);
    for(int i = 1; i < result.size();i++){
        cout << result[i] << endl;
    }
    
    return 0;
}