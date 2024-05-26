#include <iostream>
#include <random>

using namespace std;

void xorshift(uint32_t& value, vector<uint32_t>& PsevdRand) {
    value ^= (value << 3);
    value ^= (value >> 5);
    value ^= (value << 2);
    PsevdRand.push_back(value);
}

int main() {
    vector<uint32_t> PsevdRand;
    uint32_t value = 123456789;
    for (int i = 0; i < 10; i++) {
        xorshift(value, PsevdRand);
    }
    for (uint32_t n : PsevdRand) {
        cout << n << " ";
    }
    cout << endl;
    return 0;
}