```c
#include <stdio.h>
#include <time.h>

int main() {
    clock_t start = clock();

    // Здесь размещается измеряемый код

    clock_t end = clock();
    double seconds = (double)(end - start) / CLOCKS_PER_SEC;

    printf("The time: %f seconds\n", seconds);
}

```c
#include <stdio.h>
#include <time.h>

int main() {
    time_t start, end;

    time(&start);

    // Здесь размещается измеряемый код

    time(&end);

    double seconds = difftime(end, start);

    printf("The time: %f seconds\n", seconds);
}
