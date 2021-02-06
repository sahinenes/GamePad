
/*
 * uart.c
 *
 * Created: 25.12.2020 21:39:21
 *  Author: Enes
 */ 
#define F_CPU 16000000
#include <avr/io.h>7


void init_uart(int baud)
{
	uint16_t baudRate=F_CPU/baud/16-1;
	UBRR0H=(baudRate>>8);
	UBRR0L=baudRate;
	UCSR0B|=(1<<RXEN0)|(1<<TXEN0);
	UCSR0C|=(1<<UCSZ00)|(1<<UCSZ01);
	
}
void send_uart( char *mesaj)
{
	while(*mesaj!='\0')
	{
		while(!(UCSR0A & (1<<UDRE0)));
		UDR0=*mesaj;
		mesaj++;
	}

}

unsigned char get_string()
{
	while(!(UCSR0A & (1<<RXC0)));
	return UDR0;
}