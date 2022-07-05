#ifndef PACKAGE_H_
#define PACKAGE_H_
#include "sys.h"

typedef struct sPkg__
{
	u8 length;
	u8 src_port;
	u8 dis_port;
	u8 remote_addrH;
	u8 remote_addrL;
	u8 data[59];	
	}sPkg;

#define newPkg(num)	\
struct 						\
{							\
	u8 length;			\
	u8 src_port;			\
	u8 dis_port;			\
	u8 remote_addrH;\
	u8 remote_addrL;\
	u8 data[num];		\
}


#endif 
