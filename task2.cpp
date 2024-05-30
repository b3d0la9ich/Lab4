#include <iostream>
#include <random>
#include <vector>
#include <algorithm>
#include <unordered_map>

using namespace std;

void randomFill(vector<int>& fillVec, int N, int gr1, int gr2) {
    random_device rd;
    mt19937_64 random_(rd());
    for (int i = 0; i < N; i++) {
        fillVec.push_back(random_()%gr1 + gr2);
    }
}

void newMass(const vector<int>& rand1, const vector<int>& rand2, vector<int>& New) {
    int ind = 0;
    for (int n : rand1) {
        if (ind % 2 == 0) {
            New.push_back(n + rand2[ind]);
        }
        else {
            New.push_back(n - rand2[ind]);
        }
        ind++;
    }
}

int main() {
    system("chcp 65001");
    //1-2
    int N = 10;
    vector<int> randNum;
    randomFill(randNum, N, 101, 100);
    sort(randNum.begin(), randNum.end());
    cout << "Массив с случайными значениями: ";
    for (int n : randNum) {
        cout << n << " " << endl;
    } 
    cout << endl;
    cout << "Второй по величине элемент: " << randNum[N-2] << endl;
    int sum = 0;
    randNum.pop_back();
    randNum.pop_back();
    randNum.erase(randNum.begin());
    for (int i : randNum) {
        sum += i;
    }
    cout << "Сумма: " << sum << endl;

    randNum.clear();
    //3
    vector<int> randNum1;
    vector<int> New;

    randomFill(randNum, N, 101, -50);
    randomFill(randNum1, N, 101, -50);

    newMass(randNum, randNum1, New);

    cout << "Первый массив с случайными значениями: ";
    for (int n : randNum) {
        cout << n << " ";
    }
    cout << endl;
    cout << "Второй массив с случайными значениями: ";
    for (int n : randNum1) {
        cout << n << " ";
    }
    cout << endl;
    cout << "Новый массив: ";
    for (int n : New) {
        cout << n << " ";
    }
    cout << endl;
    unordered_map<int, int> povtor;
    for (int n : New) {
        povtor[n]++;
    }
    for (pair<int, int> n : povtor) {
        cout << "Элемент: " << n.first << " Количество повторов: " << n.second << endl;
    }
    int a, b;
    cout << "Введите начальный и конечный год: ";
    cin >> a >> b;
    vector<int> visokYears;
    for (int i = a; i <= b; i++) {
        if ((i % 4 == 0 && i % 100 != 0) || (i % 400 == 0)) {
            visokYears.push_back(i);
        }
    }
    cout << "Високосные годы: ";
    for (int n : visokYears) {
        cout << n << " ";
    }
    return 0;
}