signed int sum ;
signed long Pow ( signed long a , signed long b ) ;
void main ( ) ;
signed long Pow ( signed long a , signed long b ) { signed long r = 1, i ; for ( i = 0 ; i < b ; i ++ ) { r *= a ; } return r ; }
void main ( )
{
    sum = 0 ;
    signed char _a [ ] = { 0 , 15 , 1 } ; _a [ 2 ] = ( _a [ 0 ] < _a [ 1 ] ? 1 : -1 ) ; signed char a = _a [ 0 ] ; do { sum = ( sum + Pow ( 2 , a ) ) ; a = 0 ; _a [ 0 ] += _a [ 2 ] ; a = _a [ 0 ] ; } while ( a != _a [ 1 ] + _a [ 2 ] ) ;
}