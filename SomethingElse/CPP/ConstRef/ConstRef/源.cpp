#include <iostream>
using namespace std;

class Student
{
public:
	int age;
	void OneYearPassed() { age++; }
	int getAge() const { return age; }
	Student(int a) :age(a) {}
};

void test(const Student& s) 
{
	// s.OneYearPassed();// test�Ĳ���s��const����student��OneYearPassed��������const��Ĭ��Ϊ���޸ģ����Բ���ʹ�á�
	s.getAge();
	cout << s.age << endl;
}
int main()
{
	Student tom(5);
	test(tom);

}