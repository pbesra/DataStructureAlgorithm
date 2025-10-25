#include <iostream>
#include <vector>
#include <memory>
#include <cmath>
#include <cassert>
#include <climits>
#define lli long long int
#define PRIME 1000000009
using namespace std;



int findMax(vector<lli> &arr){
    int max=arr[0];
    for(auto i: arr){
        if(i>max){
            max=i;
        }
    }
    return max;
}


void countSortBasedOnDigit(vector<lli> &arr, int digitPos){
    
    vector<lli> countArr(10, 0);
    vector<lli> outputArr(arr.size(), INT_MIN);
    // find frequency 
    for(int i=0; i<arr.size();i++){
        int n=(arr[i]/digitPos)%10;
        countArr[n]++;
    }
    // do cumulative sum of frequencies
    for(int i=1; i<countArr.size();i++){
        countArr[i]+=countArr[i-1];
    }

    // build the output array
    for (int i = arr.size()-1; i>=0; i--)
    {
        int index=countArr[(arr[i]/digitPos)%10];
        outputArr[index-1] = arr[i];
        countArr[(arr[i]/digitPos)%10]--;
    }
    
    for (int i = 0; i < outputArr.size(); i++)
    {
        arr[i] = outputArr[i];
    }
}

void radixSort(vector<lli> &arr){
    int maxNum=findMax(arr);
    for(int digitPos=1;maxNum/digitPos>0;digitPos*=10){
        countSortBasedOnDigit(arr,digitPos);
    }
}

int main()
{
    vector<lli> arr{192, 172, 571, 264, 891, 423, 761};
    radixSort(arr);
    for(auto item:arr){
        cout << item << endl;
    }
    return 0;
}