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

//����ݽ�������

class SpeechManger
{
public:

	//���캯��
	SpeechManger();

	//չʾ�˵�
	void show_Menu();

	//�˳�ϵͳ
	void exitSystem();

	//��������
	~SpeechManger();

	//��ʼ������������
	void initSpeech();

	//��Ա����
	//round 1
	vector<int>v1;
	
	//round 2
	vector<int>v2;

	//vitory
	vector<int>vVictory;

	//��ű�ż�����ѡ��
	map<int, Speaker>m_Speaker;

	//��ű�������
	int m_Index;

	//����12��ѡ��
	void creatSpeaker();

	//��ʼ����
	void startSpeech();

	//��ǩ
	void speechDraw();

	//����
	void speechContext();

};