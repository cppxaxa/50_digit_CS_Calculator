#include <stdio.h>
#include <string.h>
#include <stdio.h>
#include <stdlib.h>

extern "C"
{
	int len_obj(int a[]){
		int i = 0;
		while(a[i] != -1)
			i++;
		return i;
	}


	void swap_obj(int *p, int *q){
		int t = *p;
		*p = *q;
		*q = t;
	}

	__declspec(dllexport) void invert_obj(int a[]){
		int *p = a;
		int *q = len_obj(a) + a - 1;

		while(p < q){
			swap_obj(p, q);

			p++;
			q--;
		}
	}

	__declspec(dllexport) void diminish_obj(int a[]){
		int l = len_obj(a);

		invert_obj(a);

		int *p = l + a - 1;

		while(*p == 0 && p != a){
			*p = -1;
			*(p+1) = 0;

			p--;
		}

		invert_obj(a);
	}

	__declspec(dllexport) void swap_clone_obj(int a[], int b[]){
		//for(int i = 0; i < len_obj(a) || i < len_obj(b); i++){
		for(int i = 0; i < 100; i++){
			swap_obj(a + i, b + i);
		}
	}

	__declspec(dllexport) int greater_obj(int a[], int b[]){
		int p = len_obj(a);
		int q = len_obj(b);

		if(p > q)
			return 1;
		if(p < q)
			return 0;

		for(int i = 0; i < p; i++){
			//printf("%d > %d\n", a[i], b[i]);
			if(a[i] > b[i])
				return 1;
			if(a[i] < b[i])
				return 0;
		}

		return 0;
	}

	__declspec(dllexport) void print_obj(int a[]){
		if(a[0] == -1){
			printf("0");
			return;
		}

		for(int i = 0; a[i] != -1; i++){
			printf("%d", a[i]);
		}
	}

	__declspec(dllexport) void add_obj(int a[], int b[], int c[]){
		invert_obj(a);
		invert_obj(b);
		
		
		int i = 0;
		int carry = 0;
		
		while(i < len_obj(a) && i < len_obj(b)){
			c[i] = a[i] + b[i] + carry;
			carry = c[i] / 10;
			c[i] = c[i] % 10;

			i++;
		}

		while(i < len_obj(a)){
			c[i] = a[i] + carry;
			carry = c[i] / 10;
			c[i] = c[i] % 10;

			i++;
		}

		while(i < len_obj(b)){
			c[i] = b[i] + carry;
			carry = c[i] / 10;
			c[i] = c[i] % 10;

			i++;
		}

		c[i] = -1;


		invert_obj(a);
		invert_obj(b);
		invert_obj(c);		

		diminish_obj(a);
		diminish_obj(b);
		diminish_obj(c);
	}

	__declspec(dllexport) void sub_obj(int a[], int b[], int c[]){
		invert_obj(a);
		invert_obj(b);
		
		
		int i = 0;
		int borrow = 0;
		
		// Assume a is greater than b

		while(i < len_obj(a) && i < len_obj(b)){
			int t = a[i] - borrow;
			borrow = 0;

			if(t < 0 || t < b[i]){
				t += 10;
				borrow = 1;
			}

			c[i] = t - b[i];

			i++;
		}

		while(i < len_obj(a)){
			int t = a[i] - borrow;
			borrow = 0;

			if(t < 0){
				t += 10;
				borrow = 1;
			}

			c[i] = t;

			i++;
		}

		c[i] = -1;


		invert_obj(a);
		invert_obj(b);
		invert_obj(c);

		diminish_obj(a);
		diminish_obj(b);
		diminish_obj(c);
	}

	__declspec(dllexport) int smaller_obj(int a[], int b[]){
		if(greater_obj(a, b)){
			return 0;
		}
		else if(greater_obj(b, a)){
			return 1;
		}

		return 0;
	}

	__declspec(dllexport) int equal_obj(int a[], int b[]){
		if(greater_obj(a, b) == 0 && greater_obj(b, a) == 0)
			return 1;
		return 0;
	}

	__declspec(dllexport) int is_zero_obj(int a[]){
		diminish_obj(a);

		if(a[0] == -1)
			return 1;
		return 0;
	}

	__declspec(dllexport) void mul_obj(int a[], int b[], int c[]){
		int p = len_obj(a);
		int q = len_obj(b);
		
		invert_obj(a);
		invert_obj(b);

		int max_i = 0;

		for(int s = 0; s < q; s++){
			int sum = 0;
			int carry = 0;

			for(int f = 0; f < p; f++){

				sum = b[s] * a[f];

				if(c[s + f] != -1)
					sum = sum + c[s + f];

				carry = sum / 10;
				sum = sum % 10;

				c[ s + f ] = sum;

				int i = s + f + 1;
				while(carry > 0){
					c[i] = c[i] + carry;
					carry = c[i] / 10;
					c[i] = c[i] % 10;
					
					i++;
				}

				if(max_i < i)
					max_i = i;

				/*printf("%d * %d : Array : ", b[s], a[f]);
				for(int i = 0; i < 10; i++)
					printf("%d", c[i]);
				printf("\n");*/
			}
		}

		c[max_i] = -1;

		invert_obj(a);
		invert_obj(b);
		invert_obj(c);
	}

	__declspec(dllexport) void clone_obj(int a[], int b[]){
		for(int i = 0; i < 100; i++)
			b[i] = a[i];
	}

	__declspec(dllexport) void div_obj(int a[], int b[], int c[]){
		int ba[100], one[100], bc[100], newa[100];
		for(int i = 0; i < 100; i++){
			newa[i] = ba[i] = a[i];
			bc[i] = 0;
			c[i] = 0;
			one[i] = 0;
		}
		
		one[0] = 1;
		one[1] = -1;

		bc[0] = -1;
		c[0] = -1;

		/*
		newa = a
		ba = a

		bc = 0
		c = 0
		one = 1
		*/

		while(greater_obj(ba, b)){
			add_obj(one, bc, c);
			clone_obj(c, bc);
			sub_obj(ba, b, newa);
			clone_obj(newa, ba);

			/*

			1 + bc = c
			bc = c
			newa = ba - b
			ba = newa


			if(a > b)
				c++
				a -= b


			create backup a, b, c
			*/
		}

		if(equal_obj(ba, b)){
			add_obj(one, bc, c);
		}
	}
}
