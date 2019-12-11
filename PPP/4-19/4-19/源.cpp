#include "..\\..\\std_lib_facilities.h"


int main()
{
	string name = "";
	int score = 0;

	vector<string> names;
	vector<int> scores;

	while (cin >> name >> score)
	{
	
		bool already_have = false;
		for (string s : names)
		{
			if (name == s)
			{
				already_have = true;
				break;
			}
		}
		if (!already_have)
		{
			names.push_back(name);
			scores.push_back(score);
		}
	}

	for (int i = 0; i < names.size(); ++i)
		cout << "name: " << names[i] << "\t" << "score: " << scores[i] << endl;

}