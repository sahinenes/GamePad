/*
 * GamePad.c
 *
 * Created: 4.02.2021 13:18:53
 * Author : Enes
 */ 
#define F_CPU 16000000
#include <avr/io.h>
#include "uart.h"
#include "Keypad.h"
#include <avr/interrupt.h>
#include <stdlib.h>
volatile char key;
char str[50];


 


int main(void)
{
  init_uart(9600);
  key=Key_None;
  KP_Setup();						
   
   
    while (1) 
    {
		
		  key = KP_GetKey();
		  
		  //If key is pressed
		  if (key != Key_None )
		  {
			 
			  int new_value=key-48;
			  itoa(new_value,str,10);
			  send_uart(str);
			  send_uart("\n");
			  key=Key_None;
			 
		  }
		  else
		  {
			  key=Key_None;
		  }
	

	
    }
}

