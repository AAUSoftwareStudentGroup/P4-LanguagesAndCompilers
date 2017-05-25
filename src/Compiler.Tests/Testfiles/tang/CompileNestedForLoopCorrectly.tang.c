signed long sum ;
signed long Pow ( signed long a , signed long b ) ;
void main ( ) ;
signed long Pow ( signed long a , signed long b ) { signed long r = 1 , i ; for ( i = 0 ; i < b ; i ++ ) { r *= a ; } return r ; }
void main ( )
{
    sum = 0 ;
    signed char _x [ ] = { 0 , 10 , 1 } ; _x [ 2 ] = ( _x [ 0 ] < _x [ 1 ] ? 1 : -1 ) ; signed char x = _x [ 0 ] ; do { signed char _y [ ] = { 0 , x , 1 } ; _y [ 2 ] = ( _y [ 0 ] < _y [ 1 ] ? 1 : -1 ) ; signed char y = _y [ 0 ] ; do { sum = ( sum + ( x * y ) ) ; _y [ 0 ] += _y [ 2 ] ; y = _y [ 0 ] ; } while ( y != _y [ 1 ] + _y [ 2 ] ) ; _x [ 0 ] += _x [ 2 ] ; x = _x [ 0 ] ; } while ( x != _x [ 1 ] + _x [ 2 ] ) ;
}