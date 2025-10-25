#include <iostream>
#include <vector>
#include <memory>
#include <stack>
#include <queue>
#define lli long long int
#define PRIME 1000000009
using namespace std;

string decompressString(const string& str){
    string result="";
    string subStr="";
    for(int i=0; i<str.length();i++){
        subStr=str[i];
        int count=(int)str[i]-48;
        int index=i;
        if(count>=1 && count<=9){
            subStr="";
            index+=2;
            while(str[index]!=']' && str[index]!='[' && index<str.length()){
                index++;
            }
            string subStrFrac=str.substr(i+2, index-i-2);
            while(count>0){
                subStr+=subStrFrac;
                count--;
            }
        }
        result+=subStr;
        i=index;
    }
    return result;
}
string compressString(const string &str){
    
}
int main()
{
    string str="a2[bc]ty1[w]3[er]";
    string decompressedString="abcbctywererer";
    string result=decompressString(str);
    cout << result << endl;

    compressString(decompressedString);
    return 0;
}