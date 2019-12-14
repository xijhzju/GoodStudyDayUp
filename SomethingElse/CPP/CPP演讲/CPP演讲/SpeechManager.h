#pragma once
#include <iostream>
using namespace std;
#include<vector>
#include<map>
#include"Speaker.h"
#include<algorithm>
#include<deque>
#include<numeric>
#include<string>

//设计演讲管理函数

class SpeechManger
{
public:

	//构造函数
	SpeechManger();

	//展示菜单
	void show_Menu();

	//退出系统
	void exitSystem();

	//析构函数
	~SpeechManger();

	//初始化容器和属性
	void initSpeech();

	//成员属性
	//round 1
	vector<int>v1;
	
	//round 2
	vector<int>v2;

	//vitory
	vector<int>vVictory;

	//存放编号及具体选手
	map<int, Speaker>m_Speaker;

	//存放比赛轮数
	int m_Index;

	//创建12名选手
	void creatSpeaker();

	//开始比赛
	void startSpeech();

	//抽签
	void speechDraw();

	//比赛
	void speechContext();

};