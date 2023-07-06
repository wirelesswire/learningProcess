#include <iostream>
#include <vector>
using namespace std;
class funct {    
public :
    char *  name;
    int (*function)(int, int);
    funct(char *  name, int(*function)(int,int)) {
        this->name = name;
        this->function = function;
    }
    funct() {
    }
};
int add(int a ,int b)  {
    return a + b;
}
int subtract(int a,int b) {
    return a - b;
}
int multiply(int a , int b ) {
    return (a * b);
}
int main()
{
    int(*b)(int,int)   { &add };
    int(*c)(int,int)   {&subtract};
    int(*u) (int, int) { &multiply }; 
    char  d[] = "add";
    char  z[] = "subtract";
    char  f[] = "multiply";
    funct a[]  {funct(d,b),funct(z, c),funct(f,u)};
    bool go = true;
    while (go)
    {
        std::cout << "wpisz nazwe funkcji(add,subtract,multiply) lub q aby wyjsc\n";
        char  line[10];
        cin >> line;
        system("cls");


        if (!strcmp( line ,"q")) {
            go = false;
        }
        else {
            for (size_t i = 0; i <sizeof(a)/sizeof(a[0]); i++)
            {
                if (!strcmp( a[i].name, line)) {
                    int  a1;
                    int  a2;
                    printf("wpisz 1 argument\n");
                    cin >> a1;
                    printf("wpisz 2 argument\n");
                    cin >> a2;
                    cout <<"wynik: "  << a[i].function(a1, a2)<<"\n";
                }
            }

        }
    }
}