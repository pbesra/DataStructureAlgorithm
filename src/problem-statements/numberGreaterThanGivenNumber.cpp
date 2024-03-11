#include <iostream>
#include <vector>
#include <memory>
// #include <bits/stdc++.h>
#define lli long long int
#define PRIME 1000000009

using namespace std;

int getHighestNum(vector<int> &nums, int n)
{
    int recentMax = INT32_MAX;
    int len = nums.size();
    bool found = false;
    bool nExist = false;

    for (int i = 0; i < len; i++)
    {
        if (nums[i] >= n)
        {
            nExist = true;
        }
        if (n < nums[i] && nums[i] < recentMax)
        {
            found = true;
            recentMax = nums[i];
        }
    }
    if (found)
    {
        return recentMax;
    }
    else if (nExist)
    {
        return n;
    }
    return recentMax;
}

int main()
{

    vector<int> nums{1, 37, -1, 17, 26, 29, -5, 35, 20, 50, 60};
    cout << getHighestNum(nums, 26) << endl;
    return 0;
}

// unique_ptr -> make_unique
// shared_ptr -> make_shared