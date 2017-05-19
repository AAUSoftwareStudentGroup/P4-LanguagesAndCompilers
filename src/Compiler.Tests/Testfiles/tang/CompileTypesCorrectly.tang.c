unsigned char on ;
signed char sc ;
signed int si ;
signed long sl ;
unsigned char uc ;
unsigned int ui ;
unsigned long ul ;
int Pow ( signed long a , unsigned long b ) ;
void main ( ) ;
int Pow ( signed long a , unsigned long b ) { signed long r = 1 ; for ( unsigned long i = 0 ; i < b ; i ++ ) { r *= a ; } return r ; }
void main ( )
{
    on = 1 ;
    sc = 127 ;
    si = 32767 ;
    sl = 9223372036854775807 ;
    uc = 255 ;
    ui = 65535 ;
    ul = 4294967295 ;
}