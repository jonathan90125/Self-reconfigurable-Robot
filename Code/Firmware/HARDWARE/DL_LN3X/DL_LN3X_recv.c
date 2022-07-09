#include "lee.h"
#include "led.h"
#include "package.h"
#include "usart.h"
#include "sys.h"



typedef struct sPkgBase__
{
	u8 length;
	u8 data[63];
}sPkgBase;

 
static void recvHead(u8 totle);
 
static void recvTerminal(void);
 
static void recvData(u8 data);
 
static u8 escape = no;

 
void uartRevieveByte(u8 data)
{
	switch(data)
	{
		case 0xff: 
		recvTerminal();
		break;
		case 0xfe: 
		escape = yes;
		break;
		default: 
		if(escape == yes)
		{ 
			escape = no;
			if(data <=63)
			{
				recvHead(data);
			}
			else
			{ 
				recvData(data+2);
			}
		}
		else
		{ 
			recvData(data);
		}
		break;
	}
}



 static sPkgBase recv_temp[2];
 
static volatile  u8 Loading = 0;
 
#define Load_pkg recv_temp[Loading]
 
#define User_pkg recv_temp[(Loading+1)&1]

 
#define RS_IDLE 0XFF 
#define RS_DONE 0xA0 
static volatile u8 Recv_counter = RS_IDLE;

 
static volatile u8 Received = no;
 
static volatile u8 Locked = no;


sPkg* getNextPkg(void)
{
	sPkg* rev;
	
	Locked = no;

	if(Received == yes)
	{ 
		Received =no;
		Locked = yes;
		rev = (sPkg*)(&User_pkg);
	}
	else
	{ 
		if(Recv_counter == RS_DONE)
		{ 
			Loading++;
			Loading&=1;
			Recv_counter = RS_IDLE;	
			Locked = yes;
			rev = (sPkg*)(&User_pkg);			
		}
		else
		{ 
			rev = NULL;
		}		
	}	
	 
	return rev;
}



static void recvHead(u8 totle)
{
	if(Recv_counter == RS_IDLE)
	{
		Load_pkg.length = totle;
		Recv_counter = 0;
	}
}

static void recvData(u8 data)
{	
	if(Recv_counter < Load_pkg.length)
	{		
		Load_pkg.data[Recv_counter] = data;
		Recv_counter++;
	}
	else
	{
		Recv_counter = RS_IDLE;
	}
}

static void recvTerminal(void)
{
	if(Recv_counter == Load_pkg.length)
	{ 
		if(Locked == no)
		{ 
			Loading++;
			Loading&=1;
			Received = yes;
			Recv_counter = RS_IDLE;
		} 
		else
		{ 
			Recv_counter = RS_DONE;
		}
	}
	else
	{	 
		Recv_counter = RS_IDLE;
	}
}
