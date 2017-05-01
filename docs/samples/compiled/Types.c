unsigned char ui8 ;
unsigned int ui16 ;
unsigned long ui32 ;
signed char i8 ;
signed int i16 ;
signed int i32 ;
unsigned char b ;
volatile unsigned char * r8 ;
volatile unsigned short * r16 ;
void __vector_21 ( void ) ;
void main ( ) ;
void __vector_21 ( )
{
    ui8 = 10 ;
}
void main ( )
{
    ui8 = 8 ;
    ui16 = 16 ;
    ui32 = 32 ;
    i8 = 8 ;
    i16 = 16 ;
    i32 = 32 ;
    b = 1 ;
    r8 = ( volatile unsigned char * ) ( 8 ) ;
    r16 = ( volatile unsigned short * ) ( 16 ) ;
}
