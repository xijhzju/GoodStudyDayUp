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
	// s.OneYearPassed();// test的参数s是const，但student的OneYearPassed方法不是const，默认为会修改，所以不能使用。
	s.getAge();
	cout << s.age << endl;
}
int main()
{
	Student tom(5);
	test(tom);

}