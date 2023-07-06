#include <iostream>
#include <string>
#include <vector>
using namespace std;
struct  Figura {
public:
	char nazwa[20]{};
	float pole{};
	float obwod{};
	struct Figura* next{};
	struct Figura* previous{};
	virtual float  LiczPole() {
		return NULL;
	}
	virtual float LiczObwod() {
		return NULL;
	}
	virtual void printSelf() {
		cout << "nazwa" << nazwa << " pole: " << pole << "/" << pole << " obwod : " << obwod;
	}
};
struct  Kolo : public  Figura {
public:
	float r;
	Kolo(float r) {
		this->r = r;
		strcpy_s(this->nazwa, "kolo");
		LiczPole();
		LiczObwod();
	}
	float LiczPole() override {
		this->pole = 3.14 * r * r;
		return this->pole;
	};
	float LiczObwod() override {
		this->obwod = 2 * 3.14 * r;
		return this->obwod;
	};
	void printSelf() override {
		cout << "ta figura to KOLO o promieniu " << this->r << " polu " << this->pole << " i obwodzie " << this->obwod;
	}
};
struct  Prostokat : public Figura {
	int a, b;
public:
	Prostokat(int a, int b) {
		this->a = a;
		this->b = b;
		strcpy_s(this->nazwa, "prostokat");
		LiczPole();
		LiczObwod();
	}
	float LiczPole() override {
		this->pole = a * b;
		return this->pole;
	};
	float LiczObwod() override {
		this->obwod = (a + b) * 2;
		return this->obwod;
	};
	void printSelf() override {
		cout << "ta figura to PROSTOKAT o bokach a :  " << this->a << " i  b : " << this->b << " , polu " << this->pole << " i obwodzie " << this->obwod;
	}
};
struct  Trojkat : public Figura {
	float a, b, c, h;
public:
	Trojkat(float a, float b, float c, float h) {
		this->a = a;
		this->b = b;
		this->c = c;
		this->h = h;
		strcpy_s(this->nazwa, "trojkat");
		LiczPole();
		LiczObwod();
	}
	float LiczPole() override {
		this->pole = 0.5 * a * h;
		return this->pole;
	};
	float LiczObwod() override {
		this->obwod = a + b + c;
		return this->obwod;
	};
	void printSelf() override {
		cout << "ta figura to TROJKAT o bokach  a : " << this->a << ", b: " << this->b << " ,c : " << this->c << " i wysokosci  " << this->h << " polu " <<this->pole<< " i obwodzie " << this->obwod;
	}
};
struct  List
{
public:
	Figura* currentItem;
	int count;
	List* self;
	void addEnd(Figura* b ) {
		policz();
		if (count == 0 ) {
			policz();

			return;
		}
		else
		{
			int z = goToEnd();
			currentItem->next = b;
			b->previous = currentItem;
			for (size_t i = 0; i < z; i++)
			{
				previousItem();
			}
		}
		policz();
	}
	void addBegining(Figura* c) {
		policz();
		if (count == 0) {
			addEnd(c);
			return;
		}
		if (currentItem == NULL) {
			currentItem = c;
			policz();
			return;
		}
		int z = goToStart();
		currentItem->previous = c;
		c->next = currentItem;
		for (size_t i = 0; i < z; i++)
		{
			nextItem();
		}
		policz();
	}
	void addPlace(Figura* k, int placeNumber) {
		policz();
		if (count == 0) {
			addEnd(k);
			return;
		}
		if (placeNumber == 0) {
			addBegining(k);
			return;
		}
		if (placeNumber > count) {
			cout << "numer miejsca poza zakresem dodano na koniec \n";
			policz();
			addEnd(k);
			return;
		}
		placeNumber -= 1;

		int b = goToStart();
		for (size_t i = 0; i < placeNumber ; i++)
		{
			nextItem();
		}
		if (currentItem->next != NULL) {
			k->next = currentItem->next;
			currentItem->next->previous = k;
		}
		currentItem->next =k;
		k->previous = currentItem;
		goToStart();
		for (size_t i = 0; i < (placeNumber < b ? b+1 : b); i++)
		{
			nextItem();
		}
		policz();

	}
	void policz() {
		int a = goToStart();
		if (currentItem != NULL) {
			count = 1;
		}
		else {
			count = 0;
			return;
		}
		count += goToEnd();

		goToStart();
		for (size_t i = 0; i < a; i++)
		{
			nextItem();
		}
	}
	void deletePlace(int placeNumber) {
		if (placeNumber > count) {
			cout << "numer miejsca poza zakresem  count : " << count << " numer wskazany : "<< placeNumber<<"\n";
			return;
		}
		int b = goToStart();
		for (size_t i = 0; i < placeNumber-1; i++)
		{
			nextItem();
		}
		deleteCurrent();
		goToStart();
		for (size_t i = 0; i < (placeNumber-1 < b ? b -1 : b); i++)
		{
			nextItem();
		}
	}
	void deleteCurrent() {
		if (currentItem == NULL) {
			return;
		}
		if (currentItem->next == NULL && currentItem->previous == NULL) {
			currentItem = NULL;
			policz();
			return;
		}
		if (currentItem->next != NULL) {
			currentItem->next->previous = currentItem->previous;
		}
		if (currentItem->previous != NULL) {
			currentItem->previous->next = currentItem->next;
		}
		if (!previousItem()) {
			nextItem();
		}
		policz();
	}
	int  goToStart() {
		int a = 0;
		while (previousItem())
		{
			a++;
		}
		return a;
	}
	int  goToEnd() {
		int a = 0;
		while (nextItem())
		{
			a++;
		}
		return a;
	}
	void showAll() {
		int z = goToStart();
		cout << "{";
		bool c;
		int counter = 1;
		do
		{
			cout << "\n";
			if (counter != z+1) {
				cout << counter;
			}
			else {
				cout << char(26);
			}
			cout <<" " << "[ ";
			showCurrent();
			c = nextItem();
			cout << " ]";
			counter++;
		} while (c);
		cout << "\n}\n";
		goToStart();
		for (size_t i = 0; i < z; i++)
		{
			nextItem();
		}
	}
	void showCurrent() {
		if (currentItem != NULL) {
			currentItem->printSelf();
			return;
		}
		cout << "lista jest pusta ";

	}
	bool nextItem() {
		if (currentItem != NULL) {
			if (currentItem->next != NULL) {
				if (currentItem->next != currentItem) {
					currentItem = currentItem->next;
					return true;
				}
			}
		}

		return false;
	}
	bool  previousItem() {

		if (currentItem != NULL) {
			if (currentItem->previous != NULL) {
				if (currentItem->previous != currentItem) {
					currentItem = currentItem->previous;
					return true;
				}

			}
		}

		return false;
	}
	List(Figura* firstItem  ) {
		this->currentItem = firstItem;
		this->currentItem->next = NULL;
		this->currentItem->previous = NULL;
		this->count = 0;
		policz();
	}
	List() {
		this->count = 0;
		this->currentItem = NULL;
	}
};
void showHelp(bool satoggle , bool lptoggle) {
	cout<< "q-quit \nsc-show current\nsa-show all toggle("<<(satoggle ? "wlaczone" :"wylaczone" )
		<<")\nlp-light print toggle(" << (lptoggle ? "wlaczone" : "wylaczone") 
		<<") \nh-help\nn-next\np-previous\nadd-add last \naddpos-add at position\ndel-delete current \ndelpos-delete from positon \n";
}
int* getsomeanswers(int howmany) {
	int* a = new int[10];
	for (size_t i = 0; i < howmany; i++)
	{
		cout << "arg " << i + 1 << ": ";
		int b;
		cin >> b;
		a[i] = b;
	}
	return a;
}
void ezprint(List lista) {
	int a = lista.goToStart();
	if (lista.count == 0 ) {
		return;
	}
	int i = 0; 
	cout << "numer " << "nazwa       " << "pole        " << "obwod       " << "\n";
	int counter = 1;
	do
	{
		if (counter != a+1) {
			cout << counter;
		}
		else {
			cout << char(26);
		}

		cout << "     ";
		printf_s("%-10s  %-10.2f  %-10.2f  \n", lista.currentItem->nazwa , lista.currentItem->pole , lista.currentItem->obwod);
		counter++;
	} while (lista.nextItem());

	lista.goToStart();
	for (size_t i = 0; i < a; i++)
	{
		lista.nextItem();
	}
}
void makeitem(List & lista, int place = -1) {
	printf("podaj nazwe\n");
	printf("mozliwe  nazwy(ilosc argumentow) : kolo(int r), trojkat(int a,int b, int c, int h), prostokat(int a, int b)\n");
	bool go = true;
	int* cd;
	char nzw[10];
	while (go) {
		cin >> nzw;
		if (!strcmp(nzw, "trojkat")) {
			go = false;
			cd = getsomeanswers(4);
			Figura* tr = new Trojkat(cd[0], cd[1], cd[2], cd[3]);
			if (lista.count == 0) {
				List l = List(tr);
				lista = l;
				return;
			}
			if (place == -1) {
				
				lista.addEnd(tr);
			}
			else {
				lista.addPlace(tr, place);
			}
		}
		else if (!strcmp(nzw, "kolo")) {
			go = false;
			cd = getsomeanswers(1);
			Figura* kolo = new Kolo(cd[0]);
			if (lista.count == 0) {
				List l = List(kolo);
				lista = l;
				return;
			}
			if (place == -1) {
				lista.addEnd(kolo);
			}
			else {
				lista.addPlace(kolo, place);
			}
		}
		else if (!strcmp(nzw, "prostokat")) {
			go = false;
			cd = getsomeanswers(2);
			Figura* pr = new Prostokat(cd[0], cd[1]);

			if (lista.count == 0) {
				List l = List(pr);
				lista = l;
				return;
			}
			if (place == -1) {
				lista.addEnd(pr);
			}
			else {
				lista.addPlace(pr, place);
			}
		}
		else {
			printf("cos nie tak z argumetami sprobuj ponownie\n");
			return;
		}
	}
}

