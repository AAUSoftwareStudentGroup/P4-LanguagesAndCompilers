void main ( void ) ;
unsigned long sum ;
void main ( void )
{
    sum = 0;
    for( signed char x = 0 ; x <= 10 ; x ++ )
    {
        for( signed char y = 0 ; y <= x ; y ++ )
        {
            sum = ( sum + ( x * y ) );
        }
    }
}
