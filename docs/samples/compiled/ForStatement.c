void main ( void ) ;
long long int sum ;
void main ( void )
{
    sum = 0;
    for( long long int x = 0 ; x <= 10 ; x ++ )
    {
        for( long long int y = 0 ; y <= x ; y ++ )
        {
            sum = ( sum + ( x * y ) );
        }
    }
}