void showGeneral(bool showall , bool printlight ,List lista ) {
	if (showall) {
		lista.showAll();
	}
	else
	{
		if (printlight) {
			ezprint(lista);
		}
	}
}

int main()
{
	Figura* tmp = new  Kolo(10);
	List  lista;
	lista = List(tmp );
	Figura* abc = new Kolo(4);
	Figura* abcff = new Kolo(5);
	Figura* abcf = new Kolo(3);
	Figura* abcffd = new Kolo(3);
	Figura* trojkat = new Trojkat(3, 4, 5, 4);
	Figura* prostokat = new Prostokat(2, 3);
	lista.addEnd(abc);
	lista.addEnd(abcf);
	lista.addEnd(abcff);
	lista.addEnd(abcffd);
	lista.addEnd(trojkat);
	lista.addEnd(prostokat);
	bool run = true;
	bool helpprompt = true;
	bool showall = false ; 
	bool printlight = true;
	while (run)
	{
		showGeneral(showall,printlight,lista);		
		lista.policz();

		cout << "ilosc  : " << lista.count << "\n";
		if (helpprompt) {
			printf("h-help\n");
			helpprompt = false;
		}
		cout << "command : ";
		char a[10];
		cin >> a;
		std::system("cls");

		if (!strcmp(a, "q")) {
			run = false;
		}
		else  if (!strcmp(a, "sa")) {
			showall = !showall;
		}
		else  if (!strcmp(a, "lp")) { 
			printlight = !printlight;
		}
		else if (!strcmp(a, "sc"))
		{
			cout << "current item  : ";
			lista.showCurrent();
			cout << "\n";
		}
		else if (!strcmp(a, "h"))
		{
			showHelp(showall ,printlight);
		}
		else if (!strcmp(a, "n"))
		{
			lista.nextItem();
		}
		else if (!strcmp(a, "p"))
		{
			lista.previousItem();
		}
		else if (!strcmp(a, "add")) {
			showGeneral(showall, printlight, lista);
			makeitem(lista);
			std::system("cls");
		}
		else if (!strcmp(a, "addpos")) {
			showGeneral(showall, printlight, lista);
			cout << "po ktorej pozycji(0-" << lista.count<< ") : ";
			int z;
			cin >> z;
			makeitem(lista, z);
		}
		else if (!strcmp(a, "del"))
		{
			lista.deleteCurrent();
		}
		else if (!strcmp(a, "delpos"))
		{
			showGeneral(showall, printlight, lista);
			if (lista.count != 0) {
				cout << "z ktorej pozycji(1-" << lista.count << ") : ";
				int z;
				cin >> z;
				if (z <= 0 || z>lista.count) {
					cout << "nieprawidlowy numer  indeksu\n";
					continue;
				}
				lista.deletePlace(z);
			}
			else
			{
				cout << "lista jest pusta nie ma skad usuwac  \n";
			}
			
		}
		else if (!strcmp(a, "c")) {
			std::system("cls");
			helpprompt = true;
		}
		else {
			printf("nie rozpoznano komendy sprobuj ponownie\n");
			helpprompt = true;
		}
	}
}



