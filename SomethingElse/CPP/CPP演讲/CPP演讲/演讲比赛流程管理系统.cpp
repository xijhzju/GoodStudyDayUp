#include <iostream>
using namespace std;
#include "SpeechManager.h"
#include<string>

int main()
{
	SpeechManger sm;

	//以下测试代码
	//===============
	/*for (map<int, Speaker>::iterator it = sm.m_Speaker.begin(); it != sm.m_Speaker.end(); it++)
	{
		cout << "选手编号：" << it->first << "姓名：" << it->second.m_Name << "成绩：" << it->second.m_Score[0] << endl;
	}*/

	//sm.speechDraw();


	//=======================
	//以上是测试代码
	int choice = 0;//存储用户的选项

	while (true)
	{
		sm.show_Menu();

		cout << "请输入你的选择..." << endl;
		cin >> choice;//接受用户选择

		switch (choice)
		{
		case 1://开始比赛
			sm.startSpeech();
			break;
		case 2://查看记录
			break;
		case 3://清空记录
			break;
		case 0://退出系统
			sm.exitSystem();
			break;
		default:
			system("cls");//清屏
			break;
		}
	}

	system("pause");
	return 0;
}