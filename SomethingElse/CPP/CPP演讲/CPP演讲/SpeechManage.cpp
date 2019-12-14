#include "SpeechManager.h"

//���캯��
SpeechManger::SpeechManger()
{
	//��ʼ������
	this->initSpeech();

	//����ѡ��
	this->creatSpeaker();
}

//չʾ�˵�
void SpeechManger::show_Menu()
{
	cout << "*****************************" << endl;
	cout << "******��ӭ�μ��ݽ�����*********" << endl;
	cout << "*******1 ��ʼ�ݽ�����**********" << endl;
	cout << "*******2 �鿴������¼**********" << endl;
	cout << "*******3 ��ձ�����¼**********" << endl;
	cout << "*******0 �˳���������**********" << endl;
	cout << "******��ӭ�μ��ݽ�����*********" << endl;
	cout << endl;
}

//�˳�ϵͳ
void SpeechManger::exitSystem()
{
	cout << "ллʹ�ã���ӭ�´�����" << endl;
	system("pause");
	exit(0);
}

//��������
SpeechManger::~SpeechManger()
{
}

//��ʼ�����Ժ�����
void SpeechManger::initSpeech()
{
	//�����ÿ�
	this->v1.clear();
	this->v2.clear();
	this->vVictory.clear();
	this->m_Speaker.clear();
	//������1
	this->m_Index = 1;
}

//����12��ѡ��
void SpeechManger::creatSpeaker()
{
	string seed = "ABCDEFGHIJKL";
	for (int i = 0; i < seed.size(); i++)
	{
		string name = "ѡ��";
		name += seed[i];

		Speaker sp;
		sp.m_Name = name;
		for (int j = 0; j < 2; j++)
		{
			sp.m_Score[j] = 0;
		}

		//12��ѡ�ֱ��
		this->v1.push_back(i + 10001);

		//ѡ�ֱ�ţ���Ӧ��ѡ�� ����map����
		this->m_Speaker.insert(make_pair(i + 10001, sp));
	}
}

//��ʼ����
void SpeechManger::startSpeech()
{
	//��һ�ֱ���
	//1����ǩ
	speechDraw();
	//2������
	speechContext();
	//3�����

	//�ڶ��ֱ���
	//1����ǩ
	m_Index = 2;
	speechDraw();
	//2������
	speechContext();
	//3�����ս��

	//4���������
}

void SpeechManger::speechDraw()
{
	cout << "��" << this->m_Index << "�ֱ���ѡ�����ڳ�ǩ" << endl;
	cout << "===============================" << endl;
	cout << "��ǩ�������ݽ�˳�����£�" << endl;

	if (this->m_Index == 1)
	{
		random_shuffle(v1.begin(), v1.end());
		for (vector<int>::iterator it = v1.begin(); it < v1.end(); it++)
		{
			cout << *it << "  ";
		}
		cout << endl;
	}
	else
	{
		random_shuffle(v2.begin(), v2.end());
		for (vector<int>::iterator it = v2.begin(); it < v2.end(); it++)
		{
			cout << *it << "  ";
		}
		cout << endl;
	}

	cout << "------------------------------" << endl;
	system("pause");
	cout << endl;
}

void SpeechManger::speechContext()
{
	cout << "---------��" << this->m_Index << "�ֱ�����ʽ��ʼ-----" << endl;
	multimap<double, int, greater<double>> groupScore;//��ʱ���������key������value ѡ�ֱ��
	int num = 0;//��¼��Ա����6��һ��

	vector<int> v_Src;//������Ա����

	if (this->m_Index == 1)
	{
		v_Src = v1;
	}
	else
	{
		v_Src = v2;
	}

	//����������Ա
	for (vector<int>::iterator it = v_Src.begin(); it < v_Src.end(); it++)
	{
		num++;
		//��ί���
		deque<double>d;
		for (int i = 0; i < 10; i++)
		{
			double score = (rand() % 401 + 600) / 10.f;//��������������600-1000�ĸ��㣬int�����������ƽ������ͬ
			cout << score << " ";
			d.push_back(score);
		}
		cout << endl;

		sort(d.begin(), d.end(), greater<double>());//����
		d.pop_front();//ȥ����߷�
		d.pop_back();//ȥ����ͷ�

		double sum = accumulate(d.begin(), d.end(), 0.0f);
		double avg = sum / (double)d.size();

		cout << "��ţ�" << *it << " ѡ�֣�" << this->m_Speaker[*it].m_Name << "��ƽ����Ϊ��" << avg << endl;

		this->m_Speaker[*it].m_Score[this->m_Index - 1] = avg;

		//6��һ�飬����ʱ��������
		groupScore.insert(make_pair(avg, *it));

		if (num % 6 == 0)
		{
			cout << "��" << num / 6 << "��������Σ�" << endl;
			for (multimap<double, int, greater<double>>::iterator it = groupScore.begin(); it != groupScore.end(); it++)
			{
				cout << "��ţ�" << it->second << " ������" << this->m_Speaker[it->second].m_Name << " �ɼ���" << this->m_Speaker[it->second].m_Score[this->m_Index - 1] << endl;
			}

			int count = 0;
			//ȡǰ����
			for (multimap<double, int, greater<double>>::iterator it = groupScore.begin(); it != groupScore.end() && count < 3; it++, count++)
			{
				if (this->m_Index == 1)
				{
					v2.push_back((*it).second);
				}
				else
				{
					vVictory.push_back((*it).second);
				}
			}

			groupScore.clear();
			cout << endl;
		}

	}
	cout << "��" << this->m_Index << "�ֱ�������-------" << endl;
	if (this->m_Index != 1)//��ӡǰ3��
	{
		for (int i = 0; i < 3; i++)
		{
			cout << "��" << i + 1 << "����: " << this->m_Speaker[vVictory[i]].m_Name << endl;
		}
	}

	if (this->m_Index==1) //��ӡ��Χ��2�ֵ�ѡ��
	{
		cout << "��Χ��һ�ֵ�ѡ���У�";
		for (int i = 0; i < 6; i++)
		{
			cout << this->m_Speaker[v2[i]].m_Name<<"\t";
		}
		cout << endl;
	}
	system("pause");
}