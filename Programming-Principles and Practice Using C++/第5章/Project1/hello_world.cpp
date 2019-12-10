#include "..\\..\\std_lib_facilities.h"
#include <vector>
#include<algorithm>
#include<iostream>
using namespace std;

//�Լ���exception��
class My_err
{
public:
	void what() { cout << s << endl; }
	My_err(string str) { s = str; }
private:
	string s;
};

//����n��쳲�������
vector<int> fibo(int n)
{
	vector<int> v;

	if (n < 1)
	{
		throw My_err("cant lower than 1");
	}
	if (n == 1)
	{
		v.push_back(1);
		return v;
	}
	if (n == 2)
	{
		v.push_back(1);
		v.push_back(1);
		return v;
	}
	//n>=3
	v.push_back(1);
	--n;
	v.push_back(1);
	--n;
	while (n)
	{
		int t = 0;
		int len = v.size();
		t = v[len - 1] + v[len - 2];
		v.push_back(t);
		--n;
	}
	return v;

}

//��5�µ�13�⡣ ����4��0-9�������������һ��vector�С�
vector<int> four_rand_num()
{
	vector<int> v;
	srand((unsigned int)time(NULL));
	int i = 4;
	while (i)
	{
		v.push_back(rand() % 10);
		--i;
	}
	return v;
}

//��Ҳ�4������
vector<int> guess_bull_cow()
{
	cout << "please input four digit(for example:1234 or 3943)\n";
	vector<int> v;
	for (int i = 4; i > 0; --i)//û�м������ĸ�ʽ������ע�⣡����
	{
		char c;
		cin >> c;
		int n = c - '0';
		v.push_back(n);
	}
	return v;
}

//�Ƚ�2��vector��������ʾ
void prompt_bull_cow(const vector<int>& v1, const vector<int>& v2)
{
	int num_bull = 0;
	int num_cow = 0;
	for (int i = 0; i < 4; i++)
	{
		for (int j = 0; j < 4; j++)
		{
			if (v1[i] == v2[j])
			{
				if (i == j)
				{
					num_bull++;
				}
				else
				{
					num_cow++;
				}
			}
		}
	}
	cout << num_bull << " bull,and " << num_cow << " cow\n";
}

//��ӡ��vector
template<typename T>
void print_vector(const vector<T> v)
{
	for (T i : v) cout << i << '\t';
	cout << endl;

}

//��5�µ�13��:��ţĸţ��Ϸ
void bull_cow()
{
	vector<int> v1 = four_rand_num();
	vector<int> v2;
	//print_vector(v1);//����ʱ��
	while (1)
	{
		v2 = guess_bull_cow();
		if (v1 == v2)
		{
			cout << "bingo!\n";
			return;
		}
		prompt_bull_cow(v1, v2);
	}
}

//��14�⻹û��������
int main()
{


	bull_cow();


	keep_window_open();
	return 0;
}
