#include "SpeechManager.h"

//构造函数
SpeechManger::SpeechManger()
{
	//初始化属性
	this->initSpeech();

	//创建选手
	this->creatSpeaker();
}

//展示菜单
void SpeechManger::show_Menu()
{
	cout << "*****************************" << endl;
	cout << "******欢迎参加演讲比赛*********" << endl;
	cout << "*******1 开始演讲比赛**********" << endl;
	cout << "*******2 查看以往记录**********" << endl;
	cout << "*******3 清空比赛记录**********" << endl;
	cout << "*******0 退出比赛程序**********" << endl;
	cout << "******欢迎参加演讲比赛*********" << endl;
	cout << endl;
}

//退出系统
void SpeechManger::exitSystem()
{
	cout << "谢谢使用，欢迎下次再来" << endl;
	system("pause");
	exit(0);
}

//析构函数
SpeechManger::~SpeechManger()
{
}

//初始化属性和容器
void SpeechManger::initSpeech()
{
	//容器置空
	this->v1.clear();
	this->v2.clear();
	this->vVictory.clear();
	this->m_Speaker.clear();
	//轮数置1
	this->m_Index = 1;
}

//创建12名选手
void SpeechManger::creatSpeaker()
{
	string seed = "ABCDEFGHIJKL";
	for (int i = 0; i < seed.size(); i++)
	{
		string name = "选手";
		name += seed[i];

		Speaker sp;
		sp.m_Name = name;
		for (int j = 0; j < 2; j++)
		{
			sp.m_Score[j] = 0;
		}

		//12名选手编号
		this->v1.push_back(i + 10001);

		//选手编号，对应的选手 存入map容器
		this->m_Speaker.insert(make_pair(i + 10001, sp));
	}
}

//开始比赛
void SpeechManger::startSpeech()
{
	//第一轮比赛
	//1：抽签
	speechDraw();
	//2：比赛
	speechContext();
	//3：结果

	//第二轮比赛
	//1：抽签
	m_Index = 2;
	speechDraw();
	//2：比赛
	speechContext();
	//3：最终结果

	//4：保存分数
}

void SpeechManger::speechDraw()
{
	cout << "第" << this->m_Index << "轮比赛选手正在抽签" << endl;
	cout << "===============================" << endl;
	cout << "抽签结束，演讲顺序如下：" << endl;

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
	cout << "---------第" << this->m_Index << "轮比赛正式开始-----" << endl;
	multimap<double, int, greater<double>> groupScore;//临时容器，存放key分数，value 选手编号
	int num = 0;//记录人员数，6个一组

	vector<int> v_Src;//比赛人员容器

	if (this->m_Index == 1)
	{
		v_Src = v1;
	}
	else
	{
		v_Src = v2;
	}

	//遍历比赛成员
	for (vector<int>::iterator it = v_Src.begin(); it < v_Src.end(); it++)
	{
		num++;
		//评委打分
		deque<double>d;
		for (int i = 0; i < 10; i++)
		{
			double score = (rand() % 401 + 600) / 10.f;//打分用随机数代替600-1000的浮点，int不好最后容易平均分相同
			cout << score << " ";
			d.push_back(score);
		}
		cout << endl;

		sort(d.begin(), d.end(), greater<double>());//排序
		d.pop_front();//去掉最高分
		d.pop_back();//去掉最低分

		double sum = accumulate(d.begin(), d.end(), 0.0f);
		double avg = sum / (double)d.size();

		cout << "编号：" << *it << " 选手：" << this->m_Speaker[*it].m_Name << "的平均分为：" << avg << endl;

		this->m_Speaker[*it].m_Score[this->m_Index - 1] = avg;

		//6人一组，用临时容器保存
		groupScore.insert(make_pair(avg, *it));

		if (num % 6 == 0)
		{
			cout << "第" << num / 6 << "组比赛名次：" << endl;
			for (multimap<double, int, greater<double>>::iterator it = groupScore.begin(); it != groupScore.end(); it++)
			{
				cout << "编号：" << it->second << " 姓名：" << this->m_Speaker[it->second].m_Name << " 成绩：" << this->m_Speaker[it->second].m_Score[this->m_Index - 1] << endl;
			}

			int count = 0;
			//取前三名
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
	cout << "第" << this->m_Index << "轮比赛结束-------" << endl;
	if (this->m_Index != 1)//打印前3名
	{
		for (int i = 0; i < 3; i++)
		{
			cout << "第" << i + 1 << "名是: " << this->m_Speaker[vVictory[i]].m_Name << endl;
		}
	}

	if (this->m_Index==1) //打印入围第2轮的选手
	{
		cout << "入围下一轮的选手有：";
		for (int i = 0; i < 6; i++)
		{
			cout << this->m_Speaker[v2[i]].m_Name<<"\t";
		}
		cout << endl;
	}
	system("pause");
}