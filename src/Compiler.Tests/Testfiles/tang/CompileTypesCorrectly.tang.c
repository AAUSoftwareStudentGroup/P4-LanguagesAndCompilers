unsigned char on ;
signed char sc ;
signed int si ;
signed long sl ;
signed long Pow ( signed long a , signed long b ) ;
void main ( ) ;
signed long Pow ( signed long a , signed long b ) { signed long r = 1 , i ; for ( i = 0 ; i < b ; i ++ ) { r *= a ; } return r ; }
void main ( )
{
    on = 1 ;
    sc = 127 ;
    si = 32767 ;
    sl = 2147483647 ;
}