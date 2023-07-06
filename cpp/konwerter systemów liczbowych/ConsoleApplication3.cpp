#include <iostream>
#include <string>
using namespace std;
long todec(long from,string s ) {
    string a = "0123456789abcdef";
	long num = 0;
	int multiplier = 1;
	for (long i = s.length() - 1; i >= 0; i--)
	{
		long c = a.find_first_of(s[i]);
		if (c  > from - 1  || c == -1 ) {
			printf("zly format liczby ");
			return -1; 
		}
		num +=c *multiplier;
		multiplier *= from;
	}
	return num; 
}
string toany(int toSys , long fromLiczba   ) {	
	string a = "0123456789abcdef";
	string ret = "";
	if (toSys != 1) {
		long multiplier = toSys;
		while (multiplier <= fromLiczba)
		{
			multiplier *= toSys;
		}
		multiplier /= toSys;
		bool go = true;
		while (go)
		{
			if (multiplier == 0) {
				go = false;
				continue;
			}
			long calosci = fromLiczba / multiplier;
			long reszta = fromLiczba % multiplier;
			ret += a[calosci];
			fromLiczba -= multiplier * calosci;
			multiplier /= toSys;
		}
	}
	else {
		for (size_t i = 0; i < fromLiczba; i++)
		{
			ret += "1";
		}
	}
	return ret;	
}
void prosokomende (bool zjedynkowym) {
	cout << "MOZLIWE KOMENDY\nq-wyjdz  \nconv - konwertujna wskazany system liczbowy\nconva - konwertuj na wszystkie uwzglednione systemy liczbowe(" << (zjedynkowym ? "1" : "2") << "-16)\njeden-uwzglednij system jedynkowy przy wypisywaniu wszystkich(" << (zjedynkowym ? "uwzgledniony" : "nieuwzgledniony") << ")\nkomenda:";

}
int main()
{
	bool go = true;
	bool zjedynkowym = false;
	

	while ( go ) {
		prosokomende(zjedynkowym);
		char input[15] ;
		cin >> input;
		system("cls");

		if (!strcmp( input ,"q")) {
			go = false;
			//return 1 ;
			continue;
		}
		else if (!strcmp( input  ,"cls"))
		{
			system("cls");

		}
		else if (!strcmp( input ,"conv")) {
			printf("wprowadz system zrodlowy");
			int  system; 
			cin >> system;
			string liczba = "";
			printf("wprowadz liczbe ");
			cin >> liczba;
			long converted = todec(system,liczba);
			if (converted ==-1) {
				printf("sproboj ponownie");
			}
			else {
				printf("wprowadz system docelowy ");
				string a; 
				cin >> a;
				int tosys = stoi(a);
				cout << liczba << "(" << system << ")" << " to " <<toany(tosys, converted) <<"("<<a << ")\n";
			}	
		}
		else if (!strcmp(input, "jeden")) {
			zjedynkowym = !zjedynkowym;
		}
		else if (!strcmp(input, "conva")) {
			printf("wprowadz system zrodlowy  ");
			int system;
			cin >> system;
			string liczba = "";
			printf("wprowadz liczbe ");
			cin >> liczba;
			long converted = todec(system, liczba);
			if (converted == -1) {
				printf("sproboj ponownie");
			}
			else {
				for (size_t i = zjedynkowym ?  1 : 2 ; i < 17; i++)
				{
					cout << liczba << "(" << system << ")" << " to " << toany(i, converted)<<"(" <<i << ")\n";
				}
			}
		}
		else
		{
			system("cls");
			printf("nieznana komenda\n");
		}
		;
	}



}
 